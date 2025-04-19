using BKSFarm.api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BKSFarm.Dto.Seed;

namespace BKSFarm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
       private readonly IPlantRepository _pantRepository;
        public SeedController(IPlantRepository plantRepository)
        {
            _pantRepository = plantRepository;
        }
        [HttpPost]
        [Route("CreateSeed")]
        [HttpPost("create")] // or [HttpPost] if this is the only action
        public async Task<ActionResult<CreateSeedDto>> CreateSeed()
        {
            return null;
        }
    }
}
