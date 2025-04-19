using BKSFarm.api.Data;
using BKSFarm.api.Entities;
using BKSFarm.Dto.Seed;
using BKSFarm.Dto.Plant;

using Microsoft.EntityFrameworkCore;
using BKSFarm.api.Interfaces;

namespace BKSFarm.api.Repository
{
    public class SeedRepository : ISeedRepository
    {
        private readonly DataContext _ctx;
        public SeedRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        private async Task<bool> SeedExist(string seedType)
        {
            return await _ctx.Seeds.AnyAsync(c => c.Type == seedType);
        }
        private async Task<bool> SeedExist(Guid id)
        {
            return await _ctx.Seeds.AnyAsync(c => c.Id == id);
        }
        public async Task<Seed> CreateSeed(CreateSeedDto newSeed)
        {
            if (await SeedExist(newSeed.Type) == false)
            {
                var seed = new Seed()
                {
                    Id = Guid.NewGuid(),
                    ImageUrl = newSeed.ImageUrl,
                    Type = newSeed.Type,
                };
                if (seed != null)
                {
                    await _ctx.SaveChangesAsync();
                }
                return seed;
            }
            return null;
        }

        public async Task<bool> DeleteSeed(Guid id)
        {
            var seedToDelete = await _ctx.Seeds.FindAsync(id);
            if (seedToDelete != null)
            {
                _ctx.Seeds.Remove(seedToDelete);
                await _ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Seed> GetSeedById(Guid id)
        {
            var seedToFind = await _ctx.Seeds.FindAsync(id);
            if (seedToFind == null)
            {
                return null;
            }
            return seedToFind;
        }

        public async Task<List<Seed>> GetAllSeeds()
        {
            var listOfSeeds = await _ctx.Seeds.ToListAsync();
            if (listOfSeeds == null)
            {
                return null;
            }
            return listOfSeeds;
        }

        public async Task<Seed> UpdateSeed(Guid id, UpadateSeedDto upadedSeed)
        {
            var seedToUpdate = await _ctx.Seeds.FindAsync(id);
            if (seedToUpdate == null)
            {
                return null;
            }
            seedToUpdate.Type = upadedSeed.Type;
            seedToUpdate.ImageUrl = upadedSeed.ImageUrl;
            await _ctx.SaveChangesAsync();
            return seedToUpdate;
        }

        


    }
}
