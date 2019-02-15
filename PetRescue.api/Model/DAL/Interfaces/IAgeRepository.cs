using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IAgeRepository
    {
        IEnumerable<Age> GetAges();
        Age GetAgeByID(int id);
        void InsertAge(Age age);
        void DeleteAge(int id);
        void UpdateAge(Age age);
        void Save();
        bool AgeExists(int id);
    }
}
