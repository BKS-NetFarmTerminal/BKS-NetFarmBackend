using BKSFarm.api.Extentions.DtoConvertor;
using BKSFarm.api.Interfaces;
using BKSFarm.Dto.Animal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BKSFarm.api.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class AnimalController : ControllerBase
	{
		private readonly IAnimalRepository _animalRepository;
		public AnimalController(IAnimalRepository animalRepository)
		{
			_animalRepository = animalRepository;
		}
		
		[HttpGet]
		[Route("getAnimals")]
		public async Task<ActionResult<List<AnimalDto>>> GetAllAnimals()
		{
			var animals = await _animalRepository.GetAllAnimals();
			if (animals == null)
			{
				return NotFound();
			}
			else
			{
				var animalsDto = animals.ConvertToDto();
				return Ok(animalsDto);
			}
			

		}

		[HttpGet]
		[Route("getAnimal/{id:Guid}")]
		public async Task<ActionResult<AnimalDto>> GetAnimal(Guid id)
		{
			
			var animal = await _animalRepository.GetAnimalById(id);
			if (animal == null)
			{
				return NotFound();
			}
			else
			{
				var animalDto = animal.ConverToDto();
				return Ok(animalDto);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimalDto animalDto)
		{
			var newAnimal = await _animalRepository.CreateAnimal(animalDto);
			if (newAnimal == null)
			{
				return NoContent();
			}
			return Ok(newAnimal);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateManufacturer(Guid id, UpdateAnimalDto animalDto)
		{
			
			var updateAnimal = await _animalRepository.UpdateAnimal(id, animalDto);
			if (updateAnimal == null)
			{
				return NoContent();
			}
			var response = await _animalRepository.GetAnimalById(updateAnimal.Id);
			var result = response.ConverToDto();
			return Ok(result);	
		}

		[HttpDelete]
		public async Task<ActionResult<bool>> DeleteAnimal(Guid id)
		{
			
			var animal = await _animalRepository.DeleteAnimal(id);
			return animal;
			
		}
	}
}
