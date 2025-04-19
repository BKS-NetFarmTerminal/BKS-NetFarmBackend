using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKSFarm.Dto.Plant
{
    public class ShowPlantDto
    {
        public string PlantName { get; set; }

        public string PlantImageUrl { get; set; }

        public int PlantStage { get; set; }

        public string PlantType { get; set; }

        public long DateCreate { get; set; }

        public long DieTime { get; set; }

        public long TimeToLvlUp { get; set; }

    }
}
