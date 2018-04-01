using AnimaniaConsole.Data;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnimaniaConsole.UnitTests.Services.AnimalTypeServicesTests
{
    [TestClass]
    public class GetAnimalTypeIdByAnimalTypeName_Should
    {

        private Mock<IAnimaniaConsoleContext> mockContext;
        private IAnimalTypeServices animalTypeService;

        [TestInitialize]
        public void Initialize()
        {
            var data = new List<AnimalType>
            {
                new AnimalType {Id = 1, AnimalTypeName = "dog"},
                new AnimalType {Id = 2, AnimalTypeName = "cat"},
            }.AsQueryable();

            var mockSet = new Mock<IDbSet<AnimalType>>();
            mockSet.As<IQueryable<AnimalType>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AnimalType>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AnimalType>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AnimalType>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            mockContext = new Mock<IAnimaniaConsoleContext>();
            mockContext.Setup(x => x.AnimalTypes).Returns(mockSet.Object);

            animalTypeService = new AnimalTypeServices();
        }

        [TestMethod]
        public void Throw_ArgumentException_When_SuchAnimalTypeDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                animalTypeService.GetAnimalTypeIdByAnimalTypeName(mockContext.Object, "fish"));
        }

        [TestMethod]
        public void Return_AnimalTypeId_When_Executed()
        {
            //Act
            var animalTypeId = animalTypeService.GetAnimalTypeIdByAnimalTypeName(mockContext.Object, "dog");

            //Assert
            Assert.AreEqual(1, animalTypeId);
        }

        [TestMethod]
        public void Return_InstanceOfTypeByte_When_Executed()
        {
            //Act
            var animalTypeId = animalTypeService.GetAnimalTypeIdByAnimalTypeName(mockContext.Object, "dog");

            //Assert
            Assert.IsInstanceOfType(animalTypeId, typeof(byte));
        }
    }
}
