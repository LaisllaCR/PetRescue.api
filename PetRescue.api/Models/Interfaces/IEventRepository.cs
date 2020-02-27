using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<EventResource> GetEvents();
        EventResource GetEventByID(int id);
        void InsertEvent(EventResource resource);
        void DeleteEvent(int id);
        void UpdateEvent(EventResource resource);
        void Save();
        bool EventExists(int id);
    }
}
