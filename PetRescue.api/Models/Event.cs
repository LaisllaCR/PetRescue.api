using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public int PetId { get; set; }
        public DateTime When { get; set; }
        public string What { get; set; }
        public string Where { get; set; }
        public bool Reward { get; set; }
        public DateTime CreationDate { get; set; }
        public int EventTypeId { get; set; }
        public int LocationTypeId { get; set; }
        public int EventStatusId { get; set; }

        public virtual EventStatus EventStatus { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual LocationType LocationType { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
