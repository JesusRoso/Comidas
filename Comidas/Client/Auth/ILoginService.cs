using Comidas.Shared.DTO;

namespace Comidas.Client.Auth
{
    public interface ILoginService
    {
        Task Login(UserToken userToken); //recibe un toquen y lo guarda en localStorage
        Task Logout();
        Task ManejarRenovacionToken();
    }
}
