using System.ComponentModel.DataAnnotations.Schema;

namespace BKSFarm.api.Entities
{
    public class Animal
    {
        public Guid AnimalId { get; set; }

        public string AnimalImageUrl { get; set; }

        public string AnimalType { get; set; }

        public int AnimalStage { get; set; }

        public int DateCreate { get; set; }
            
        public int DieTime { get; set; }

        public int TimeToLvlUp { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
