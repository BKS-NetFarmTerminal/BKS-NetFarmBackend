using BKSFarm.api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BKSFarm.api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			var result = await _authService.Authenticate(request.WalletToken);

			if (!result.Success)
				return Unauthorized(new { result.Error });

			return Ok(new { result.Token });
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequest request)
		{
			var result = await _authService.Register(request.WalletToken);

			if (!result.Success)
				return BadRequest(new { result.Error });

			return Ok(new { result.Token });
		}
	}

	public class LoginRequest
	{
		[Required]
		public string WalletToken { get; set; }
	}

	public class RegisterRequest
	{
		[Required]
		public string WalletToken { get; set; }
	}
}
