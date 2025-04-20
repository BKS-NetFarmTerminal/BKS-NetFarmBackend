using System.ComponentModel.DataAnnotations;

namespace BKSFarm.api.Extentions.Auth
{
	public class LoginRequest
	{
		[Required]
		public string WalletToken { get; set; }
	}
}
