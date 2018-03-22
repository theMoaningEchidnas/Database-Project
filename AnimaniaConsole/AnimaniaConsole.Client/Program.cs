using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using Autofac;
using Client;
using AnimaniaConsole.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

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

            var engine = container.Resolve<IEngine>();
            engine.Run();

            //TEST FOR CREATING USER AND ADDING IT TO THE DATABASE
            //var userservice = container.Resolve<IUserService>();
            //var user = new CreateUserModel();
            //user.UserName = "adasfaasf";
            //user.FirstName = "asdasfa";
            //user.LastName = "asdasfas";
            //user.Password = "As123asf21";
            //user.Email = "asdaf@abv.bg";
            //userservice.RegisterUser(user);



            Console.WriteLine(posts.Count());

            var createPostModel = new CreatePostModel
            {
                Title = "My first post",
                Description = "This is the description of my first post",
                PostDate = DateTime.Parse("2018-03-20"),
                Price = 250,
                Status = true,
                
                AnimalName = "New Baby",
                Birthday = DateTime.Parse("2017-03-20"),
                BreedTypeName = "Pudel2",
                AnimalTypeName = "Dog",
                LocationName = "Sofia"

            };

            postService.CreatePost(createPostModel);

        }
    }
}
