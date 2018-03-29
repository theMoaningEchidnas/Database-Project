using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class ChangePasswordCommand : ICommand
    {

        public ChangePasswordCommand(IUserServices userService)
        {
            this.UserService = userService;
        }

        public IUserServices UserService { get; }

        public string Execute(IList<string> parameters)
        {
            var result = UserService.ValidateUser();
            if (result == true)
            {
                var newPassword = parameters[1];
                UserService.ChangePassword(newPassword);
                return "Password changed!"; ;
            }
            else
            {
                return "Please Log in first!";
            }

        }
    }
}
