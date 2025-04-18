using System.ComponentModel.DataAnnotations.Schema;

namespace BKSFarm.api.Entities
{
    public class UserSeed
    {
        public Guid UserSeedId { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("SeedId")]
        public Guid SeedId { get; set; }
        public Seed Seed { get; set; } = null!;
    }
}
