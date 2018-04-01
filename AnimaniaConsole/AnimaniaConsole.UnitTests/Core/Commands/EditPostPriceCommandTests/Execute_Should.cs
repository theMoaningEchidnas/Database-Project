using System.Collections.Generic;
using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.Core.Contracts;
using AnimaniaConsole.Data;
using AnimaniaConsole.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnimaniaConsole.UnitTests.Core.Commands.EditPostPriceCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallValidatorMethodForIntFromString_When_ParsingPostId()
        {
            //Arrange

            var mockValidateCore = new Mock<IValidateCore>();
            mockValidateCore.Setup(x => x.IntFromString("5", "postId")).Returns(It.IsAny<int>());
            mockValidateCore.Setup(x => x.DecimalFromString("100.55", "price")).Returns(It.IsAny<decimal>());
            
            var stubPostServices = new Mock<IPostServices>();
            var stubUserServices = new Mock<IUserServices>();

            var parameters = new string[] { "EditPostPrice", "5", "100.55" };

            
            var command = new EditPostPriceCommand(stubPostServices.Object, stubUserServices.Object, mockValidateCore.Object);
            //command..postService.FindPostById(postId);
            
            //Act
            command.Execute(parameters);

            //Assert
            mockValidateCore.Verify(x => x.IntFromString("5", "postId"), Times.AtLeast(1));
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
