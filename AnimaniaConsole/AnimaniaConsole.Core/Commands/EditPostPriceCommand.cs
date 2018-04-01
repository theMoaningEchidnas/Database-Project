using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Core.Contracts;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class EditPostPriceCommand : ICommand
    {
        private readonly IPostServices postService;
        private readonly IUserServices userService;
        private readonly IValidateCore coreValidator;

        public EditPostPriceCommand(IPostServices postService, IUserServices userService, IValidateCore coreValidator)
        {
            this.postService = postService ?? throw new ArgumentNullException();
            this.userService = userService ?? throw new ArgumentNullException();
            this.coreValidator = coreValidator ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            var postId = this.coreValidator.IntFromString(parameters[1], "postId");

            var loggedUserId = this.userService.GetLoggedUserId();

            var postToBeEdited = this.postService.FindPostById(postId);

            postToBeEdited.Price = this.coreValidator.DecimalFromString(parameters[2], "price");

            this.postService.VerifyPostOwnerId(postToBeEdited.UserId, loggedUserId);

            var result = postService.EditPostPrice(postToBeEdited);

            return result;
        }
    }
}
