using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IColorRepository
    {
        IEnumerable<ColorResource> GetColors();
        ColorResource GetColorByID(int id);
        void InsertColor(ColorResource color);
        void DeleteColor(int id);
        void UpdateColor(ColorResource color);
        void Save();
        bool ColorExists(int id);
    }
}
