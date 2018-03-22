using AnimaniaConsole.DTO;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimaniaConsole.Core.CommandContracts;

namespace AnimaniaConsole.Core.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public RegisterUserCommand(IUserService service)
        {
            this.Service = service;
        }

        public IUserService Service { get; }



        public string Execute(IList<string> parameters)
        {
            string message = null;
            CreateUserModel UserToRegister = new CreateUserModel();

            UserToRegister.UserName = parameters[1];
            UserToRegister.Password = parameters[2];
            UserToRegister.FirstName = parameters[3];
            UserToRegister.LastName = parameters[4];
            UserToRegister.Email = parameters[5];
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

                        message="Something went wrong try again!";
                    
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
