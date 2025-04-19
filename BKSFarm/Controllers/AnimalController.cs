using BKSFarm.api.Extentions.DtoConvertor;
using BKSFarm.api.Interfaces;
using BKSFarm.Dto.Animal;
using Microsoft.AspNetCore.Mvc;

namespace BKSFarm.api.Controllers
{
	[Route("api/[controller]")]
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
		public async Task<ActionResult<List<AnimalDto>>> GetAnimals()
		{
			try
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
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Ошибка получения данных из базы данных");
			}

		}
	}
}
