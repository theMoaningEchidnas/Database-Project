using System;
using AnimaniaConsole.Data;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AnimaniaConsole.UnitTests.Helpers;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AnimaniaConsole.DTO.Models;

namespace AnimaniaConsole.UnitTests.Services.PostServicesTest
{
    [TestClass]
    public class FindPostById_Should
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
                    Id = 1,
                    Title = "Title No A1",
                    Description = "The shortest post description - part 1",
                    Price = 10,
                    Status = false,
                    UserId = 1
                },
                new Post
                {
                    Id = 2,
                    Title = "Title No A2",
                    Description = "The shortest post description - part 2",
                    Price = 20,
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
        public void Throw_ArgumentNullException_When_PostId_IsNotFound()
        {
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => postServices.FindPostById(100));
        }

        [TestMethod]
        public void Throw_ArgumentException_When_StatusOfFoundPost_IsFalse()
        {
            //Arrange
            var foundPost = new Mock<Post>();
            foundPost.Object.Status = false;
            
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => postServices.FindPostById(1));
        }

        [TestMethod]
        public void ReturnsInstanceOfTypeEditPostModel_When_Executed_WithValidData()
        {
            //Arrange
            var foundPost = new Mock<Post>();
            foundPost.Object.Status = true;
            
            //Act & Assert
            Assert.IsInstanceOfType(postServices.FindPostById(3), typeof(EditPostModel));
        }

        [TestMethod]
        public void ReturnsCorrectPost_When_Executed_WithValidData()
        {
            //Arrange
            var expectedPostsFound = new EditPostModel
                {
                    Id = 3,
                    Title = "Title No 3",
                    Description = "The shortest post description - part 3",
                    Price = 30,
                    UserId = 1
                };

            var foundPost = new Mock<Post>();
            foundPost.Object.Status = true;

            //Act & Assert
            Assert.AreEqual(expectedPostsFound.Id, postServices.FindPostById(3).Id);
        }
    }
}
