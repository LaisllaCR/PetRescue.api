using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IShelterRepository
    {
        IEnumerable<ShelterDto> GetShelters();
        ShelterDto GetShelterByID(int id);
        void InsertShelter(ShelterDto shelter);
        void DeleteShelter(int id);
        void UpdateShelter(ShelterDto shelter);
        void Save();
        bool ShelterExists(int id);
    }
}
