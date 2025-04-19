using BKSFarm.api.Data;
using BKSFarm.api.Interfaces;
using BKSFarm.Dto.Plant;
using BKSFarm.Dto.Seed;
using Microsoft.EntityFrameworkCore;

namespace BKSFarm.api.Repository
{
    public class PlantRepository : IPlantRepository
    {
        private readonly DataContext _dbContext;
        public PlantRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public async Task<ShowPlantDto> WaterPlant(Guid PlantId)
        //{
        //    var userPlant = await _dbContext.Plants.FindAsync(PlantId);
        //    if (userPlant == null)
        //    {
        //        Results.NotFound("Пользователя с таким Id нет");
        //        return null;
        //    }
        //    userPlant.PlantStage += 1;
        //    long nowUnix = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        //    userPlant.DieTime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds() + (4 * 60 * 60);
        //    await _dbContext.SaveChangesAsync();
        //    return new ShowPlantDto()
        //    {
        //        PlantName = userPlant.PlantName,
        //        PlantType = userPlant.PlanType,
        //        PlantImageUrl = userPlant.PlantImageUrl,
        //        PlantStage = userPlant.PlantStage,
        //        DateCreate = userPlant.DateCreate,
        //        DieTime = userPlant.DieTime,
        //        TimeToLvlUp = userPlant.TimeToLvlUp,
        //    };

        //}
        //public async Task<List<ShowPlantDto>> ShowUserPlants(Guid userId)
        //{
        //    var user = await _dbContext.Users
        //           .Include(u => u.Plants)
        //           .FirstOrDefaultAsync(u => u.UserId == userId);

        //    if (user == null)
        //    {
        //        return new List<ShowPlantDto>();
        //    }


        //    var plantList = new List<ShowPlantDto>();


        //    if (user.Plants != null)
        //    {
        //        plantList = user.Plants.Select(p => new ShowPlantDto()
        //        {
        //            PlantName = p.PlantName,
        //            PlantImageUrl = p.PlantImageUrl,
        //            PlantStage = p.PlantStage,
        //            DateCreate = p.DateCreate,
        //            DieTime = p.DieTime,
        //            TimeToLvlUp = p.TimeToLvlUp,
        //            PlantType = p.PlanType
        //        }).ToList();
        //    }

        //    return plantList;

        //}
        
    }
}
