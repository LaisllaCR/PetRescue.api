using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        public FeatureRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteFeature(int id)
        {
            Feature specie = dbContext.Feature.Find(id);
            dbContext.Feature.Remove(specie);
        }

        public Feature GetFeatureByID(int id)
        {
            return dbContext.Feature.Find(id);
        }

        public IEnumerable<Feature> GetFeatures()
        {
            return dbContext.Feature.ToList();
        }

        public void InsertFeature(Feature specie)
        {
            dbContext.Feature.Add(specie);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public bool FeatureExists(int id)
        {
            return dbContext.Feature.Any(e => e.ID == id);
        }

        public void UpdateFeature(Feature specie)
        {
            dbContext.Entry(specie).State = EntityState.Modified;
        }
    }
}
