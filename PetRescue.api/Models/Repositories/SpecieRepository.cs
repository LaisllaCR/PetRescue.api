﻿using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class SpecieRepository : Repository<Specie>, ISpecieRepository
    {
        public SpecieRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteSpecie(int id)
        {
            Specie specie = dbContext.Specie.Find(id);
            dbContext.Specie.Remove(specie);
        }

        public SpecieResource GetSpecieByID(int id)
        {
            return new SpecieResource(dbContext.Specie.Find(id));
        }

        public IEnumerable<SpecieResource> GetSpecies()
        {
            return (from specie in dbContext.Specie select new SpecieResource(specie)).ToList();
        }

        public void InsertSpecie(SpecieResource resource)
        {
            Specie specie = new Specie();
            specie.SpecieId = resource.SpecieId;
            specie.Description = resource.Description;

            dbContext.Specie.Add(specie);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public bool SpecieExists(int id)
        {
            return dbContext.Specie.Any(e => e.SpecieId == id);
        }

        public void UpdateSpecie(SpecieResource resource)
        {
            Specie specie = dbContext.Specie.Find(resource.SpecieId);

            dbContext.Entry(specie).State = EntityState.Modified;

            specie.Description = resource.Description;
        }
    }
}