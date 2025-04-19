using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKSFarm.Dto.Plant
{
	public class PlantDto
	{
		public Guid Id { get; set; }
		public string Type { get; set; }
		public long DieTime { get; set; }
		public long TimeToLvlUp { get; set; }
	}
}
