using Microsoft.AspNetCore.Identity;

namespace BKSFarm.api.Entities
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Login { get; set; }
        public string Token { get; set; }

        public int FieldCount { get; set; } = 6;

        public List<UserSeed> Seed { get; set; }

        public List<UserPlant> Plants { get; set; }

        public List<UserEgg> Eggs { get; set; }

        public List<UserAnimal> Animals { get; set; }
    }
}
