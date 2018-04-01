using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AnimaniaConsole.UnitTests.Helpers;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AnimaniaConsole.DTO.Contracts;

namespace AnimaniaConsole.UnitTests.Services.UserServicesTests
{
    [TestClass]
    public class ChangePassword_Should
    {

        private Mock<IAnimaniaConsoleContext> mockContext;
        private IUserServices userServices;
        private Mock<IDbSet<User>> mockSet;
        private Mock<IUserSessionModel> stubUserSessionModel;

        [TestInitialize]
        public void Initialize()
        {
            var data = new List<User>
            {
                new User {Id = 1, UserName = "UserName1", Password = "Password123Abc123Abc" },
                new User {Id = 2, UserName = "UserName2", Password = "Password123Abc123Abb" },
                new User {Id = 3, UserName = "UserName3", Password = "Password123Abc123Aba" },
            };

            mockSet = data.GetQueryableMockDbSet();

            mockContext = new Mock<IAnimaniaConsoleContext>();

            mockContext.Setup(x => x.Users).Returns(mockSet.Object);

            var stubMapper = new Mock<IMapper>();
            stubUserSessionModel = new Mock<IUserSessionModel>();
        
            userServices = new UserServices(mockContext.Object, stubMapper.Object, stubUserSessionModel.Object);
        }

        [TestMethod]
        public void ChangesThePasswordInTheDatabase_When_Executed()
        {
            //Arrange
            stubUserSessionModel.Setup(x => x.Id).Returns(2);

            //Act
            userServices.ChangePassword("NewPassword123");
            mockContext.Object.SaveChanges();

            var actualDescription = mockSet.Object.SingleOrDefault(x=>x.Id == 2).Password;

            //Assert
            Assert.AreEqual("NewPassword123", actualDescription);
        }

    }
}
