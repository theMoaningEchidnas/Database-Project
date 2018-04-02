using System;
using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AnimaniaConsole.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnimaniaConsole.UnitTests.Services.PostServicesTest
{
    [TestClass]
    public class EditPostDescriptionShould
    {
        private Mock<IAnimaniaConsoleContext> mockContext;
        private IPostServices postServices;
        private Mock<IDbSet<Post>> mockSet;

        [TestInitialize]
        public void Initialize()
        {
            var data = new List<Post>
            {
                new Post {Id = 1, Title= "Title No A1", Description = "The shortest post description in the database - part 1"},
                new Post {Id = 2, Title= "Title No A2", Description = "The shortest post description in the database - part 2"},
                new Post {Id = 3, Title= "Title No 3", Description = "The shortest post description in the database - part 3"}
            };

            mockSet = data.GetQueryableMockDbSet();

            mockContext = new Mock<IAnimaniaConsoleContext>();

            mockContext.Setup(x => x.Posts).Returns(mockSet.Object);

            var stubBreedTypeServices = new Mock<IBreedTypeServices>();
            var stubLocationSerivces = new Mock<ILocationServices>();
            var stubAnimalTypeServices = new Mock<IAnimalTypeServices>();

            postServices = new PostServices(mockContext.Object, stubLocationSerivces.Object,
                stubAnimalTypeServices.Object, stubBreedTypeServices.Object);
        }

        [TestMethod]
        public void Returns_InstanceOfTypeString_When_Executed()
        {
            //Arrange
            var editPostModel = new Mock<EditPostModel>();
            editPostModel.Object.Id = 1;
            editPostModel.Object.Description = "New New New New New New NewNew New New New New v New";

            //Act
            var result = postServices.EditPostDescription(editPostModel.Object);

            //Assert
            Assert.IsInstanceOfType(result, typeof(string));
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
            postServices.EditPostDescription(editPostModel.Object);
            mockContext.Object.SaveChanges();

            var actualDescription = mockSet.Object.ToList()[editPostModel.Object.Id-1].Description;

            //Assert
            Assert.AreEqual(expectedDescription, actualDescription);
        }

    }
}
