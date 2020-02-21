using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IBreedRepository
    {
        IEnumerable<BreedResource> GetBreeds();
        BreedResource GetBreedByID(int id);
        void InsertBreed(BreedResource breed);
        void DeleteBreed(int id);
        void UpdateBreed(BreedResource breed);
        void Save();
        bool BreedExists(int id);
    }
}
