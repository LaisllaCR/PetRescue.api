using PetRescue.api.Models.Dtos.AppClient;

namespace PetRescue.api.Models.Interfaces
{
    public interface IAppClientRepository
    {
        TokenDto Authenticate(AppClientDto resource);
    }
}
