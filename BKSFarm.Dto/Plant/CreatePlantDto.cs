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

        public string PlantName { get; set; }

        public string PlantImageUrl { get; set; }

        public string PlantType { get; set; }   

        public Guid UserId { get; set; }

    }
}
