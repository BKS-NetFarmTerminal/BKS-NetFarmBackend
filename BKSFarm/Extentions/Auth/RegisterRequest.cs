using System.ComponentModel.DataAnnotations;

namespace BKSFarm.api.Extentions.Auth
{
	public class RegisterRequest
	{
		[Required]
		public string WalletToken { get; set; }
	}
}
