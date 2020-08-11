using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IEventStatusRepository
    {
        IEnumerable<EventStatusDto> GetEventStatuss();
        EventStatusDto GetEventStatusByID(int id);
        void InsertEventStatus(EventStatusDto eventStatus);
        void DeleteEventStatus(int id);
        void UpdateEventStatus(EventStatusDto eventStatus);
        void Save();
        bool EventStatusExists(int id);
    }
}