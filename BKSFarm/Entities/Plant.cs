using System.ComponentModel.DataAnnotations.Schema;

namespace BKSFarm.api.Entities
{
    public class Plant
    {
        public Guid PlantId { get; set; }

        public string PlantName { get; set; }

        public string? PlanType { get; set; }

        public string PlantImageUrl { get; set; }

        public int PlantStage {  get; set; }

        public long DateCreate { get; set; }

        public long DieTime { get; set; }

        public long TimeToLvlUp { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}
