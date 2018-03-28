﻿using AnimaniaConsole.Core.CommandContracts;
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
            this.postService = postService;
        }
        public string Execute(IList<string> parameters)
        {
            var postToActivate = int.Parse(parameters[1]);
            this.postService.ActivatePost(postToActivate);

            return $"Post With ID:{postToActivate} was activated!";
        }
    }
}