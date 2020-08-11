using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IHairRepository
    {
        IEnumerable<HairDto> GetHairs();
        HairDto GetHairByID(int id);
        void InsertHair(HairDto hair);
        void DeleteHair(int id);
        void UpdateHair(HairDto hair);
        void Save();
        bool HairExists(int id);
    }
}
