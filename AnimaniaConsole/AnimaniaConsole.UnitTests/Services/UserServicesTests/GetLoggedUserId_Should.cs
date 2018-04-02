using System;
using System.Collections.Generic;
using System.Data.Entity;
using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Contracts;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AnimaniaConsole.UnitTests.Helpers;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnimaniaConsole.UnitTests.Services.UserServicesTests
{
    [TestClass]
    public class GetLoggedUserId_Should
    {
        private IUserServices userServices;
        private Mock<IUserSessionModel> stubUserSessionModel;

        [TestInitialize]
        public void Initialize()
        {
            var stubContext = new Mock<IAnimaniaConsoleContext>();
            var stubMapper = new Mock<IMapper>();
            stubUserSessionModel = new Mock<IUserSessionModel>();

            userServices = new UserServices(stubContext.Object, stubMapper.Object, stubUserSessionModel.Object);
        }

        [TestMethod]
        public void Throws_ArgumentException_When_User_IsNotLoggedIn()
        {
            //Arrange
            stubUserSessionModel.Setup(x => x.Id).Returns(0);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => userServices.GetLoggedUserId());
        }

        [TestMethod]
        public void ReturnsInstanceOfTypeInt_When_Executed()
        {
            //Arrange
            stubUserSessionModel.Setup(x => x.Id).Returns(4);

            //Act
            var expectedLoggedUserId = userServices.GetLoggedUserId();

            //Assert
            Assert.IsInstanceOfType(expectedLoggedUserId, typeof(int));
        }
    }
}
