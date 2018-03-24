using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AnimaniaConsole.Core.Commands
{
    public class CreatePostCommand : ICommand
    {
        private readonly UserSessionModel session;
        private readonly IUserService userService;

        public CreatePostCommand(IPostService postService, UserSessionModel session, IUserService userService)
        {
            this.session = session;
            this.userService = userService;
            this.PostService = postService;
        }

        public bool CheckUserIsLogged => this.userService.VerifyUserIsAlreadyLoggedIn(session);

        public IPostService PostService { get; }

        public string Execute(IList<string> parameters)
        {
            if (!CheckUserIsLogged)
            {
                throw new ArgumentException("You are not logged in! Please, log in and try again!");
            }

            string message = null;

            //CreatePost;New Post Title;The shortest post DESCRIPTION for my sweet pupy;10000;20.10.2017;SnoopDogy;Dog;Pudel2;Sofia


            var postToCreate = new CreatePostModel();

            var BD = DateTime.ParseExact(parameters[4], "d.M.yyyy", CultureInfo.InvariantCulture);

            postToCreate.Title = parameters[1];
            postToCreate.Description = parameters[2];
            postToCreate.Price = decimal.Parse(parameters[3]);
            postToCreate.Birthday = BD;
            postToCreate.AnimalName = parameters[5];
            postToCreate.AnimalTypeName = parameters[6];
            postToCreate.BreedTypeName = parameters[7];
            postToCreate.LocationName = parameters[8];

            postToCreate.PostDate = DateTime.Now;
            postToCreate.Status = true;

            try
            {
                this.PostService.CreatePost(postToCreate);
                message = $"Post was created successfully!";
            }
            catch
            {
                message = "Something went wrong try again!";
            }

            return message;


        }
    }
}