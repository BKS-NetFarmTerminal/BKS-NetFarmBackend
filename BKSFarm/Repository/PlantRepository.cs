using BKSFarm.api.Data;
using BKSFarm.api.Entities;
using BKSFarm.api.Interfaces;
using BKSFarm.Dto.Seed;

namespace BKSFarm.api.Repository
{
    public class PlantRepository : IPlantRepository
    {
        private readonly DataContext _dbContext;
        public PlantRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CreateAndShowSeedDto> CreateSeed(CreateAndShowSeedDto newSeed)
        {
            return null;
            UserSeed seed  = new UserSeed();
            {
                
            }
        }

    }
}
