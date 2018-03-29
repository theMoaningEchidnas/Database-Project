using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class ShowMyPostsCommand : ICommand
    {
        private readonly IPostServices postService;
        private readonly IUserServices userService;

        public ShowMyPostsCommand(IPostServices postService, IUserServices userService)
        {
            this.postService = postService;
            this.userService = userService;
        }

        public string Execute(IList<string> parameters)
        {
            var userId = this.userService.GetLoggedUserId();

            var myPosts = postService.GetAllMyPosts(userId);
            return postService.PrintPostsToConsole(myPosts);
        }
    }
}
