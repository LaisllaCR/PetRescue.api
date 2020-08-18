using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class LocationTypeDto
    {
        public LocationTypeDto()
        {

        }
        public int LocationTypeId { get; set; }
        public string Description { get; set; }
    }
}
