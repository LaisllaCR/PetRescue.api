using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IShelterRepository
    {
        IEnumerable<ShelterResource> GetShelters();
        ShelterResource GetShelterByID(int id);
        void InsertShelter(ShelterResource shelter);
        void DeleteShelter(int id);
        void UpdateShelter(ShelterResource shelter);
        void Save();
        bool ShelterExists(int id);
    }
}
