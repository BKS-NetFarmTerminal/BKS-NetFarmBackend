using BKSFarm.api.Extentions.Auth;

namespace BKSFarm.api.Interfaces
{
	public interface IAuthService
	{
		Task<AuthResult> Authenticate(string Token);
		Task<AuthResult> Register(string Token);
	}
}
