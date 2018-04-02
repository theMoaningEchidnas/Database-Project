using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Commands
{
    public class SearchPostsByAnimalTypeCommand : ICommand
    {
        private readonly IPostServices postService;

        public SearchPostsByAnimalTypeCommand(IPostServices postService)
        {
            this.postService = postService ?? throw new ArgumentNullException();
        }
        public string Execute(IList<string> parameters)
        {
            var animalType = parameters[1];

            var posts = postService.SearchPostsByAnimalType(animalType);
            return postService.PrintPostsToConsole(posts);
        }
    }
}
