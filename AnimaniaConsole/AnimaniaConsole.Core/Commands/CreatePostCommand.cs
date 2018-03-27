using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AnimaniaConsole.Core.Commands
{

    //CreatePost;New Post Title;The shortest post DESCRIPTION for my sweet pupy;10000;20.10.2017;SnoopDogy;Dog;Pudel2;Sofia

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

        public IPostService PostService { get; }

        public string Execute(IList<string> parameters)
        {
            var userId = this.userService.GetLoggedUserId(session);

            var BD = DateTime.ParseExact(parameters[4], "d.M.yyyy", CultureInfo.InvariantCulture);

            var postToCreate = new CreatePostModel()
            {
                Title = parameters[1],
                Description = parameters[2],
                Price = decimal.Parse(parameters[3]),
                Birthday = BD,
                AnimalName = parameters[5],
                AnimalTypeName = parameters[6],
                BreedTypeName = parameters[7],
                LocationName = parameters[8],
                PostDate = DateTime.Now,
                Status = true
            };


            try
            {
                this.PostService.CreatePost(postToCreate, userId);
                return $"Post was created successfully!";
            }
            catch
            {
                return "Something went wrong, please check input and try again!";
            }

        }
    }
}