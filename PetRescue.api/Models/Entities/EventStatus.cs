using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class EventStatus
    {
        public EventStatus()
        {
            Event = new HashSet<Event>();
        }

        public int EventStatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
