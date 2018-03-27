using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class ShowMyPostsCommand : ICommand
    {
        private readonly IPostService postService;
        private readonly UserSessionModel session;
        private readonly IUserService userService;

        public ShowMyPostsCommand(IPostService postService, UserSessionModel session, IUserService userService)
        {
            this.postService = postService;
            this.session = session;
            this.userService = userService;
        }

        public string Execute(IList<string> parameters)
        {
            var userId = this.userService.GetLoggedUserId(session);

            var myPosts = postService.ShowMyPosts(userId);
            return postService.PrintPostsToConsole(myPosts);
        }
    }
}
