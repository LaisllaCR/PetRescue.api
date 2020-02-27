using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;
using PetRescue.api.Models.Repositories;
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
            SocialMidia = new SocialMidiaRepository(context);
            Shelter = new ShelterRepository(context); 
            ShelterPet = new ShelterPetRepository(context);
            PetPhoto = new PetPhotoRepository(context);
            PetColor = new PetColorRepository(context);
            PetCharacteristic = new PetCharacteristicRepository(context);
            Pet = new PetRepository(context);
            LocationType = new LocationTypeRepository(context);
            EventType = new EventTypeRepository(context);
            EventStatus = new EventStatusRepository(context);
            Event = new EventRepository(context);
            ContactSocialMidia = new ContactSocialMidiaRepository(context);
            Contact = new ContactRepository(context);
            Characteristic = new CharacteristicRepository(context);
        }
        #endregion

        #region PUBLIC

        public ISpecieRepository Specie { get; set; }
        public IBreedRepository Breed { get; set; }
        public IAgeRepository Age { get; set; }
        public IHairRepository Hair { get; set; }
        public ISizeRepository Size { get; set; }
        public IColorRepository Color { get; set; }
        public ISocialMidiaRepository SocialMidia { get; set; }
        public IShelterRepository Shelter { get; set; }
        public IShelterPetRepository ShelterPet { get; set; }
        public IPetPhotoRepository PetPhoto { get; set; }
        public IPetColorRepository PetColor { get; set; }
        public IPetCharacteristicRepository PetCharacteristic { get; set; }
        public IPetRepository Pet { get; set; }
        public ILocationTypeRepository LocationType { get; set; }
        public IEventTypeRepository EventType { get; set; }
        public IEventStatusRepository EventStatus { get; set; }
        public IEventRepository Event { get; set; }
        public IContactSocialMidiaRepository ContactSocialMidia { get; set; }
        public IContactRepository Contact { get; set; }
        public ICharacteristicRepository Characteristic { get; set; }

        #endregion
    }
}
