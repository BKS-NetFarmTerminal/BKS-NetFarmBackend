using BKSFarm.api.Data;
using BKSFarm.api.Entities;
using BKSFarm.api.Interfaces;
using BKSFarm.Dto.Animal;
using Microsoft.EntityFrameworkCore;

namespace BKSFarm.api.Repository
{
	public class AnimalRepository : IAnimalRepository
	{
		private readonly DataContext _ctx;
		public AnimalRepository(DataContext ctx)
		{
			_ctx = ctx;
		}
		private async Task<bool> AnimalExist(string animalType)
		{
			return await _ctx.Animals.AnyAsync(c => c.Type == animalType);
		}
		private async Task<bool> AnimalExist(Guid? id)
		{
			return await _ctx.Animals.AnyAsync(c => c.Id == id);
		}
		public async Task<Animal> CreateAnimal(CreateAnimalDto dto)
		{
			if (await AnimalExist(dto.Type) == false)
			{
				Animal animal = new Animal
				{
					Id = Guid.NewGuid(),
					Type = dto.Type,
					DieTime = dto.DieTime,
					TimeToLvlUp = dto.TimeToLvlUp,
				};
				if (animal != null)
				{
					var result = await _ctx.Animals.AddAsync(animal);
					await _ctx.SaveChangesAsync();
					return animal;
				}
			}
			return null;
		}

		public async Task<bool> DeleteAnimal(Guid id)
		{
			var animal = await _ctx.Animals.FindAsync(id);
			if (animal != null)
			{
				_ctx.Animals.Remove(animal);
				await _ctx.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<List<Animal>> GetAllAnimals()
		{
			var animals = await _ctx.Animals.ToListAsync();
			return animals;
		}

		public async Task<Animal> GetAnimalById(Guid id)
		{
			if (await AnimalExist(id))
			{
				var animal = await _ctx.Animals.SingleOrDefaultAsync(m => m.Id == id);
				return animal;
			}
			return null;
		}

		public async Task<Animal> UpdateAnimal(Guid id, UpdateAnimalDto dto)
		{
			var animal = await _ctx.Animals.FindAsync(id);
			if (animal != null)
			{
				animal.Type = dto.Type;
				animal.DieTime = dto.DieTime;
				animal.TimeToLvlUp = dto.TimeToLvlUp;
				await _ctx.SaveChangesAsync();
				return animal;
			}
			return null;
		}
	}
}
