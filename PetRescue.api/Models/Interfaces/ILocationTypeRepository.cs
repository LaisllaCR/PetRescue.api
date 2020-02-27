using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface ILocationTypeRepository
    {
        IEnumerable<LocationTypeResource> GetLocationTypes();
        LocationTypeResource GetLocationTypeByID(int id);
        void InsertLocationType(LocationTypeResource locationType);
        void DeleteLocationType(int id);
        void UpdateLocationType(LocationTypeResource locationType);
        void Save();
        bool LocationTypeExists(int id);
    }
}
