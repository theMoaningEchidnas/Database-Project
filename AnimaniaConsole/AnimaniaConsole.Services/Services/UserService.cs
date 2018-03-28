using AnimaniaConsole.Data;
using AnimaniaConsole.DTO;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimaniaConsole.Services.Services
{
    public class UserService : IUserService
    {
        public UserService(IAnimaniaConsoleContext ctx, IMapper mapper)
        {
            this.Context = ctx;
            this.Mapper = mapper;
        }

        public IAnimaniaConsoleContext Context { get; }

        public IMapper Mapper { get; }

        public void RegisterUser(CreateUserModel userDTO)
        {
            var newUser = Mapper.Map<User>(userDTO);
            newUser.Status = true;
            this.Context.Users.Add(newUser);
            Context.SaveChanges();
        }

        public void LogInUser(string userName, string password, UserSessionModel userSession)
        {
            User user;
            try
            {
                user = this.Context.Users.Where(x => x.UserName == userName && x.Password == password && x.Status == true).Single();
            }
            catch (Exception)
            {
                throw new Exception("Failed to find such active user in database.");
            }
            userSession.Id = user.Id;
            userSession.UserName = user.UserName;
        }

        public void LogOutUser(UserSessionModel userSession)
        {
            userSession.Id = 0;
            userSession.UserName = null;
        }

        public void ChangePassword(UserSessionModel userSession, string newPassword)
        {
            var user = this.Context.Users.Where(x => x.Id == userSession.Id).Single();
            user.Password = newPassword;
            this.Context.SaveChanges();
        }

        public int GetLoggedUserId(UserSessionModel userSession)
        {
            if (userSession.Id == 0)
            {
                throw new ArgumentException("You are not logged in! Please, log in and try again!");
            }
            return userSession.Id;
        }

        public void DeactivateUser(int userId)
        {
            var userToBeDeactivated = this.Context.Users.SingleOrDefault(x => x.Id == userId && x.Status == true);
            if (userToBeDeactivated == null)
            {
                throw new ArgumentException("No such active user!");
            }
            userToBeDeactivated.Status = false;
            Context.SaveChanges();  


        }

    }

}

