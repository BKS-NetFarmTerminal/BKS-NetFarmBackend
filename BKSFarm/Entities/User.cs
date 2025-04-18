namespace BKSFarm.api.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public double Money { get; set; }


    }
}
