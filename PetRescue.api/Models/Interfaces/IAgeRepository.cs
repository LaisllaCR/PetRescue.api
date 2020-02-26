using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IAgeRepository
    {
        IEnumerable<AgeResource> GetAges();
        AgeResource GetAgeByID(int id);
        void InsertAge(AgeResource age);
        void DeleteAge(int id);
        void UpdateAge(AgeResource age);
        void Save();
        bool AgeExists(int id);
    }
}
