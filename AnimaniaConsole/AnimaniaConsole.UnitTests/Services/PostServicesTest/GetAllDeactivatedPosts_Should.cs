using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AnimaniaConsole.UnitTests.Helpers;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace AnimaniaConsole.UnitTests.Services.PostServicesTest
{
    [TestClass]
    public class GetAllDeactivatedPosts_Should
    {
        private Mock<IAnimaniaConsoleContext> mockContext;
        private IPostServices postServices;


        [TestInitialize]
        public void Initialize()
        {
            Mapper.Initialize(config => { });


            var data = new List<Post>
            {
                new Post
                {
                    Id = 1, Title= "Title No A1",
                    Description = "The shortest post description - part 1",
                    Price = 10, 
                    Status = false,
                    UserId = 1
                },
                new Post
                {
                    Id = 2,
                    Title = "Title No A2",
                    Description = "The shortest post description - part 2", Price = 20,
                    Status = false,
                    UserId = 2

                },
                new Post
                {
                    Id = 3,
                    Title = "Title No 3",
                    Description = "The shortest post description - part 3",
                    Price = 30,
                    Status = true,
                    UserId = 1
                }
            };

            var mockSet = data.GetQueryableMockDbSet();

            mockContext = new Mock<IAnimaniaConsoleContext>();

            mockContext.Setup(x => x.Posts).Returns(mockSet.Object);

            var stubBreedTypeServices = new Mock<IBreedTypeServices>();
            var stubLocationSerivces = new Mock<ILocationServices>();
            var stubAnimalTypeServices = new Mock<IAnimalTypeServices>();

            postServices = new PostServices(mockContext.Object, stubLocationSerivces.Object,
                stubAnimalTypeServices.Object, stubBreedTypeServices.Object);

        }

        [TestCleanup]
        public void Cleanup()
        {
            Mapper.Reset();
        }

        [TestMethod]
        public void ReturnInstanceOfTypeListIfCorrectUserIsProvided_When_Executed()
        {
            //Act
            var foundPosts = postServices.GetAllDeactivatedPosts(1);

            //Assert
            Assert.IsInstanceOfType(foundPosts, typeof(List<PostModel>));

        }

        [TestMethod]
        public void ReturnAllTheCorrectDeactivatedPosts_When_Executed()
        {
            //Arrange
            var expectedPostsFound = new List<PostModel>
            {
                new PostModel
                {
                    Id = 1,
                    Title = "Title No A1",
                    Description = "The shortest post description - part 1",
                    Price = 10,
                    Status = false,
                    UserId = 1
                }
            };

            //Act
            var actualPostsFound = postServices.GetAllDeactivatedPosts(1).ToList();

            //Assert
            CollectionAssert.AreEqual(expectedPostsFound, actualPostsFound, new PostModelComparer());

        }


    }
}
