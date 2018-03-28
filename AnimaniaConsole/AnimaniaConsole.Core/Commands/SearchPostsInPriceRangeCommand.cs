using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Commands
{
    public class SearchPostsInPriceRangeCommand : ICommand
    {
        private readonly IPostServices postService;

        public SearchPostsInPriceRangeCommand(IPostServices postService)
        {
            this.postService = postService;
        }
        public string Execute(IList<string> parameters)
        {
            var searchedText = parameters[1];
            var searchedPriceFrom = int.Parse(parameters[2]);
            var searchedPriceTo = int.Parse(parameters[3]);

            var posts = postService.SearchPostsFromTo(searchedText, searchedPriceFrom,searchedPriceTo);
            return postService.PrintPostsToConsole(posts);
        }
    }
}
