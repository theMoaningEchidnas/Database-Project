using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class EditPostPriceCommand : ICommand
    {
        private readonly IPostServices postService;
        private readonly UserSessionModel session;
        private readonly IUserService userService;

        public EditPostPriceCommand(IPostServices postService, UserSessionModel session, IUserService userService)
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

            postToBeEdited.Price = decimal.Parse(parameters[2]);

            this.postService.VerifyPostOwnerId(postToBeEdited.UserId, loggedUserId);

            var result = postService.EditPostPrice(postToBeEdited);

            return result;
        }
    }
}
