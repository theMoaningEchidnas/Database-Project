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

    public class ActivatePostCommand : ICommand
    {
        private readonly IPostServices postService;
        private readonly UserSessionModel user;

        public ActivatePostCommand(IPostServices postService,UserSessionModel user)
        {
            this.postService = postService;
            this.user = user;
        }
        public string Execute(IList<string> parameters)
        {
            var postToActivate = int.Parse(parameters[1]);
            this.postService.ActivatePost(postToActivate);

            return $"Post With ID:{postToActivate} was activated!";
        }
    }
}
