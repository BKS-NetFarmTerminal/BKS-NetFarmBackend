namespace BKSFarm.api.Entities
{
    public class Animals
    {
        public Guid AnimalsId { get; set; }

        public double LocationX { get; set; }   

        public double LocationY { get; set; }


        public DateTime TimeOfGrowingUpEnd { get; set; }
    }
}
