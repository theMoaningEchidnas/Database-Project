using AnimaniaConsole.DTO;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using System.Collections.Generic;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IUserService
    {
        void RegisterUser(CreateUserModel user);
        void ChangePassword(string newPassword);
        void LogInUser(string userName, string password);
        void LogOutUser();
        int GetLoggedUserId();
        void DeactivateUser(int userId);
        string GetLoggedUserName();
        bool ValidateUser();
    }
}
