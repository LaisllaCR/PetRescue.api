using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IEventTypeRepository
    {
        IEnumerable<EventTypeResource> GetEventTypes();
        EventTypeResource GetEventTypeByID(int id);
        void InsertEventType(EventTypeResource eventType);
        void DeleteEventType(int id);
        void UpdateEventType(EventTypeResource eventType);
        void Save();
        bool EventTypeExists(int id);
    }
}
