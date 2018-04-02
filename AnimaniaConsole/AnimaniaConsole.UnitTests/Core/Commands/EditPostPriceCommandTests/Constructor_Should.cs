using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using AnimaniaConsole.Core.Contracts;

namespace AnimaniaConsole.UnitTests.Core.Commands.EditPostPriceCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Throw_ArgumentNullException_When_UserServices_IsNull()
        {
            //Arrange
            var stubUserServices = new Mock<IUserServices>();
            var stubValidateCore = new Mock<IValidateCore>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EditPostPriceCommand(null, stubUserServices.Object, stubValidateCore.Object));
        }


        [TestMethod]
        public void Throw_ArgumentNullException_When_PpostServices_IsNull()
        {
            //Arrange
            var stubPostServices = new Mock<IPostServices>();
            var stubValidateCore = new Mock<IValidateCore>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EditPostPriceCommand(stubPostServices.Object, null, stubValidateCore.Object));
        }



        [TestMethod]
        public void Throw_ArgumentNullException_When_ValidateCore_IsNull()
        {
            //Arrange
            var stubPostServices = new Mock<IPostServices>();
            var stubUserServices = new Mock<IUserServices>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EditPostPriceCommand(stubPostServices.Object, stubUserServices.Object, null));
        }
    }
}