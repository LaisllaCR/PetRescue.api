using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IEventTypeRepository
    {
        IEnumerable<EventTypeDto> GetEventTypes();
        EventTypeDto GetEventTypeByID(int id);
        void InsertEventType(EventTypeDto eventType);
        void DeleteEventType(int id);
        void UpdateEventType(EventTypeDto eventType);
        void Save();
        bool EventTypeExists(int id);
    }
}
