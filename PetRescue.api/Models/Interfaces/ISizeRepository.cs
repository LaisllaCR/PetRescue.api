using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface ISizeRepository
    {
        IEnumerable<SizeDto> GetSizes();
        SizeDto GetSizeByID(int id);
        void InsertSize(SizeDto size);
        void DeleteSize(int id);
        void UpdateSize(SizeDto size);
        void Save();
        bool SizeExists(int id);
    }
}
