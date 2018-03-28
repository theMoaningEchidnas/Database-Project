using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Commands
{
    public class SearchPostsByPriceFromCommand : ICommand
    {

        private IPostService postService;
        public SearchPostsByPriceFromCommand(IPostService postService)
        {
            this.postService = postService;
        }
        public string Execute(IList<string> parameters)
        {
            var searchedText = parameters[1];
            var searchedPriceFrom = int.Parse(parameters[2]);
            var posts = postService.SearchPostsFrom(searchedText,searchedPriceFrom);
            return postService.PrintPostsToConsole(posts);
        }
    }
}
