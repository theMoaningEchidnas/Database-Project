using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Commands
{
    public class SearchPostsByPriceRangeToCommand : ICommand
    {
        private readonly IPostServices postService;

        public SearchPostsByPriceRangeToCommand(IPostServices postService)
        {
            this.postService = postService;
        }
        public string Execute(IList<string> parameters)
        {
            var searchedText = parameters[1];
            var searchedPriceTo = int.Parse(parameters[2]);
            var posts = postService.SearchPostsTo(searchedText, searchedPriceTo);
            return postService.PrintPostsToConsole(posts);
        }
    }
}
