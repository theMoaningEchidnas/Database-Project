using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AnimaniaConsole.UnitTests.Services.PostServicesTest
{
    [TestClass]
    public class CreatePost_Should
    {
        private Mock<ILocationServices> locationServicesMock;
        private Mock<IAnimalTypeServices> animalTypeServicesMock;
        private Mock<IBreedTypeServices> breedTypeServicesMock;
        private AnimaniaConsoleContext effortContext;
        private PostServices postService;

        [ClassInitialize]
        public static void InitilizeAutomapper(TestContext context)
        {
            //Mapper.Initialize(config => {
            //    config.CreateMap<CreatePostModel, Post>().ReverseMap();
            //});
        }


        [TestInitialize]
        public void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<CreatePostModel, Post>().ReverseMap();
            });

            locationServicesMock = new Mock<ILocationServices>();
            animalTypeServicesMock = new Mock<IAnimalTypeServices>();
            breedTypeServicesMock = new Mock<IBreedTypeServices>();
            effortContext = new AnimaniaConsoleContext(Effort.DbConnectionFactory.CreateTransient());
            postService = new PostServices(effortContext, locationServicesMock.Object, animalTypeServicesMock.Object, breedTypeServicesMock.Object);
            User user = new User()
            {
                Id = 0,
                UserName = "Tester",
                Password = "Password123",
                Email = "test@test.com"
            };
            effortContext.Users.Add(user);
            effortContext.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Mapper.Reset();
        }

        [TestMethod]
        public void Pass_TheRight_Argument_ToLocationServices()
        {
            var createPostModel = new CreatePostModel()
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

            locationServicesMock
                .Setup(l => l.GetLocationIdByLocationName(It.IsAny<IAnimaniaConsoleContext>(), It.IsAny<string>()))
                .Returns(0);
            animalTypeServicesMock
                .Setup(a => a.GetAnimalTypeIdByAnimalTypeName(It.IsAny<IAnimaniaConsoleContext>(), It.IsAny<string>()))
                .Returns(0);
            breedTypeServicesMock
                .Setup(b => b.GetBreedTypeIdByBreedTypeName(It.IsAny<string>()))
                .Returns(0);

            postService.CreatePost(createPostModel, 0);

        }
    }
}
