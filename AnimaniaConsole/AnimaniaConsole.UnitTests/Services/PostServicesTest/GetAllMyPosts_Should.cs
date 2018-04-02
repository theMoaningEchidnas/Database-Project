using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.UnitTests.Services.PostServicesTest
{
    [TestClass]
    public class GetAllMyPosts_Should
    {
        private IPostServices postServices;
   
        [TestMethod]
        public void Should_Return_The_Right_Collection()
        {

            var ContextMock = new AnimaniaConsoleContext(Effort.DbConnectionFactory.CreateTransient());

            var LocationMock = new Mock<ILocationServices>();
            var AnimalTypeMock = new Mock<IAnimalTypeServices>();
            var BreedTypeMock = new Mock<IBreedTypeServices>();

            postServices = new PostServices(ContextMock, LocationMock.Object, AnimalTypeMock.Object, BreedTypeMock.Object);

            var post = new CreatePostModel()
            {
                Title = "1234567890",
                Description = "12345678901234567890",
                Status = true,
                LocationName = "TestLocation",
                AnimalTypeName = "TestAnimalTypeName",
                BreedTypeName = "TestBreed",
                AnimalName = "TestAnimalName",
                Birthday = DateTime.Now
            };
            User user = new User()
            {
                Id = 1,
                UserName = "Tester",
                Password = "Password123",
                Email = "test@test.com"
            };
            postServices.CreatePost(post, 1);

            Assert.IsInstanceOfType(postServices.GetAllMyPosts(1), typeof(IEnumerable<PostModel>));

        }
     
    }
}
