using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IUserService
    {
         void RegisterUser(string username, string firstname, string lastname, string password, string email, string additionalInfo);
    }
}
