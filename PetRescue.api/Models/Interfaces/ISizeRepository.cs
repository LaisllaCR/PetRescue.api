using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface ISizeRepository
    {
        IEnumerable<SizeResource> GetSizes();
        SizeResource GetSizeByID(int id);
        void InsertSize(SizeResource size);
        void DeleteSize(int id);
        void UpdateSize(SizeResource size);
        void Save();
        bool SizeExists(int id);
    }
}
