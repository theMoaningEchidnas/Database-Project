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
    public class LogInUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly ISessionService sessionService;
        private readonly UserSessionModel session;

        public LogInUserCommand(IUserService userService, ISessionService sessionService, UserSessionModel session)
        {
            this.userService = userService;
            this.sessionService = sessionService;
            this.session = session;
        }
        public string Execute(IList<string> parameters)
        {
            string username = parameters[1];
            string password = parameters[2];

            if (sessionService.ValidateUser(session))
            {
                throw new Exception("There is a logged in user!");
            }
            else
            {
                userService.LogInUser(username, password, session);
            }
            return "User logged in successfully.";
        }
    }
}
