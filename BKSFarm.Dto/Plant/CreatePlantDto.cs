using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKSFarm.Dto.Plant
{
    public class CreatePlantDto
    {
		public string Type { get; set; }
		public long DieTime { get; set; }
		public long TimeToLvlUp { get; set; }
	}
}
