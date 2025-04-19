using BKSFarm.api.Data;
using BKSFarm.api.Entities;
using BKSFarm.api.Interfaces;
using BKSFarm.Dto.Plant;
using BKSFarm.Dto.Seed;
using Microsoft.EntityFrameworkCore;

namespace BKSFarm.api.Repository
{
    public class PlantRepository : IPlantRepository
    {
        private readonly DataContext _ctx;
        public PlantRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

		private async Task<bool> PlantExist(string plantType)
		{
			return await _ctx.Plants.AnyAsync(c => c.Type == plantType);
		}
		private async Task<bool> PlantExist(Guid? id)
		{
			return await _ctx.Plants.AnyAsync(c => c.Id == id);
		}
		public async Task<Plant> CreatePlant(CreatePlantDto dto)
		{
			if (await PlantExist(dto.Type) == false)
			{
				Plant plant = new Plant
				{
					Id = Guid.NewGuid(),
					Type = dto.Type,
					DieTime = dto.DieTime,
					TimeToLvlUp = dto.TimeToLvlUp,
				};
				if (plant != null)
				{
					var result = await _ctx.Plants.AddAsync(plant);
					await _ctx.SaveChangesAsync();
					return plant;
				}
			}
			return null;
		}

		public async Task<bool> DeletePlant(Guid id)
		{
			var plant = await _ctx.Plants.FindAsync(id);
			if (plant != null)
			{
				_ctx.Plants.Remove(plant);
				await _ctx.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<List<Plant>> GetAllPlants()
		{
			var plants = await _ctx.Plants.ToListAsync();
			return plants;
		}

		public async Task<Plant> GetPlantById(Guid id)
		{
			if (await PlantExist(id))
			{
				var plant = await _ctx.Plants.SingleOrDefaultAsync(m => m.Id == id);
				return plant;
			}
			return null;
		}

		public async Task<Plant> UpdatePlant(Guid id, UpdatePlantDto dto)
		{
			var plant = await _ctx.Plants.FindAsync(id);
			if (plant != null)
			{
				plant.Type = dto.Type;
				plant.DieTime = dto.DieTime;
				plant.TimeToLvlUp = dto.TimeToLvlUp;
				await _ctx.SaveChangesAsync();
				return plant;
			}
			return null;
		}
	}
}
