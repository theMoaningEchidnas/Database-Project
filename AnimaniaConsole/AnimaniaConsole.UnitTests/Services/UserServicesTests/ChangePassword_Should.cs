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
            var stubUserSessionModel = new Mock<IUserSessionModel>();
            var stubAnimalTypeServices = new Mock<IAnimalTypeServices>();

            userServices = new UserServices(mockContext.Object, stubMapper.Object, stubUserSessionModel.Object);
        }

        [TestMethod]
        public void Returns_InstanceOfTypeString_When_Executed()
        {
            //Arrange
            var editPostModel = new Mock<EditPostModel>();
            editPostModel.Object.Id = 1;
            editPostModel.Object.Description = "New New New New New New NewNew New New New New v New";

            //Act
            //var result = userServices.EditPostDescription(editPostModel.Object);

            //Assert
            //Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void EditedPostDescription_IsSavedInDatabase_When_Executed()
        {
            //Arrange
            var editPostModel = new Mock<EditPostModel>();
            editPostModel.Object.Id = 2;
            var expectedDescription = "New New New New New New NewNew New New New New v New" + DateTime.Now;
            editPostModel.Object.Description = expectedDescription;


            //Act
            //userServices.EditPostDescription(editPostModel.Object);
            mockContext.Object.SaveChanges();

            //var actualDescription = mockSet.Object.ToList()[editPostModel.Object.Id - 1].Description;

            //Assert
            //Assert.AreEqual(expectedDescription, actualDescription);
        }

    }
}
