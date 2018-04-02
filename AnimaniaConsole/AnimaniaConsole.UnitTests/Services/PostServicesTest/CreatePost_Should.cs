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

            effortContext.Locations.Add(location);
            effortContext.AnimalTypes.Add(type);
            effortContext.BreedTypes.Add(breed);
            effortContext.Users.Add(user);
            effortContext.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Mapper.Reset();
        }

        [TestMethod]
        public void Create_Post_WhenArguments_AreValid()
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
                .Returns(1);
            animalTypeServicesMock
                .Setup(a => a.GetAnimalTypeIdByAnimalTypeName(It.IsAny<IAnimaniaConsoleContext>(), It.IsAny<string>()))
                .Returns(1);
            breedTypeServicesMock
                .Setup(b => b.GetBreedTypeIdByBreedTypeName(It.IsAny<string>()))
                .Returns(1);

            postService.CreatePost(createPostModel, 1);

            Assert.AreEqual(1, effortContext.Posts.Count());
        }

        [TestMethod]
        public void Invoke_GetLocationIdByLocationName_From_LocationServices()
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
                .Returns(1).Verifiable();
            animalTypeServicesMock
                .Setup(a => a.GetAnimalTypeIdByAnimalTypeName(It.IsAny<IAnimaniaConsoleContext>(), It.IsAny<string>()))
                .Returns(1);
            breedTypeServicesMock
                .Setup(b => b.GetBreedTypeIdByBreedTypeName(It.IsAny<string>()))
                .Returns(1);

            postService.CreatePost(createPostModel, 1);

            locationServicesMock.Verify(x => x.GetLocationIdByLocationName(It.IsAny<IAnimaniaConsoleContext>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Invoke_GetAnimalTypeIdByAnimalTypeName_From_AnimalTypeServices()
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
                .Returns(1);
            animalTypeServicesMock
                .Setup(a => a.GetAnimalTypeIdByAnimalTypeName(It.IsAny<IAnimaniaConsoleContext>(), It.IsAny<string>()))
                .Returns(1).Verifiable();
            breedTypeServicesMock
                .Setup(b => b.GetBreedTypeIdByBreedTypeName(It.IsAny<string>()))
                .Returns(1);

            postService.CreatePost(createPostModel, 1);

            animalTypeServicesMock.Verify(x => x.GetAnimalTypeIdByAnimalTypeName(It.IsAny<IAnimaniaConsoleContext>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Invoke_GetBreedTypeIdByBreedTypeName_From_BreedTypeServices()
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
                .Returns(1);    
            animalTypeServicesMock
                .Setup(a => a.GetAnimalTypeIdByAnimalTypeName(It.IsAny<IAnimaniaConsoleContext>(), It.IsAny<string>()))
                .Returns(1);
            breedTypeServicesMock
                .Setup(b => b.GetBreedTypeIdByBreedTypeName(It.IsAny<string>()))
                .Returns(1).Verifiable();

            postService.CreatePost(createPostModel, 1);

            breedTypeServicesMock.Verify(x => x.GetBreedTypeIdByBreedTypeName(It.IsAny<string>()), Times.Once);
        }
    }
}