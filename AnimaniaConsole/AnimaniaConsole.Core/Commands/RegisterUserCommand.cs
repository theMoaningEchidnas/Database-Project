using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public RegisterUserCommand(IUserService service)
        {
            this.Service = service;
        }

        public IUserService Service { get; }


        //RegisterUser;Buser;Bpassword123;Kremvirsh;Boni;obichame.kremvirshi@meso.edu;;;
        public string Execute(IList<string> parameters)
        {
            string message = null;
            CreateUserModel UserToRegister = new CreateUserModel
            {
                UserName = parameters[1],
                Password = parameters[2],
                FirstName = parameters[3],
                LastName = parameters[4],
                Email = parameters[5],
                Tel=parameters[6],
                Facebook=parameters[7],
                Skype=parameters[8]
            };
            Service.RegisterUser(UserToRegister);

            return message = $"WELCOME: | {UserToRegister.UserName} | Enjoy your Account : )";

        }
    }
}
