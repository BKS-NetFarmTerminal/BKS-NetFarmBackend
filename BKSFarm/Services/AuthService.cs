using BKSFarm.api.Data;
using BKSFarm.api.Entities;
using BKSFarm.api.Extentions.Auth;
using BKSFarm.api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BKSFarm.api.Services
{
	public class AuthService : IAuthService
	{
		private readonly DataContext _context;
		private readonly IConfiguration _config;

		public AuthService(DataContext context, IConfiguration config)
		{
			_context = context;
			_config = config;
		}

		public async Task<AuthResult> Authenticate(string walletToken)
		{
			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.Token == walletToken);

			if (user == null)
				return new AuthResult { Success = false, Error = "User not found" };

			var token = GenerateJwtToken(user);
			return new AuthResult { Success = true, Token = token };
		}

		public async Task<AuthResult> Register(string walletToken)
		{
			if (await _context.Users.AnyAsync(u => u.Token == walletToken))
				return new AuthResult { Success = false, Error = "User already exists" };

			var user = new User { Token = walletToken };
			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			var token = GenerateJwtToken(user);
			return new AuthResult { Success = true, Token = token };
		}

		private string GenerateJwtToken(User user)
		{
			var securityKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

			var credentials = new SigningCredentials(
				securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
			new Claim(JwtRegisteredClaimNames.Sub, user.Token),
			new Claim("userId", user.UserId.ToString()),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
			};

			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(
					_config.GetValue<int>("Jwt:ExpireMinutes")),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
