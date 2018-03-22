using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Services.Services
{
    public class SessionService : ISessionService
    {
        public bool ValidateUser(UserSessionModel userSession)
        {
            if (userSession.Id == 0 || userSession.UserName == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
