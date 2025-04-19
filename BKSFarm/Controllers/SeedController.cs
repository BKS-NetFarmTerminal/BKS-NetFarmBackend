using BKSFarm.api.Extentions.DtoConvertor;
using BKSFarm.api.Interfaces;
using BKSFarm.Dto.Seed;
using Microsoft.AspNetCore.Mvc;

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

		[HttpGet]
		[Route("getSeeds")]
		public async Task<ActionResult<List<SeedDto>>> GetAllSeeds()
		{
			var seeds = await _seedRepository.GetAllSeeds();
			if (seeds == null)
			{
				return NotFound();
			}
			var seedDto = seeds.ConvertToDto();
			return Ok(seedDto);
		}

		[HttpGet]
		[Route("getSeed/{id:Guid}")]
		public async Task<ActionResult<SeedDto>> GetSeed(Guid id)
		{
			var seed = await _seedRepository.GetSeedById(id);
			if (seed == null)
			{
				return NotFound();
			}
			var seedDto = seed.ConverToDto();
			return Ok(seedDto);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSeed([FromBody] CreateSeedDto seedDto)
		{
			var newSeed = await _seedRepository.CreateSeed(seedDto);
			if (newSeed == null)
			{
				return NoContent();
			}
			var newSeedDto = newSeed.ConverToDto(); 
			return Ok(newSeedDto);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSeed(Guid id, UpadateSeedDto seedDto)
		{
			var updatedSeed = await _seedRepository.UpdateSeed(id, seedDto);
			if (updatedSeed == null)
			{
				return NoContent();
			}
			var response = await _seedRepository.GetSeedById(updatedSeed.Id);
			var result = response.ConverToDto();
			return Ok(result);
		}

		[HttpDelete]
		public async Task<ActionResult<bool>> DeleteSeed(Guid id)
		{
			var result = await _seedRepository.DeleteSeed(id);
			return result;
		}
	}
}
