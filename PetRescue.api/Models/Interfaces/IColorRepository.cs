using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IColorRepository
    {
        IEnumerable<ColorDto> GetColors();
        ColorDto GetColorByID(int id);
        void InsertColor(ColorDto color);
        void DeleteColor(int id);
        void UpdateColor(ColorDto color);
        void Save();
        bool ColorExists(int id);
    }
}
