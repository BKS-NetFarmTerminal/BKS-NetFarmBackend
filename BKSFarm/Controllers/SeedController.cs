using BKSFarm.api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BKSFarm.Dto.Seed;
using BKSFarm.Dto.Plant;

namespace BKSFarm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
       private readonly ISeedRepository _seedRepository;
        public SeedController(ISeedRepository seedRepository)
        {
            _seedRepository = seedRepository;
        }
        [HttpPost("create")] 
        public async Task<ActionResult<CreateSeedDto>> CreateSeed(CreateSeedDto newSeed)
        {
            return await _seedRepository.CreateSeed(newSeed);
        }
        [HttpPost("Add")]
        public async Task<CreateSeedDto> AddSeedToUser(AddSeedToUserDto addSeed)
        {
            return await _seedRepository.AddSeedToUser(addSeed);
        }
        [HttpPost("PlantSeed")]
        public async Task<ShowPlantDto> PlantSeed(CreatePlantDto createPlant)
        {
            return await _seedRepository.PlantSeed(createPlant);
        }


    }
}
