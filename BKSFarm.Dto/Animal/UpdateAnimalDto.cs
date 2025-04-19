using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKSFarm.Dto.Animal
{
	public class UpdateAnimalDto
	{
		public string Type { get; set; }
		public long DieTime { get; set; }
		public long TimeToLvlUp { get; set; }
	}
}
