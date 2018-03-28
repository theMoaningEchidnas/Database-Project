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
    public class ShowMyDeactivatedPostsCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IPostServices postService;

        public ShowMyDeactivatedPostsCommand(IUserService userService,IPostServices postService)
        {
            this.userService = userService;
            this.postService = postService;
        }
        public string Execute(IList<string> parameters)
        {
            var userID = userService.GetLoggedUserId();
            var postsToShow = postService.GetAllDeactivetedPosts(userID);
            return postService.PrintPostsToConsole(postsToShow);
        }
    }
}
