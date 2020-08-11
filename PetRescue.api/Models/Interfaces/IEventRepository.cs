using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<EventDto> GetEvents();
        EventDto GetEventByID(int id);
        void InsertEvent(EventDto resource);
        void DeleteEvent(int id);
        void UpdateEvent(EventDto resource);
        void Save();
        bool EventExists(int id);
    }
}
