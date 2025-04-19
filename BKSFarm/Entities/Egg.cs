using System.ComponentModel.DataAnnotations.Schema;

namespace BKSFarm.api.Entities
{
    public class Egg
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
        public List<UserEgg> UserEgg { get; set; }
    }
}
