﻿using AnimaniaConsole.Data;
using AnimaniaConsole.DTO;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AutoMapper;
using System;
using System.Linq;
using AnimaniaConsole.DTO.Contracts;

namespace AnimaniaConsole.Services.Services
{
    public class UserServices : IUserServices
    {
        public UserServices(IAnimaniaConsoleContext ctx, IMapper mapper, IUserSessionModel session)
        {
            this.Session = session;
            this.Context = ctx;
            this.Mapper = mapper;
        }

        public IUserSessionModel Session { get; }
        public IAnimaniaConsoleContext Context { get; }
        public IMapper Mapper { get; }

        public void RegisterUser(CreateUserModel userDTO)
        {
            var newUser = Mapper.Map<User>(userDTO);
            newUser.Status = true;
            this.Context.Users.Add(newUser);
            Context.SaveChanges();
        }

        public void LogInUser(string userName, string password)
        {
            var user = this.Context.Users.SingleOrDefault(x => x.UserName == userName && x.Password == password && x.Status == true);
            if (user == null)
            {
                throw new ArgumentException("Failed to find such active user in database.");
            }
            
            Session.Id = user.Id;
            Session.UserName = user.UserName;
        }
        public bool ValidateUser()
        {
            if (Session.Id == 0 || Session.UserName == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void LogOutUser()
        {
            Session.Id = 0;
            Session.UserName = null;
        }

        public void ChangePassword(string newPassword)
        {
            var user = this.Context.Users.SingleOrDefault(x => x.Id == Session.Id);

            user.Password = newPassword;
            this.Context.SaveChanges();
        }

        public int GetLoggedUserId()
        {
            if (Session.Id == 0)
            {
                throw new ArgumentException("You are not logged in! Please, log in and try again!");
            }
            return Session.Id;
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

        public string GetLoggedUserName()
        {
            if (Session.Id == 0)
            {
                throw new ArgumentException("You are not logged in! Please, log in and try again!");
            }
            return Session.UserName;
        }
    }

}

