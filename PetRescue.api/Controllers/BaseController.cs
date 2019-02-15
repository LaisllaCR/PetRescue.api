using Microsoft.AspNetCore.Mvc;
using PetRescue.api.Model;
using PetRescue.api.Model.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
