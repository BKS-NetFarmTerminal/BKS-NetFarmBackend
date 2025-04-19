using System.ComponentModel.DataAnnotations.Schema;

namespace BKSFarm.api.Entities
{
	public class UserAnimal
	{
		public Guid Id { get; set; }
		public DateTime DateCreate { get; set; }
		public DateTime DateUpdate { get; set; }
		public string Type { get; set; }
		public string ImageUrl { get; set; }
		public int Stage { get; set; } = 0;
		public Guid UserId { get; set; }
		[ForeignKey("UserId")]
		public User User { get; set; }
		public Guid AnimalId { get; set; }
		[ForeignKey("AnimalId")]
		public Animal Animal { get; set; }
	}
}
