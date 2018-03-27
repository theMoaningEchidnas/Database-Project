using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class EditPostDescriptionCommand : ICommand
    {
        private readonly IPostService postService;
        private readonly UserSessionModel session;
        private readonly IUserService userService;

        public EditPostDescriptionCommand(IPostService postService, UserSessionModel session, IUserService userService)
        {
            this.postService = postService;
            this.session = session;
            this.userService = userService;
        }

        public string Execute(IList<string> parameters)
        {
            var postId = int.Parse(parameters[1]);

            var loggedUserId = this.userService.GetLoggedUserId(session);

            var postToBeEdited = this.postService.FindPostById(postId);

            postToBeEdited.Description = parameters[2];

            this.postService.VerifyPostOwnerId(postToBeEdited.UserId, loggedUserId);

            var result = postService.EditPostDescription(postToBeEdited);

            return result;
        }
    }
}
