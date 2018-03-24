using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class ChangePasswordCommand : ICommand
    {

        public ChangePasswordCommand(IUserService userService, ISessionService sessionService, UserSessionModel session)
        {
            this.UserService = userService;
            this.SessionService = sessionService;
            this.Session = session;
        }

        public IUserService UserService { get; }
        public ISessionService SessionService { get; }
        public UserSessionModel Session { get; }

        public string Execute(IList<string> parameters)
        {
            var result = SessionService.ValidateUser(this.Session);
            if (result == true)
            {
                var password = parameters[1];
                UserService.ChangePassword(this.Session, password);
                return "Password changed!"; ;
            }
            else
            {
                return "Please Log in first!";
            }

        }
    }
}
