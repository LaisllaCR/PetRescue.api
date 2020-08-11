using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface ILocationTypeRepository
    {
        IEnumerable<LocationTypeDto> GetLocationTypes();
        LocationTypeDto GetLocationTypeByID(int id);
        void InsertLocationType(LocationTypeDto locationType);
        void DeleteLocationType(int id);
        void UpdateLocationType(LocationTypeDto locationType);
        void Save();
        bool LocationTypeExists(int id);
    }
}
