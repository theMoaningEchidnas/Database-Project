using System;
using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class EditPostTitleCommand : ICommand
    {
        private readonly IPostServices postService;
        private readonly IUserServices userService;

        public EditPostTitleCommand(IPostServices postService, IUserServices userService)
        {
            this.postService = postService ?? throw new ArgumentNullException();
            this.userService = userService ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            var postId = int.Parse(parameters[1]);

            var loggedUserId = this.userService.GetLoggedUserId();

            var postToBeEdited = this.postService.FindPostById(postId);

            postToBeEdited.Title = parameters[2];

            this.postService.VerifyPostOwnerId(postToBeEdited.UserId, loggedUserId);

            var result = postService.EditPostTitle(postToBeEdited);

            return result;
        }
    }
}
