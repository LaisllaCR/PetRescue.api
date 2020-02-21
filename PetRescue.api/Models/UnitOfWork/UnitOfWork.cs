using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region PRIVATE

        private readonly dbContext context;

        #endregion

        #region Constructors
        public UnitOfWork(dbContext _context)
        {
            context = _context;

            Specie = new SpecieRepository(context);
            Breed = new BreedRepository(context);
            Age = new AgeRepository(context);
            Hair = new HairRepository(context);
            Size = new SizeRepository(context);
            Color = new ColorRepository(context);
        }
        #endregion

        #region PUBLIC

        public ISpecieRepository Specie { get; set; }
        public IBreedRepository Breed { get; set; }
        public IAgeRepository Age { get; set; }
        public IHairRepository Hair { get; set; }
        public ISizeRepository Size { get; set; }
        public IColorRepository Color { get; set; }

        #endregion
    }
}
