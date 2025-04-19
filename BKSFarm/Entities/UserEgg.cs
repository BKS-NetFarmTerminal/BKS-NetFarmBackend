using System.ComponentModel.DataAnnotations.Schema;

namespace BKSFarm.api.Entities
{
	public class UserEgg
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public Guid UserId { get; set; }
		[ForeignKey("UserId")]
		public User User { get; set; }
		public Guid EggId { get; set; }
		[ForeignKey("EggId")]
		public Egg Egg { get; set; }
	}
}
