using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Data;
using AnimaniaConsole.Services.Contracts;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    //SearchPosts;DESCRIPTION

    public class SearchPostsCommand : ICommand
    {
        private readonly IPostService postService;
        private readonly IAnimaniaConsoleContext context;

        public SearchPostsCommand(IPostService postService, IAnimaniaConsoleContext context)
        {
            this.postService = postService;
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var searchedText = parameters[1];
            var listOfFoundPosts = postService.SearchPosts(searchedText);
            return postService.PrintPostsToConsole(listOfFoundPosts);

        }

    }
}
