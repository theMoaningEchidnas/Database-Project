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
        private readonly IUserServices userService;

        public LogOutUserCommand(IUserServices userService)
        {
            this.userService = userService ?? throw new ArgumentNullException();
        }
        public string Execute(IList<string> parameters)
        {
            string userName = userService.GetLoggedUserName();
            userService.LogOutUser();

            return $"{userName}, logged out.";
        }
    }
}
