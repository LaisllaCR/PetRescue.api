using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IColorRepository
    {
        IEnumerable<Color> GetColors();
        Color GetColorByID(int id);
        void InsertColor(Color color);
        void DeleteColor(int id);
        void UpdateColor(Color color);
        void Save();
        bool ColorExists(int id);
    }
}
