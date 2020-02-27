using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class LocationType
    {
        public LocationType()
        {
            Event = new HashSet<Event>();
        }

        public int LocationTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
