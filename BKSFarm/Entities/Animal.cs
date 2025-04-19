using System.ComponentModel.DataAnnotations.Schema;

namespace BKSFarm.api.Entities
{
    public class Animal
    {
        public Guid AnimalId { get; set; }

        public string AnimalImageUrl { get; set; }

        public string AnimalType { get; set; }

        public int AnimalStage { get; set; }

        public long DateCreate { get; set; }
            
        public long DieTime { get; set; }

        public long TimeToLvlUp { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
