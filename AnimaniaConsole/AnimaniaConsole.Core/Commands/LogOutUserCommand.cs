using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Commands
{
    public class LogOutUserCommand : ICommand
    {
        private readonly IUserService userService;

        public LogOutUserCommand(IUserService userService)
        {
            this.userService = userService;
        }
        public string Execute(IList<string> parameters)
        {
            string userName = userService.GetLoggedUserName();
            userService.LogOutUser();

            return $"{userName}, logged out.";
        }
    }
}
