using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AnimaniaConsole.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.UnitTests.Services.PostServicesTest
{
    [TestClass]
    public class EditPostTitle_Should
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
        public void Edit_TheTitle_OfThe_Post()
        {
            var editPostModel = new Mock<EditPostModel>();
            editPostModel.Object.Id = 1;
            editPostModel.Object.Title = "New";

            mockContext.Setup(x => x.Posts.Find(It.IsAny<object>())).Returns(mockSet.Object.Where(x => x.Id == editPostModel.Object.Id).First());

            var result = postServices.EditPostTitle(editPostModel.Object);

            Assert.AreEqual(editPostModel.Object.Title, mockSet.Object.Where(x => x.Id == editPostModel.Object.Id).First().Title);
        }
    }
}
