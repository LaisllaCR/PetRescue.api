using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class EventDto
    {
        public EventDto()
        {
                
        }

        public EventDto(Event eventEntity)
        {
            EventId = eventEntity.EventId;
            PetId = eventEntity.PetId;
            When = eventEntity.When;
            What = eventEntity.What;
            Where = eventEntity.Where;
            Reward = eventEntity.Reward;
            CreationDate = eventEntity.CreationDate;
            EventTypeId = eventEntity.EventTypeId;
            LocationTypeId = eventEntity.LocationTypeId;
            EventStatusId = eventEntity.EventStatusId;
        }

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
    }
}
