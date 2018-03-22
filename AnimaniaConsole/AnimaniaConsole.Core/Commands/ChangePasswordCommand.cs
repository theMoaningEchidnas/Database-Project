using AnimaniaConsole.Core.Commands.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Commands
{
    public class ChangePasswordCommand : ICommand
    {

        public ChangePasswordCommand(IUserService userService,ISessionService sessionService,UserSessionModel session)
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
            string message = null;
            var result=SessionService.ValidateUser(this.Session);
            if (result==true)
            {
                var password = parameters[1];
                UserService.ChangePassword(this.Session, password);
                return message = "Password changed!";
            }
            else
            {
                return message = "Please Log in first!";
            }
     
        }
    }
}
