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
    class ShowMyActivePostsCommand : ICommand
    {
        private readonly IPostServices postService;
        private readonly IUserService userService;

        public ShowMyActivePostsCommand(IPostServices postService, IUserService userService)
        {
            this.postService = postService;
            this.userService = userService;
        }
        public string Execute(IList<string> parameters)
        {
            var userId = userService.GetLoggedUserId();

           // var posts  = 
            return "";
        }
    }
}
