using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKSFarm.Dto.Seed
{
    public class AddSeedToUserDto
    {
        public Guid SeedId { get; set; }
        public Guid UserId { get; set; }
    }
}
