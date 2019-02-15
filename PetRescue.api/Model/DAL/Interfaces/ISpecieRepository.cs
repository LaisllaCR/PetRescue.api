using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface ISpecieRepository
    {
        IEnumerable<Specie> GetSpecies();
        Specie GetSpecieByID(int id);
        void InsertSpecie(Specie specie);
        void DeleteSpecie(int id);
        void UpdateSpecie(Specie specie);
        void Save();
        bool SpecieExists(int id);
    }
}
