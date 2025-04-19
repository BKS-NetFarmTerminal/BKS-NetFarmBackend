using BKSFarm.api.Entities;
using BKSFarm.Dto.Plant;
using BKSFarm.Dto.Seed;

namespace BKSFarm.api.Interfaces
{
    public interface ISeedRepository
    {
        public Task<Seed> CreateSeed(CreateSeedDto newSeed);

        public Task<Seed> UpdateSeed(Guid id , UpadateSeedDto upadedSeed);

        public Task<bool> DeleteSeed(Guid id);

        public Task<Seed> GetSeedById(Guid id);

        public Task<List<Seed>> GetAllSeeds();
    }
}
