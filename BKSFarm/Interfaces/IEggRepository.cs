using BKSFarm.api.Entities;
using BKSFarm.Dto.Egg;
using BKSFarm.Dto.Seed;

namespace BKSFarm.api.Interfaces
{
    public interface IEggRepository
    {
        public Task<Egg> CreateEgg(CreateEggDto newEgg);

        public Task<Egg> UpdateEgg(Guid id, UpdateEggDto upadedEgg);

        public Task<bool> DeleteEgg(Guid id);

        public Task<Egg> GetEGgById(Guid id);

        public Task<List<Egg>> GetAllEggs();
    }
}
