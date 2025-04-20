namespace BKSFarm.api.Extentions.Auth
{
	public class AuthResult
	{
		public bool Success { get; set; }
		public string? Token { get; set; }
		public string? Error { get; set; }
	}
}
