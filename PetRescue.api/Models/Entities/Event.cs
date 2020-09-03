using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public int PetId { get; set; }
        public int EventTypeId { get; set; }
        public int LocationTypeId { get; set; }
        public int EventStatusId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool Reward { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual EventStatus EventStatus { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual LocationType LocationType { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
