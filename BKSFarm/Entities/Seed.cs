namespace BKSFarm.api.Entities
{
    public class Seed
    {
        public Guid Id { get; set; }

        public string Type { get; set; }
        public string ImageUrl { get; set; }
        public List<UserSeed> UserSeed { get; set; }
    }
}
