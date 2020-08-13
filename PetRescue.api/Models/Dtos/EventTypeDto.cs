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

        public EventTypeDto(EventType eventType)
        {
            EventTypeId = eventType.EventTypeId;
            Description = eventType.Description;
        }

        public int EventTypeId { get; set; }
        public string Description { get; set; }
    }
}
