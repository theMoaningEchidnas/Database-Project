﻿using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AnimaniaConsole.UnitTests.Core.Commands.EditPostPriceCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        private IPostServices postServices;
        private IUserServices userServices;

        [TestMethod]
        public void Throw_Exception_When_UserServices_IsNull()
        {
            //Arrange
            var stubUserServices = new Mock<IUserServices>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EditPostPriceCommand(postServices, stubUserServices.Object));
        }


        [TestMethod]
        public void Throw_Exception_When_PpostServices_IsNull()
        {
            //Arrange
            var stubPostServices = new Mock<IPostServices>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EditPostPriceCommand(stubPostServices.Object, userServices));
        }
    }
}