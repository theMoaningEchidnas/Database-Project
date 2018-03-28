using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class ChangePasswordCommand : ICommand
    {

        public ChangePasswordCommand(IUserService userService)
        {
            this.UserService = userService;
        }

        public IUserService UserService { get; }

        public string Execute(IList<string> parameters)
        {
            var result = UserService.ValidateUser();
            if (result == true)
            {
                var password = parameters[1];
                UserService.ChangePassword(password);
                return "Password changed!"; ;
            }
            else
            {
                return "Please Log in first!";
            }

        }
    }
}
