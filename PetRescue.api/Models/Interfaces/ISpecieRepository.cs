using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface ISpecieRepository
    {
        IEnumerable<SpecieResource> GetSpecies();
        SpecieResource GetSpecieByID(int id);
        void InsertSpecie(SpecieResource specie);
        void DeleteSpecie(int id);
        void UpdateSpecie(SpecieResource specie);
        void Save();
        bool SpecieExists(int id);
    }
}
