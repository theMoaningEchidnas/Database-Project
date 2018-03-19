using AnimaniaConsole.DTO;
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
    }
}
