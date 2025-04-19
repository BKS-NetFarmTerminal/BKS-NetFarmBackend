using BKSFarm.api.Entities;
using BKSFarm.Dto.Egg;
using BKSFarm.Dto.Seed;

namespace BKSFarm.api.Interfaces
{
    public interface IEggRepository
    {
        public Task<Egg> CreateSeed(CreateEggDto newEgg);

        public Task<Egg> UpdateSeed(Guid id, UpdateEggDto upadedEgg);

        public Task<bool> DeleteSeed(Guid id);

        public Task<Egg> GetSeedById(Guid id);

        public Task<List<Egg>> GetAllSeeds();
    }
}
