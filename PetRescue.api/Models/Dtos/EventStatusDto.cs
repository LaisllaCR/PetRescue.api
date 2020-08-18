using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class EventStatusDto
    {
        public EventStatusDto()
        {

        }

        public int EventStatusTypeId { get; set; }
        public string Description { get; set; }
    }
}
