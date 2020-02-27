using Microsoft.AspNetCore.Mvc;
using PetRescue.api.Model;
using PetRescue.api.Model.DAL.UnitOfWork;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;

namespace PetRescue.api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public UnitOfWork UnitOfWork { get; private set; }

        public BaseController()
        {
            UnitOfWork = new UnitOfWork(new dbContext());
        }
    }
}
