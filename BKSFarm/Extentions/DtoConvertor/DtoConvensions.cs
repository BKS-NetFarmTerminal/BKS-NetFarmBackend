using BKSFarm.api.Entities;
using BKSFarm.Dto.Animal;
using BKSFarm.Dto.Egg;
using BKSFarm.Dto.Plant;
using BKSFarm.Dto.Seed;

namespace BKSFarm.api.Extentions.DtoConvertor
{
    public static class DtoConvensions
	{
		public static List<AnimalDto> ConvertToDto(this List<Animal> animals)
		{
			return (from animal in animals
					select new AnimalDto
					{
						Id = animal.Id,
						Type = animal.Type,
						DieTime = animal.DieTime,
						TimeToLvlUp = animal.TimeToLvlUp,
					}).ToList();
		}

		public static AnimalDto ConverToDto(this Animal animal)
		{
			return new AnimalDto
			{
				Id = animal.Id,
				Type = animal.Type,
				DieTime = animal.DieTime,
				TimeToLvlUp = animal.TimeToLvlUp,
			};
		}
		//-------------------------------------------------------------------------------
		public static List<PlantDto> ConvertToDto(this List<Plant> plants)
		{
			return (from plant in plants
					select new PlantDto
					{
						Id = plant.Id,
						Type = plant.Type,
						DieTime = plant.DieTime,
						TimeToLvlUp = plant.TimeToLvlUp,
					}).ToList();
		}

		public static PlantDto ConverToDto(this Plant plant)
		{
			return new PlantDto
			{
				Id = plant.Id,
				Type = plant.Type,
				DieTime = plant.DieTime,
				TimeToLvlUp = plant.TimeToLvlUp,
			};
		}

		//-------------------------------------------------------------------------------------------

		public static List<SeedDto> ConvertToDto(this List<Seed> seeds)
		{
			return (from seed in seeds
					select new SeedDto
					{
						Id = seed.Id,
						Type = seed.Type,
						ImageUrl = seed.ImageUrl
					}).ToList();
		}

		public static SeedDto ConverToDto(this Seed seed)
		{
			return new SeedDto
			{
				Id = seed.Id,
				Type = seed.Type,
				ImageUrl = seed.ImageUrl
			};
		}

		//-------------------------------------------------------------------------------------------

		public static List<EggDto> ConvertToDto(this List<Egg> eggs)
		{
			return (from egg in eggs
					select new EggDto
					{
						Id = egg.Id,
						Type = egg.Type,
						ImageUrl = egg.ImageUrl,
					}).ToList();
		}

		public static EggDto ConverToDto(this Egg egg)
		{
			return new EggDto
			{
				Id = egg.Id,
				Type = egg.Type,
				ImageUrl = egg.ImageUrl,
			};
		}

		//-------------------------------------------------------------------------------------------
	}
}
