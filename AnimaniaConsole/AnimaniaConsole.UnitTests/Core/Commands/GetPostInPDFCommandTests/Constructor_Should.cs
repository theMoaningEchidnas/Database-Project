using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AnimaniaConsole.UnitTests.Core.CommandsGetPostInPDFTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Throw_Exception_IfPostService_IsNull()
        {
            //Arrange
            var stubUserServices = new Mock<IUserServices>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new GetPostsInPDFCommand(null, stubUserServices.Object));
        }

        [TestMethod]
        public void Throw_Exception_IfUserService_IsNull()
        {
            //Arrange
            var stubPostServices = new Mock<IPostServices>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new GetPostsInPDFCommand(stubPostServices.Object, null));
        }


    }
}
