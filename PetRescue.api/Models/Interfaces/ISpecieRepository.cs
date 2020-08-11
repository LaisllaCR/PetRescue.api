using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface ISpecieRepository
    {
        IEnumerable<SpecieDto> GetSpecies();
        SpecieDto GetSpecieByID(int id);
        void InsertSpecie(SpecieDto specie);
        void DeleteSpecie(int id);
        void UpdateSpecie(SpecieDto specie);
        void Save();
        bool SpecieExists(int id);
    }
}
