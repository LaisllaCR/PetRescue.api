using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IHairRepository
    {
        IEnumerable<Hair> GetHairs();
        Hair GetHairByID(int id);
        void InsertHair(Hair hair);
        void DeleteHair(int id);
        void UpdateHair(Hair hair);
        void Save();
        bool HairExists(int id);
    }
}
