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
            Console.WriteLine(posts.Count());
        }
    }
}
