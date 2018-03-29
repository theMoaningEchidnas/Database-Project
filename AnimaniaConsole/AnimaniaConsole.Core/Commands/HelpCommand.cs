using AnimaniaConsole.Core.CommandContracts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimaniaConsole.Core.Commands
{
    public class HelpCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var commandTypes = (from allTypes in Assembly.GetExecutingAssembly().GetTypes()
                                where allTypes.IsClass && allTypes.Namespace.Contains("AnimaniaConsole.Core.Commands") && !allTypes.Name.Contains("DisplayClass") && !allTypes.Name.Contains("<>c")
                                select allTypes).ToList();

            var stringBuilder = new StringBuilder();

            var commandsWithParams = new Dictionary<string, string>()
            {
                { "ActivatePost","(postId)"},
                { "CreatePost","(title; description; price; birthday; animalName; animalTypeName; breedTypeName; locationName)"},
                { "DeactivatePost","(postId)"},
                { "EditPostDescription","(postId, newDescription)"},
                { "EditPostPrice","(postId, newPrice)"},
                { "EditPostTitle","(postId, newTitle)"},
                { "SearchPostsByPriceFrom","(searchedText; priceFrom)"},
                { "SearchPostsByPriceRangeTo","(searchedTextpriceTo)"},
                { "SearchPosts","(searchedText)"},
                { "SearchPostsInPriceRange","(searchedText; priceFrom; priceTo)"},
                { "LogInUser","(userName; password)"},
                { "RegisterUser","(userName; password; firstName; lastName; email; tel; facebook; skype)"}
            };

            foreach (var command in commandTypes)
            {
                var commandName = command.Name.Substring(0, command.Name.Length - 7);
                if (commandsWithParams.ContainsKey(commandName))
                    stringBuilder.AppendLine(commandName + commandsWithParams[commandName]);
                else
                    stringBuilder.AppendLine(commandName);
            }

            return stringBuilder.ToString();
        }
    }
}
