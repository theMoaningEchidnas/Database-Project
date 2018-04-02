using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using AnimaniaConsole.Core.Contracts;

namespace AnimaniaConsole.Core.Commands
{
    public class EditPostDescriptionCommand : ICommand
    {
        private readonly IValidateCore validateCore;
        private readonly IPostServices postService;
        private readonly IUserServices userService;

        public EditPostDescriptionCommand(IPostServices postService, IUserServices userService, IValidateCore validateCore)
        {
            this.validateCore = validateCore ?? throw new ArgumentNullException();
            this.postService = postService ?? throw new ArgumentNullException();
            this.userService = userService ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            var postId = this.validateCore.IntFromString(parameters[1], "postId");

            var loggedUserId = this.userService.GetLoggedUserId();

            var postToBeEdited = this.postService.FindPostById(postId);

            postToBeEdited.Description = parameters[2];

            this.postService.VerifyPostOwnerId(postToBeEdited.UserId, loggedUserId);

            var result = postService.EditPostDescription(postToBeEdited);

            return result;
        }
    }
}
