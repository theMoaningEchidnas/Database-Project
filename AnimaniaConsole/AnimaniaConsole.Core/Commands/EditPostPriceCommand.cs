using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class EditPostPriceCommand : ICommand
    {
        private readonly IPostServices postService;
        private readonly IUserServices userService;

        public EditPostPriceCommand(IPostServices postService, IUserServices userService)
        {
            this.postService = postService ?? throw new ArgumentNullException();
            this.userService = userService ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            var postId = int.Parse(parameters[1]);

            var loggedUserId = this.userService.GetLoggedUserId();

            var postToBeEdited = this.postService.FindPostById(postId);

            postToBeEdited.Price = decimal.Parse(parameters[2]);

            this.postService.VerifyPostOwnerId(postToBeEdited.UserId, loggedUserId);

            var result = postService.EditPostPrice(postToBeEdited);

            return result;
        }
    }
}
