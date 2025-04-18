using System.ComponentModel.DataAnnotations.Schema;

namespace BKSFarm.api.Entities
{
    public class Plant
    {
        public Guid PlantId { get; set; }

        public string PlantName { get; set; }

        public string PlanType { get; set; }

        public string PlantImageUrl { get; set; }

        public string PlantStage {  get; set; }

        public int DateCreate { get; set; }

        public int DieTime { get; set; }

        public int TimeToLvlUp { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}
