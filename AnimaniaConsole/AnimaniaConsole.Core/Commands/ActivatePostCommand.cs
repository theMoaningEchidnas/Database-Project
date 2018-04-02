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

        public ActivatePostCommand(IPostServices postService)
        {
            this.postService = postService ?? throw new ArgumentNullException();
        }
        public string Execute(IList<string> parameters)
        {
            var postIdToActivate = int.Parse(parameters[1]);
            this.postService.ActivatePost(postIdToActivate);

            return $"Post With ID:{postIdToActivate} was activated!";
        }
    }
}
