using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.Core.Contracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnimaniaConsole.UnitTests.Core.Commands.EditPostPriceCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        private Mock<IValidateCore> stubValidateCore;
        private Mock<IPostServices> stubPostServices;
        private Mock<EditPostModel> stubEditPostModel;
        private Mock<IUserServices> stubUserServices;

        private EditPostPriceCommand command;

        [TestInitialize]
        public void Initialize()
        {
            stubValidateCore = new Mock<IValidateCore>();
            stubPostServices = new Mock<IPostServices>();
            stubEditPostModel = new Mock<EditPostModel>();
            stubUserServices = new Mock<IUserServices>();

            command = new EditPostPriceCommand(stubPostServices.Object, stubUserServices.Object, stubValidateCore.Object);

        }

        [TestMethod]
        public void CallValidateCoreMethodForIntFromString_When_ParsingPostId()
        {
            //Arrange
            stubValidateCore.Setup(x => x.IntFromString("5", "postId")).Returns(It.IsAny<int>());
            stubValidateCore.Setup(x => x.DecimalFromString("100.55", "price")).Returns(It.IsAny<decimal>());
            stubPostServices.Setup(x => x.FindPostById(It.IsAny<int>())).Returns(stubEditPostModel.Object);

            var parameters = new string[] { "EditPostPrice", "5", "100.55" };

            //Act
            command.Execute(parameters);

            //Assert
            stubValidateCore.Verify(x => x.IntFromString("5", "postId"), Times.AtLeast(1));
        }
    }
}
