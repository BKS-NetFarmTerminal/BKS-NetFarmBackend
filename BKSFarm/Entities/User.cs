using Microsoft.AspNetCore.Identity;

namespace BKSFarm.api.Entities
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Login { get; set; }

        public int FieldCount { get; set; }

        public List<UserSeed> Seeds { get; set; }

        public List<Plant> Plants { get; set; }

        public List<Egg> Eggs { get; set; }

        public List<Animal> Animals { get; set; }
    }
}
