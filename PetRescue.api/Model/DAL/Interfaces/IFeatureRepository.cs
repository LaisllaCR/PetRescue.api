using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Interfaces
{
    public interface IFeatureRepository
    {
        IEnumerable<Feature> GetFeatures();
        Feature GetFeatureByID(int id);
        void InsertFeature(Feature feature);
        void DeleteFeature(int id);
        void UpdateFeature(Feature feature);
        void Save();
        bool FeatureExists(int id);
    }
}
