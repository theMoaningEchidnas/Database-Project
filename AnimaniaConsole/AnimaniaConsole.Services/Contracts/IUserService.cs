using AnimaniaConsole.DTO;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using System.Collections.Generic;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IUserService
    {
        void RegisterUser(CreateUserModel user);
        void ChangePassword(UserSessionModel userSession, string newPassword);
        void LogInUser(string userName, string password, UserSessionModel userSession);
        void LogOutUser(UserSessionModel userSession);
        IList<Post> GetAllPosts(UserSessionModel userSession);
        int GetLoggedUserId(UserSessionModel userSession);
    }
}
