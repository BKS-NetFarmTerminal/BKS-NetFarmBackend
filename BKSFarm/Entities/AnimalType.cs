namespace BKSFarm.api.Entities
{
    public class AnimalType
    {
        public Guid AnimalTypeId { get; set; }

        public string AnimalName { get; set; }

        public double AnimalPrice { get; set; }

        public DateTime TimeOfGrowing { get; set; }
    }
}
