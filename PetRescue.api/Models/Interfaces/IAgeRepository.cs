using PetRescue.api.Models;
using System.Collections.Generic;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IAgeRepository
    {
        IEnumerable<AgeDto> GetAges();
        AgeDto GetAgeByID(int id);
        void InsertAge(AgeDto age);
        void DeleteAge(int id);
        void UpdateAge(AgeDto age);
        void Save();
        bool AgeExists(int id);
    }
}
