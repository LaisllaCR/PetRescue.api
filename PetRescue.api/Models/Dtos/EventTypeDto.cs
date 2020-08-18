using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class EventTypeDto
    {
        public EventTypeDto()
        {

        }

        public int EventTypeId { get; set; }
        public string Description { get; set; }
    }
}
