using BKSFarm.api.Data;
using BKSFarm.api.Entities;
using BKSFarm.Dto.Seed;
using BKSFarm.Dto.Plant;

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
        public async Task<CreateSeedDto> AddSeedToUser(AddSeedToUserDto addSeed)
        {
            var user = await _dbcontext.Users.FindAsync(addSeed.UserId);
            var seed = await _dbcontext.Seeds.FindAsync (addSeed.SeedId);

            if (seed == null || user == null)
            {
                Results.NotFound("Пользователя с таким Id нет");
                return null;
            }
            var UserSeed = new UserSeed() 
            { 
                User = user,
                UserId = user.UserId,
                Seed = seed,
                SeedId = seed.SeedId,
                UserSeedId = Guid.NewGuid(),
            };
            await _dbcontext.UserSeeds.AddAsync(UserSeed);
            await _dbcontext.SaveChangesAsync();
            return  new CreateSeedDto()
            {
                Name = seed.SeedName,
                ImageUrl = seed.SeedImageUrl,
            };
        }
        public async Task<ShowPlantDto> PlantSeed(CreatePlantDto createPlant)
        {
            var user = await _dbcontext.Users.FindAsync (createPlant.UserId);
            if (user == null)
            {
                Results.NotFound("Пользователя с таким Id нет");
                return null;
            }
            long nowUnix = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            var newPlant = new Plant()
            {
                PlantId = Guid.NewGuid(),
                PlantName = createPlant.PlantName,
                PlantImageUrl = createPlant.PlantImageUrl,
                PlantStage = 0,
                DateCreate = nowUnix,
                DieTime = nowUnix + (4 * 60 * 60), 
                TimeToLvlUp = nowUnix + (1 * 60 * 60),
                PlanType = createPlant.PlantType,
                User = user,
                UserId = user.UserId
            };
            await _dbcontext.Plants.AddAsync(newPlant);
            await _dbcontext.SaveChangesAsync();
            return new ShowPlantDto()
            {
                PlantName = newPlant.PlantName,
                PlantImageUrl = newPlant.PlantImageUrl,
                DateCreate = newPlant.DateCreate,
                DieTime = newPlant.DieTime,
                TimeToLvlUp = newPlant.TimeToLvlUp,
                PlantStage = 0
            };
        }
    }
}
