using BKSFarm.api.Entities;
using BKSFarm.Dto.Animal;

namespace BKSFarm.api.Interfaces
{
	public interface IAnimalRepository
	{
		public Task<Animal> CreateAnimal(CreateAnimalDto dto);
		public Task<Animal> UpdateAnimal(Guid id, UpdateAnimalDto dto);
		public Task<Animal> GetAnimalById(Guid id);
		public Task<List<Animal>> GetAllAnimals();
		public Task<bool> DeleteAnimal(Guid id);
	}
}
