using AnimaniaConsole.Data;
using AnimaniaConsole.DTO;
using AnimaniaConsole.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AnimaniaConsole.Services.Contracts;
using AutoMapper;
using AnimaniaConsole.DTO.Models;

namespace AnimaniaConsole.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IAnimaniaConsoleContext ctx;
        private readonly IMapper mapper;

        public UserService(IAnimaniaConsoleContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public IAnimaniaConsoleContext Context
        {
            get { return this.ctx; }
        }
        public IMapper Mapper
        {
            get { return this.mapper; }
        }
        public void RegisterUser(CreateUserModel userDTO)
        {
            var newUser = Mapper.Map<User>(userDTO);
            this.Context.Users.Add(newUser);
            Context.SaveChanges();
        }

        public void LogInUser(string userName, string password, UserSessionModel userSession)
        {
            User user;
            try
            {
                user = this.Context.Users.Where(x => x.UserName == userName && x.Password == password).Single();
            }
            catch (Exception)
            {
                throw new Exception("Failed to find user in database.");
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
        public IList<Post> GetAllPosts(UserSessionModel userSession)
        {
            var posts = this.Context.Posts.Where(x => x.UserId == userSession.Id).ToList();
            return posts;

        }

    }
}
