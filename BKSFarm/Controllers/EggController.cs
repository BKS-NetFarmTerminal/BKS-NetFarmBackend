using BKSFarm.api.Extentions.DtoConvertor;
using BKSFarm.api.Interfaces;
using BKSFarm.Dto.Egg;
using Microsoft.AspNetCore.Mvc;

namespace BKSFarm.api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EggController : ControllerBase
	{
		private readonly IEggRepository _eggRepository;
		public EggController(IEggRepository eggRepository)
		{
			_eggRepository = eggRepository;
		}

		[HttpGet]
		[Route("getEggs")]
		public async Task<ActionResult<List<EggDto>>> GetAllEggs()
		{
			var eggs = await _eggRepository.GetAllEggs();
			if (eggs == null)
			{
				return NotFound();
			}
			return Ok(eggs.ConvertToDto());
		}

		[HttpGet]
		[Route("getEgg/{id:Guid}")]
		public async Task<ActionResult<EggDto>> GetEgg(Guid id)
		{
			var egg = await _eggRepository.GetEGgById(id);
			if (egg == null)
			{
				return NotFound();
			}
			var eggDto = egg.ConverToDto();
			return Ok(eggDto);
		}

		[HttpPost]
		public async Task<IActionResult> CreateEgg([FromBody] CreateEggDto createDto)
		{
			var newEgg = await _eggRepository.CreateEgg(createDto);
			if (newEgg == null)
			{
				return NoContent();
			}
			var eggDto = newEgg.ConverToDto();
			return Ok(eggDto);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateEgg(Guid id, UpdateEggDto eggDto)
		{
			var updatedEgg = await _eggRepository.UpdateEgg(id, eggDto);
			if (updatedEgg == null)
			{
				return NoContent();
			}
			var response = await _eggRepository.GetEGgById(updatedEgg.Id);
			var result = response.ConverToDto();
			return Ok(result);
		}

		[HttpDelete]
		public async Task<ActionResult<bool>> DeleteEgg(Guid id)
		{
			var result = await _eggRepository.DeleteEgg(id);
			return result;
		}
	}

}
