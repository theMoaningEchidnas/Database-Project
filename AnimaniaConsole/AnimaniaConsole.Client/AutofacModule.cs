using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AnimaniaConsole.Data;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using Autofac;
using Module = Autofac.Module;
using AutoMapper;
using AnimaniaConsole.Core.Engine;
using AnimaniaConsole.Core.Contracts;
using AnimaniaConsole.Core.Commands.CommandContracts;
using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.Core;
using AnimaniaConsole.Core.Wrappers;
using AnimaniaConsole.Core.Factories;

namespace Client
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>().SingleInstance();
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<Writer>().As<IWriter>().SingleInstance();
            builder.RegisterType<Reader>().As<IReader>().SingleInstance();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();




            builder.RegisterType<AnimaniaConsoleContext>().As<IAnimaniaConsoleContext>().InstancePerDependency();
            builder.RegisterType<PostService>().As<IPostService>();
        
            builder.Register(x=>Mapper.Instance);
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<RegisterUserCommand>().Named<ICommand>("RegisterUser");


        }
    }
}
