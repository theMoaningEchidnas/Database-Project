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
        public CreatePostCommand(IPostService postService)
        {
            this.PostService = postService;
        }

        public IPostService PostService { get; }

        public string Execute(IList<string> parameters)
        {
            string message = null;

            //CreatePost;New Post Title;The shortest post DESCRIPTION for my sweet pupy;10000;20.10.2017;SnoopDogy;Dog;Pudel2;Sofia

            CreatePostModel postToCreate = new CreatePostModel();

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