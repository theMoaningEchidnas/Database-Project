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


        //RegisterUser;Buser;Bpassword123;Kremvirsh;Boni;obichame.kremvirshi@meso.edu
        public string Execute(IList<string> parameters)
        {
            string message = null;
            CreateUserModel UserToRegister = new CreateUserModel
            {
                UserName = parameters[1],
                Password = parameters[2],
                FirstName = parameters[3],
                LastName = parameters[4],
                Email = parameters[5]
            };
            switch (parameters.Count)
            {
                //No additional Info
                case 6:
                    try
                    {
                        this.Service.RegisterUser(UserToRegister);
                        message = $"User with Username:{UserToRegister.UserName} added !";

                    }
                    catch (Exception)
                    {

                        message = "Something went wrong try again!";

                    }

                    break;
                ////Just Tel
                //case 7:

                //    break;
                ////Tel and Skype
                //case 8:

                //    break;
                ////Tel,Skype and Facebook
                //case 9:
                //    break;

                default:

                    break;
            }
            return message;

        }
    }
}
