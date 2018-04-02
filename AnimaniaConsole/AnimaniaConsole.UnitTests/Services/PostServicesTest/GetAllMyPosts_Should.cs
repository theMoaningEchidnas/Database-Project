using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AutoMapper;
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
        [TestInitialize]
        public void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<CreatePostModel, Post>().ReverseMap();
            });

        }
        [TestCleanup]
        public void CleanUp()
        {
            Mapper.Reset();

        }

        [TestMethod]
        public void Should_Return_The_Right_Collection()
        {


            var ContextMock = new AnimaniaConsoleContext(Effort.DbConnectionFactory.CreateTransient());

            var LocationMock = new Mock<ILocationServices>();
            var AnimalTypeMock = new Mock<IAnimalTypeServices>();
            var BreedTypeMock = new Mock<IBreedTypeServices>();

            postServices = new PostServices(ContextMock, LocationMock.Object, AnimalTypeMock.Object, BreedTypeMock.Object);
            User user = new User()
            {
                Id = 1,
                UserName = "Tester",
                Password = "Password123",
                Email = "test@test.com"
            };
            BreedType breed = new BreedType()
            {
                BreedTypeName = "TestBreed",
                AnimalTypeId = 1
            };
            AnimalType type = new AnimalType()
            {
                AnimalTypeName = "TestAnimalTypeName",


            };
            Location location = new Location()
            {
                LocationName = "TestLocation",
            };
            var animal = new Animal
            {
                AnimalName = "TestAnimalTypeName",
                Birthday = DateTime.Now,
                AnimalTypeId = 1,
                BreedTypeId = 1,
                LocationId = 1,
                UserId = 1
            };

            var post = new CreatePostModel()
            {
                Title = "1234567890",
                Description = "12345678901234567890",
                Status = true,
                Price = 12.0M,
                LocationName = location.LocationName,
                AnimalTypeName = "TestAnimalTypeName",
                BreedTypeName = "TestBreed",
                AnimalName = "TestAnimalName",
                Birthday = DateTime.Now
            };



            Assert.IsInstanceOfType(postServices.GetAllMyPosts(1), typeof(IEnumerable<PostModel>));

        }
       

    }
}
