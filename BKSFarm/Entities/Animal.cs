using System.ComponentModel.DataAnnotations.Schema;

namespace BKSFarm.api.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public long DieTime { get; set; }
        public long TimeToLvlUp { get; set; }
        public List<UserAnimal> UserAnimal { get; set; }
    }
}
