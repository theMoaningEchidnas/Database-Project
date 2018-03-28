using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Data;
using AnimaniaConsole.Services.Contracts;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    //SearchPosts;DESCRIPTION

    public class SearchPostsCommand : ICommand
    {
        private readonly IPostServices postService;

        public SearchPostsCommand(IPostServices postService)
        {
            this.postService = postService;
        }

        public string Execute(IList<string> parameters)
        {
            var searchedText = parameters[1];
            var listOfFoundPosts = postService.SearchPosts(searchedText);
            return postService.PrintPostsToConsole(listOfFoundPosts);

        }

    }
}
