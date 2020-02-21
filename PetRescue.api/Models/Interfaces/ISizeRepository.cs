using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface ISizeRepository
    {
        IEnumerable<Size> GetSizes();
        Size GetSizeByID(int id);
        void InsertSize(Size size);
        void DeleteSize(int id);
        void UpdateSize(Size size);
        void Save();
        bool SizeExists(int id);
    }
}
