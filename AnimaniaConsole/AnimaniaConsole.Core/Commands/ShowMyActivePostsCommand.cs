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
    public class ShowMyActivePostsCommand : ICommand
    {
        private readonly IPostServices postService;
        private readonly IUserServices userService;

        public ShowMyActivePostsCommand(IPostServices postService, IUserServices userService)
        {
            this.postService = postService ?? throw new ArgumentNullException();
            this.userService = userService ?? throw new ArgumentNullException();
        }
        public string Execute(IList<string> parameters)
        {
            var userId = userService.GetLoggedUserId();

            var posts = postService.GetActivePosts(userId);

            return postService.PrintPostsToConsole(posts);
        }
    }
}
