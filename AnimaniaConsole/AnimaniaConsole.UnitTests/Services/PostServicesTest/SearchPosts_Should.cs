using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnimaniaConsole.UnitTests.Services.PostServicesTest
{
    [TestClass]
    public class SearchPosts_Should
    {
        private Mock<IAnimaniaConsoleContext> mockContext;
        private IPostServices postServices;

        [TestInitialize]
        public void Initialize()
        {
            var data = new List<Post>
            {
                new Post {Id = 1, Title= "Title No A1", Description = "The shortest post description in the database - part 1"},
                new Post {Id = 2, Title= "Title No A2", Description = "The shortest post description in the database - part 2"},
                new Post {Id = 3, Title= "Title No 3", Description = "The shortest post description in the database - part 3"},
            }.AsQueryable();

            var mockSet = new Mock<IDbSet<Post>>();
            mockSet.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            mockContext = new Mock<IAnimaniaConsoleContext>();
            mockContext.Setup(x => x.Posts).Returns(mockSet.Object);

            var stubBreedTypeServices = new Mock<IBreedTypeServices>();
            var stubLocationSerivces = new Mock<ILocationServices>();
            var stubAnimalTypeServices = new Mock<IAnimalTypeServices>();

            //initialize the AutoMapper
            Mapper.Initialize(config => { });


            postServices = new PostServices(mockContext.Object, stubLocationSerivces.Object,
                stubAnimalTypeServices.Object, stubBreedTypeServices.Object);
        }


        [TestMethod]
        public void ReturnInstanceOfTypeIQueriable_When_Executed()
        {
            //Act
            var foundPosts = postServices.SearchPosts("1");


            //Assert
            Assert.IsInstanceOfType(foundPosts, typeof(IEnumerable<PostModel>));

            //Cleanup
            Mapper.Reset();

        }

        [TestMethod]
        public void ReturnCorrectResult_When_Executed()
        {
            //Arrange
            var expectedPostsFound = new List<PostModel>
            {
                new PostModel()
                {
                    Id = 1,
                    Title = "Title No A1",
                    Description = "The shortest post description in the database - part 1"
                },
                new PostModel()
                {
                    Id = 2,
                    Title = "Title No A2",
                    Description = "The shortest post description in the database - part 2"
                }
            };

            //Act
            var actualPostsFound = postServices.SearchPosts("A").ToList();

            //Assert
            CollectionAssert.AreEqual(expectedPostsFound, actualPostsFound, new PostModelComparer());

            //Cleanup
            Mapper.Reset();
        }


    }
}
