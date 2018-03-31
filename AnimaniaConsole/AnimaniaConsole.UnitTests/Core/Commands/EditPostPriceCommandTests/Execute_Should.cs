using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using AnimaniaConsole.Core.Contracts;

namespace AnimaniaConsole.UnitTests.Core.Commands.EditPostPriceCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void Throw_ArgumentException_When_PostId_CannotBeParsetToInt()
        {
            //Arrange
            var stubPostServices = new Mock<IPostServices>();
            var stubUserServices = new Mock<IUserServices>();
            var stubValidateCore = new Mock<IValidateCore>();

            var parameters = new string[] { "abc" };

            stubValidateCore.Setup(x=>x.IntFromString(parameters[0], "postId")).Verifiable();

            var sut = new EditPostPriceCommand(stubPostServices.Object, stubUserServices.Object, stubValidateCore.Object);

            //Act & Assert
            
            //Assert.ThrowsException<ArgumentOutOfRangeException>(() => sut.Execute(parameters));
        }

        [TestMethod]
        public void Throw_ArgumentException_When_Price_IsNotDecimal()
        {


        }

        [TestMethod]
        public void Throw_ArgumentException_When_ThereIsNoLogedUser()
        {


        }

        [TestMethod]
        public void Throw_ArgumentException_When_PostToBeEdited_DoesNotExist()
        {


        }

        [TestMethod]
        public void Throw_ArgumentException_When_UsedTriesToEditPrice_OnPostWhichIsCreatedByOtherUser()
        {


        }


    }
}
