using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IBreedRepository
    {
        IEnumerable<Breed> GetBreeds();
        Breed GetBreedByID(int id);
        void InsertBreed(Breed breed);
        void DeleteBreed(int id);
        void UpdateBreed(Breed breed);
        void Save();
        bool BreedExists(int id);
    }
}
