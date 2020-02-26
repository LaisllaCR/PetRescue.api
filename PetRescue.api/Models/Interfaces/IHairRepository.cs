using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IHairRepository
    {
        IEnumerable<HairResource> GetHairs();
        HairResource GetHairByID(int id);
        void InsertHair(HairResource hair);
        void DeleteHair(int id);
        void UpdateHair(HairResource hair);
        void Save();
        bool HairExists(int id);
    }
}
