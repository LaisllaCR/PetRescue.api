using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Event = new HashSet<Event>();
        }

        public int EventTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
