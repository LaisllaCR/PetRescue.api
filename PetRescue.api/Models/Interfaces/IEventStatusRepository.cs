using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IEventStatusRepository
    {
        IEnumerable<EventStatusResource> GetEventStatuss();
        EventStatusResource GetEventStatusByID(int id);
        void InsertEventStatus(EventStatusResource eventStatus);
        void DeleteEventStatus(int id);
        void UpdateEventStatus(EventStatusResource eventStatus);
        void Save();
        bool EventStatusExists(int id);
    }
}