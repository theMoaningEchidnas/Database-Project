using AnimaniaConsole.DTO;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IUserService
    {
         void RegisterUser(CreateUserModel user);
        void ChangePassword(UserSessionModel userSession, string newPassword);
        void LogInUser(string userName, string password, UserSessionModel userSession);
        void LogOutUser(UserSessionModel userSession);
        IList<Post> GetAllPosts(UserSessionModel userSession);
    }
}
