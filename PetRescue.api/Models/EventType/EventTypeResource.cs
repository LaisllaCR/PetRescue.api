using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class EventTypeResource
    {
        public EventTypeResource()
        {

        }

        public EventTypeResource(EventType eventType)
        {
            EventTypeId = eventType.EventTypeId;
            Description = eventType.Description;
        }

        public int EventTypeId { get; set; }
        public string Description { get; set; }
    }
}
