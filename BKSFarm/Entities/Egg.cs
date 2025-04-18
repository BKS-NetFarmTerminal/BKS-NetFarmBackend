using System.ComponentModel.DataAnnotations.Schema;

namespace BKSFarm.api.Entities
{
    public class Egg
    {
        public Guid EggId { get; set; }

        public string EggName { get; set; }

        public string EggImageUrl { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
