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
        private readonly IAnimaniaConsoleContext context;
        private readonly UserSessionModel session;
        private readonly IUserService userService;

        public EditPostDescriptionCommand(IPostService postService, IAnimaniaConsoleContext context, UserSessionModel session, IUserService userService)
        {
            this.postService = postService;
            this.context = context;
            this.session = session;
            this.userService = userService;
        }

        public string Execute(IList<string> parameters)
        {
            var postId = int.Parse(parameters[1]);
            var newDescription = parameters[2];

            var editPostModel = new EditPostModel()
            {
                Id = postId,
                Description= newDescription
            };

            var loggedUserId = this.userService.GetLoggedUserId(session);
            if (loggedUserId == 0) { throw new ArgumentException("You are not logged in! Please, log in and try again!"); }

            var postToBeEdited = context.Posts.Find(postId);
            if (postToBeEdited == null) { throw new ArgumentException("Such post doesn't exist. Please check the id and try again!"); }

            var userIdOwnerOfPostToBeEdited = postToBeEdited.UserId;
            if (loggedUserId != userIdOwnerOfPostToBeEdited) { return "Post Id provided is not correct. Please check the id and try again!"; }

            var result = postService.EditPostDescription(editPostModel);
            return result;
        }
    }
}
