using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IBreedRepository
    {
        IEnumerable<BreedDto> GetBreeds();
        BreedDto GetBreedByID(int id);
        void InsertBreed(BreedDto breed);
        void DeleteBreed(int id);
        void UpdateBreed(BreedDto breed);
        void Save();
        bool BreedExists(int id);
    }
}
