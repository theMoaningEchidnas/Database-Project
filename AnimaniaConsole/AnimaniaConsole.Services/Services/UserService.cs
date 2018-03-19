using AnimaniaConsole.Data;
using AnimaniaConsole.DTO;
using AnimaniaConsole.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace AnimaniaConsole.Services.Services
{
    public class UserService
    {
        private readonly IAnimaniaConsoleContext ctx;

        public UserService(IAnimaniaConsoleContext ctx)
        {
            this.ctx = ctx;
        }
        public IAnimaniaConsoleContext Context
        {
            get { return this.ctx; }
        }
        public void RegisterUser(string username,string firstname,string lastname,string password,string email,string additionalInfo)
        {
            var addInfoColection = additionalInfo.Split().ToList();
            var user = new User();
            user.UserName = username;
            user.FirstName = firstname;
            user.LastName = lastname;
            user.Password = password;
            user.Email = email;
            switch (addInfoColection.Count)
            {
                case 1:
                    user.Tel = addInfoColection[0];
                    break;
                case 2:
                    user.Tel = addInfoColection[0];
                    user.Facebook = addInfoColection[1];
                    break;
                case 3:
                    user.Tel = addInfoColection[0];
                    user.Facebook = addInfoColection[1];
                    user.Skype = addInfoColection[2];
                    break;
                default :
                    break;
            }
            this.Context.Users.Add(user);

        }
    }
}
