﻿using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.Core.Contracts;
using AnimaniaConsole.Core.Engine;
using AnimaniaConsole.Core.Factories;
using AnimaniaConsole.Core.Factories.Contracts;
using AnimaniaConsole.Core.Providers;
using AnimaniaConsole.Core.Wrappers;
using AnimaniaConsole.Data;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using Autofac;
using AutoMapper;
using Module = Autofac.Module;
using AnimaniaConsole.DTO.Models;

namespace Client
{
    public class AutofacModule : Module
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

            builder.Register(x => Mapper.Instance);
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<SessionService>().As<ISessionService>();

            builder.RegisterType<UserSessionModel>().AsSelf().SingleInstance();
            builder.RegisterType<RegisterUserCommand>().Named<ICommand>("RegisterUser");
            builder.RegisterType<ChangePasswordCommand>().Named<ICommand>("ChangePassword");
            builder.RegisterType<RegisterUserCommand>().Named<ICommand>("RegisterUser").SingleInstance();
            builder.RegisterType<CreatePostCommand>().Named<ICommand>("CreatePost").SingleInstance();
            builder.RegisterType<LogInUserCommand>().Named<ICommand>("LogInUser").SingleInstance();
            builder.RegisterType<SearchPostsCommand>().Named<ICommand>("SearchPosts").SingleInstance();


        }
    }
}
