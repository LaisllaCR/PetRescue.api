using PetRescue.api.Models.Resources.AppClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IAppClientRepository
    {
        TokenResource Authenticate(AppClientResource resource);
    }
}
