using BKSFarm.api.Data;
using BKSFarm.api.Entities;
using BKSFarm.Dto.Seed;
using Microsoft.EntityFrameworkCore;

namespace BKSFarm.api.Repository
{
    public class SeedRepository
    {
        private readonly DataContext _dbcontext;
        public SeedRepository(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<CreateSeedDto> CreateSeed(CreateSeedDto newSeed)
        {
            Seed seed = new Seed()
            {
                SeedId = Guid.NewGuid(),
                SeedName = newSeed.Name,
                SeedImageUrl = newSeed.ImageUrl,
            };
            await _dbcontext.Seeds.AddAsync(seed);
            await _dbcontext.SaveChangesAsync();
            return newSeed;

        }
    }
}
