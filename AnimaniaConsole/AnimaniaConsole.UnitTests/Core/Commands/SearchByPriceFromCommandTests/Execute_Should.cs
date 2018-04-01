using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace AnimaniaConsole.UnitTests.Core.Commands.SearchByPriceFromCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void Calls_ServiceSearchPostsFrom_Once()
        {
            var service = new Mock<IPostServices>();


            var Params = new List<string>();
            Params.Add("x");
            Params.Add("abcd");
            Params.Add("10");

            var command = new SearchPostsByPriceFromCommand(service.Object);

            service.Setup(a => a.SearchPostsFrom(Params[1], int.Parse(Params[2]))).Returns(It.IsAny<IEnumerable<PostModel>>);

            command.Execute(Params);

            service.Verify(a => a.SearchPostsFrom(Params[1], int.Parse(Params[2])), Times.Once());

        }

    }
}
