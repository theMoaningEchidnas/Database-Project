using AnimaniaConsole.DTO.Models;

namespace AnimaniaConsole.Services.Contracts
{
    public interface ISessionService
    {
        bool ValidateUser(UserSessionModel userSession);
    }
}