﻿using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.Core.Contracts;
using AnimaniaConsole.Core.Engine;
using AnimaniaConsole.Core.Factories;
using AnimaniaConsole.Core.Factories.Contracts;
using AnimaniaConsole.Core.Providers;
using AnimaniaConsole.Core.Validator;
using AnimaniaConsole.Core.Wrappers;
using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Contracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using Autofac;
using AutoMapper;
using Module = Autofac.Module;

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
            builder.RegisterType<ValidateCore>().As<IValidateCore>().SingleInstance();
            builder.RegisterType<AnimaniaConsoleContext>().As<IAnimaniaConsoleContext>().InstancePerDependency();
            builder.RegisterType<PostServices>().As<IPostServices>();
            //the following three are single instance because we do not expect to change (add/ remove items) them during user interactions
            builder.RegisterType<LocationServices>().As<ILocationServices>().SingleInstance();
            builder.RegisterType<AnimalTypeServices>().As<IAnimalTypeServices>().SingleInstance();
            builder.RegisterType<BreedTypeServices>().As<IBreedTypeServices>().SingleInstance();
            builder.RegisterType<UserSessionModel>().As<IUserSessionModel>().SingleInstance();
            builder.Register(x => Mapper.Instance).SingleInstance();
            builder.RegisterType<UserServices>().As<IUserServices>();
            //If above is not single then the different commands related to same user will not work properly, e.g. we deactivate user and then try to show his/her posts :)

            
            builder.RegisterType<GetPostsInPDFCommand>().Named<ICommand>("GetPostsInPDF").SingleInstance();
            builder.RegisterType<ChangePasswordCommand>().Named<ICommand>("ChangePassword").SingleInstance();
            builder.RegisterType<RegisterUserCommand>().Named<ICommand>("RegisterUser").SingleInstance();
            builder.RegisterType<CreatePostCommand>().Named<ICommand>("CreatePost").SingleInstance();
            builder.RegisterType<LogInUserCommand>().Named<ICommand>("LogInUser").SingleInstance();
            builder.RegisterType<SearchPostsCommand>().Named<ICommand>("SearchPosts").SingleInstance();
            builder.RegisterType<ShowMyPostsCommand>().Named<ICommand>("ShowMyPosts").SingleInstance();
            builder.RegisterType<ShowMyDeactivatedPostsCommand>().Named<ICommand>("ShowMyDeactivatedPosts").SingleInstance();
            builder.RegisterType<ShowMyActivePostsCommand>().Named<ICommand>("ShowMyActivePosts").SingleInstance();
            builder.RegisterType<EditPostTitleCommand>().Named<ICommand>("EditPostTitle").SingleInstance();
            builder.RegisterType<EditPostDescriptionCommand>().Named<ICommand>("EditPostDescription").SingleInstance();
            builder.RegisterType<EditPostPriceCommand>().Named<ICommand>("EditPostPrice").SingleInstance();
            builder.RegisterType<DeactivateUserCommand>().Named<ICommand>("DeactivateUser").SingleInstance();
            builder.RegisterType<SearchPostsByAnimalTypeCommand>().Named<ICommand>("SearchPostsByAnimalType").SingleInstance();
            builder.RegisterType<SearchPostsByPriceFromCommand>().Named<ICommand>("SearchPostsByPriceFrom").SingleInstance();
            builder.RegisterType<SearchPostsByPriceRangeToCommand>().Named<ICommand>("SearchPostsByPriceTo").SingleInstance();
            builder.RegisterType<SearchPostsInPriceRangeCommand>().Named<ICommand>("SearchPostsByPriceInRange").SingleInstance();
            builder.RegisterType<ActivatePostCommand>().Named<ICommand>("ActivatePost").SingleInstance();
            builder.RegisterType<LogOutUserCommand>().Named<ICommand>("LogOutUser").SingleInstance();
            builder.RegisterType<HelpCommand>().Named<ICommand>("Help").SingleInstance();
            builder.RegisterType<DeactivatePostCommand>().Named<ICommand>("DeactivatePost").SingleInstance();
        }
    }
}
