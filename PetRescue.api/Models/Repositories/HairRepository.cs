﻿using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class HairRepository : Repository<Hair>, IHairRepository
    {
        public HairRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteHair(int id)
        {
            try
            {
                Hair hair = dbContext.Hair.Find(id);
                dbContext.Hair.Remove(hair);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public HairDto GetHairByID(int id)
        {
            try
            {
                return new HairDto(dbContext.Hair.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }     
        }

        public IEnumerable<HairDto> GetHairs()
        {
            try
            {
                return (from hair in dbContext.Hair select new HairDto(hair)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }    
        }

        public void InsertHair(HairDto resource)
        {
            try
            {
                Hair hair = new Hair();
                hair.HairId = resource.HairId;
                hair.Description = resource.Description;
                dbContext.Hair.Add(hair);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Save()
        {
            try
            {
                dbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                throw;
            }      
        }

        public bool HairExists(int id)
        {
            try
            {
                return dbContext.Hair.Any(e => e.HairId == id);

            }
            catch (System.Exception)
            {

                throw;
            }       
        }

        public void UpdateHair(HairDto resource)
        {
            try
            {
                Hair hair = dbContext.Hair.Find(resource.HairId);

                dbContext.Entry(hair).State = EntityState.Modified;

                hair.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
