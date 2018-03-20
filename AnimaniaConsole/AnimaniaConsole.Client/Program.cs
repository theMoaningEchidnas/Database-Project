using System;
using System.Linq;
using System.Reflection;
using AnimaniaConsole.Data;
using AnimaniaConsole.DTO;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using Autofac;
using AutoMapper;
using Client;

namespace AnimaniaConsole.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperConfig.Initialize();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var postService = container.Resolve<IPostService>();
            var posts = postService.GetAll();
            //TEST FOR CREATING USER AND ADDING IT TO THE DATABASE
            //var userservice = container.Resolve<IUserService>();
            //var user = new CreateUserModel();
            //user.UserName = "adasfaasf";
            //user.FirstName = "asdasfa";
            //user.LastName = "asdasfas";
            //user.Password = "As123asf21";
            //user.Email = "asdaf@abv.bg";
            //userservice.RegisterUser(user);


        }
    }
}
