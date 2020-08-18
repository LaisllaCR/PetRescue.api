using PetRescue.api.Models;
using System.Collections.Generic;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IPelageRepository
    {
        IEnumerable<PelageDto> GetPelages();
        PelageDto GetPelageByID(int id);
        void InsertPelage(PelageDto hair);
        void DeletePelage(int id);
        void UpdatePelage(PelageDto hair);
        void Save();
        bool PelageExists(int id);
    }
}
