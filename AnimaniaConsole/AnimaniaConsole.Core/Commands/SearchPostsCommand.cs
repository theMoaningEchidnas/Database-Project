using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Data;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimaniaConsole.Core.Commands
{
    public class SearchPostsCommand : ICommand
    {
        private readonly IPostService postService;
        private readonly IAnimaniaConsoleContext context;

        public SearchPostsCommand(IPostService postService, IAnimaniaConsoleContext context)
        {
            this.postService = postService;
            this.context = context;
        }

        //SearchPosts;DESCRIPTION
        public string Execute(IList<string> parameters)
        {

            var searchedText = parameters[1];
            var listOfFoundPosts = postService.SearchPosts(searchedText);
            var searchResult = new StringBuilder();
            searchResult = listOfFoundPosts.Any()
                ? searchResult.AppendLine($"{listOfFoundPosts.Count()} posts found.") : searchResult.AppendLine("No posts found!");

            var counter = 0;

            foreach (var foundPost in listOfFoundPosts)
            {
                counter++;
                var location = context.Locations.Where(x => x.Id == foundPost.Animal.LocationId)
                    .Select(x => x.LocationName).Single();
                searchResult.AppendLine(string.Format("Post No:{5}{4}" +
                                                      "#Title: {0}{4}" +
                                                      "#Description: {1}{4}" +
                                                      "#Price: {2}{4}" +
                                                      "#Location: {3}{4}" +
                                                      "--------------------{4}",
                        foundPost.Title, foundPost.Description, foundPost.Price, location, Environment.NewLine, counter));
            }
            return searchResult.ToString();

        }

    }
}
