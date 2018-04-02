using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Contracts;
using AnimaniaConsole.Services.Services;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnimaniaConsole.UnitTests.Services.UserServicesTests
{
    [TestClass]
    public class ValidateUser_Should
    {
        [TestMethod]
        public void ReturnsInstanceOfTypeBool_When_Executed()
        {
            //Arrange
            var stubContext = new Mock<IAnimaniaConsoleContext>();
            var stubMapper = new Mock<IMapper>();
            var stubUserSessionModel = new Mock<IUserSessionModel>();

            stubUserSessionModel.Setup(x => x.Id).Returns(It.IsAny<int>());
            stubUserSessionModel.Setup(x => x.UserName).Returns(It.IsAny<string>());

            var userServices = new UserServices(stubContext.Object, stubMapper.Object, stubUserSessionModel.Object);

            //Act
            var result = userServices.ValidateUser();

            //Assert
            Assert.IsInstanceOfType(result,typeof(bool));

        }

        [TestMethod]
        public void ReturnFalseIfSessionIdIs0_When_Executed()
        {
            //Arrange
            var stubContext = new Mock<IAnimaniaConsoleContext>();
            var stubMapper = new Mock<IMapper>();
            var stubUserSessionModel = new Mock<IUserSessionModel>();

            stubUserSessionModel.Setup(x => x.Id).Returns(0);
            stubUserSessionModel.Setup(x => x.UserName).Returns(It.IsAny<string>());

            var userServices = new UserServices(stubContext.Object, stubMapper.Object, stubUserSessionModel.Object);

            //Act
            var result = userServices.ValidateUser();

            //Assert
            Assert.AreEqual(false,result);
        }

        [TestMethod]
        public void ReturnFalseIfSessionUserNameIsNull_When_Executed()
        {
            //Arrange
            var stubContext = new Mock<IAnimaniaConsoleContext>();
            var stubMapper = new Mock<IMapper>();
            var stubUserSessionModel = new Mock<IUserSessionModel>();

            stubUserSessionModel.Setup(x => x.Id).Returns(It.IsAny<int>());
            stubUserSessionModel.Setup(x => x.UserName).Returns(string.Empty);

            var userServices = new UserServices(stubContext.Object, stubMapper.Object, stubUserSessionModel.Object);

            //Act
            var result = userServices.ValidateUser();

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ReturnTrueIfThereIsLoggedUser_When_Executed()
        {
            //Arrange
            var stubContext = new Mock<IAnimaniaConsoleContext>();
            var stubMapper = new Mock<IMapper>();
            var stubUserSessionModel = new Mock<IUserSessionModel>();

            stubUserSessionModel.Setup(x => x.Id).Returns(1);
            stubUserSessionModel.Setup(x => x.UserName).Returns("UserName");

            var userServices = new UserServices(stubContext.Object, stubMapper.Object, stubUserSessionModel.Object);

            //Act
            var result = userServices.ValidateUser();

            //Assert
            Assert.AreEqual(true, result);
        }

    }
    }
