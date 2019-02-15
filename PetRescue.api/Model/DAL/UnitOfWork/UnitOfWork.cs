using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Model.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly dbContext context;

        public UnitOfWork(dbContext _context)
        {
            context = _context;

            Specie = new SpecieRepository(context);
            Breed = new BreedRepository(context);
            Age = new AgeRepository(context);
            Hair = new HairRepository(context);
            Feature = new FeatureRepository(context);
            Size = new SizeRepository(context);
            Color = new ColorRepository(context);
        }
        
        #region PUBLIC

        public ISpecieRepository Specie { get; set; }
        public IBreedRepository Breed { get; set; }
        public IAgeRepository Age { get; set; }
        public IHairRepository Hair { get; set; }
        public IFeatureRepository Feature { get; set; }
        public ISizeRepository Size { get; set; }
        public IColorRepository Color { get; set; }

        #endregion
    }
}
