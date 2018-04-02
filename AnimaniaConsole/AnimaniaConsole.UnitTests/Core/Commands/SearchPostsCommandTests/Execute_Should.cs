using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace AnimaniaConsole.UnitTests.Core.Commands.SearchPostsCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void Pass_TheRight_Arguments_ToSearchPosts()
        {
            var postServiceMock = new Mock<IPostServices>();
            var searchPostsCommand = new SearchPostsCommand(postServiceMock.Object);
            IList<string> arguments = new List<string> { "firstArg", "secondArg" };
            postServiceMock.Setup(p => p.SearchPosts("secondArg")).Verifiable();

            searchPostsCommand.Execute(arguments);

            postServiceMock.Verify();
        }

        public void Pass_TheRight_Argumnets_ToPrintPostToConsole()
        {
            var postServiceMock = new Mock<IPostServices>();
            var postsMock = new Mock<IEnumerable<PostModel>>();
            postServiceMock.Setup(p => p.SearchPosts(It.IsAny<string>())).Returns(postsMock.Object);


        }
    }
}
