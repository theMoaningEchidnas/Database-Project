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

namespace AnimaniaConsole.Services.Services
{
    public class UserService:IUserService
    {
        private readonly IAnimaniaConsoleContext ctx;
        private readonly IMapper mapper;

        public UserService(IAnimaniaConsoleContext ctx,IMapper mapper)
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
    
    }
}
