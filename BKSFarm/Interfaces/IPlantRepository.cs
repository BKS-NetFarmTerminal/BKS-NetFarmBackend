using BKSFarm.api.Entities;
using BKSFarm.Dto.Plant;

namespace BKSFarm.api.Interfaces
{
    public interface IPlantRepository
    {
		public Task<Plant> CreatePlant(CreatePlantDto dto);
		public Task<Plant> UpdatePlant(Guid id, UpdatePlantDto dto);
		public Task<Plant> GetPlantById(Guid id);
		public Task<List<Plant>> GetAllPlants();
		public Task<bool> DeletePlant(Guid id);
	}
}
