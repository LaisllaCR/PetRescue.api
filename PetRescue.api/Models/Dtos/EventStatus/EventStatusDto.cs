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

        public EventStatusDto(EventStatus eventStatus)
        {
            EventStatusTypeId = eventStatus.EventStatusTypeId;
            Description = eventStatus.Description;
        }

        public int EventStatusTypeId { get; set; }
        public string Description { get; set; }
    }
}
