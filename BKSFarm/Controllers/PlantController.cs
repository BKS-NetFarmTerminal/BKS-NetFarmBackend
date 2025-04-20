using BKSFarm.api.Extentions.DtoConvertor;
using BKSFarm.api.Interfaces;
using BKSFarm.Dto.Plant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BKSFarm.api.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class PlantController : ControllerBase
	{
		private readonly IPlantRepository _plantRepository;
		public PlantController(IPlantRepository plantRepository)
		{
			_plantRepository = plantRepository;
		}

		[HttpGet]
		[Route("getPlants")]
		public async Task<ActionResult<List<PlantDto>>> GetAllPlants()
		{
			var plants = await _plantRepository.GetAllPlants();
			if (plants == null)
			{
				return NotFound();
			}
			var plantDto = plants.ConvertToDto();
			return Ok(plantDto);
		}

		[HttpGet]
		[Route("getPlant/{id:Guid}")]
		public async Task<ActionResult<PlantDto>> GetPlant(Guid id)
		{
			var plant = await _plantRepository.GetPlantById(id);
			if (plant == null)
			{
				return NotFound();
			}
			var plantDto = plant.ConverToDto();
			return Ok(plantDto);
		}

		[HttpPost]
		public async Task<IActionResult> CreatePlant([FromBody] CreatePlantDto plantDto)
		{
			var newPlant = await _plantRepository.CreatePlant(plantDto);
			if (newPlant == null)
			{
				return NoContent();
			}
			var newPlantDto = newPlant.ConverToDto();
			return Ok(newPlantDto);
		}

		[HttpPut]
		public async Task<IActionResult> UpdatePlant(Guid id, UpdatePlantDto plantDto)
		{
			var updatedPlant = await _plantRepository.UpdatePlant(id, plantDto);
			if (updatedPlant == null)
			{
				return NoContent();
			}
			var response = await _plantRepository.GetPlantById(updatedPlant.Id);
			var result = response.ConverToDto();
			return Ok(result);
		}

		[HttpDelete]
		public async Task<ActionResult<bool>> DeletePlant(Guid id)
		{
			var result = await _plantRepository.DeletePlant(id);
			return result;
		}
	}
}
