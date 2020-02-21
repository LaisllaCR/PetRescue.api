using Microsoft.AspNetCore.Mvc;
using PetRescue.api.Model;
using PetRescue.api.Model.DAL.UnitOfWork;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public UnitOfWork UnityOfWork { get; private set; }

        public BaseController()
        {
            UnityOfWork = new UnitOfWork(new dbContext());
        }
    }
}
