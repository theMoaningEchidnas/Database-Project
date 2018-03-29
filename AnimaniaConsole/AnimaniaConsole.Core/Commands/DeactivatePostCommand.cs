﻿using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Commands
{
    public class DeactivatePostCommand : ICommand
    {
        private readonly IPostServices postService;
        private readonly IUserService userService;

        public DeactivatePostCommand(IPostServices postService, IUserService userService)
        {
            this.postService = postService;
            this.userService = userService;
        }
        public string Execute(IList<string> parameters)
        {
            var postIdToDeactivate = int.Parse(parameters[1]);
            this.postService.DeactivatePost(postIdToDeactivate, userService.GetLoggedUserId());

            return $"Post With ID:{postIdToDeactivate} was deactivated!";
        }
    }
}
