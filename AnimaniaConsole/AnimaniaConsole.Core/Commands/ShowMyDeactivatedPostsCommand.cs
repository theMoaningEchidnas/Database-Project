using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Commands
{
    public class ShowMyDeactivatedPostsCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IPostServices postService;
        private readonly UserSessionModel user;

        public ShowMyDeactivatedPostsCommand(IUserService userService,IPostServices postService,UserSessionModel user)
        {
            this.userService = userService;
            this.postService = postService;
            this.user = user;
        }
        public string Execute(IList<string> parameters)
        {
            var userID = userService.GetLoggedUserId(user);
            var postsToShow = postService.GetAllDeactivetedPosts(userID);
            return postService.PrintPostsToConsole(postsToShow);
        }
    }
}
