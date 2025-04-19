using BKSFarm.Dto.Plant;
using BKSFarm.Dto.Seed;

namespace BKSFarm.api.Interfaces
{
    public interface ISeedRepository
    {
        public Task<CreateSeedDto> CreateSeed(CreateSeedDto newSeed);

        public Task<CreateSeedDto> AddSeedToUser(AddSeedToUserDto addSeed);

        public Task<ShowPlantDto> PlantSeed(CreatePlantDto createPlant);
        public Task<List<ShowUserSeedsDto>> ShowAllUserSeeds(Guid userId);
    }
}
