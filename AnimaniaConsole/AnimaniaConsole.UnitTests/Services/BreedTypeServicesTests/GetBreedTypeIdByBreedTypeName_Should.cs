using System;
using System.Collections.Generic;
using System.Data.Entity;
using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Contracts;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AnimaniaConsole.UnitTests.Helpers;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnimaniaConsole.UnitTests.Services.BreedTypeServicesTests
{
    [TestClass]
    public class GetBreedTypeIdByBreedTypeName_Should
    {
        private Mock<IAnimaniaConsoleContext> mockContext;
        private IBreedTypeServices breedTypeServices;
        private Mock<IDbSet<BreedType>> mockSet;

        [TestInitialize]
        public void Initialize()
        {
            var data = new List<BreedType>
            {
                new BreedType {Id = 1, BreedTypeName = "Mamarut"},
                new BreedType {Id = 2, BreedTypeName = "Kochugon"},
            };

            mockSet = data.GetQueryableMockDbSet();

            mockContext = new Mock<IAnimaniaConsoleContext>();

            mockContext.Setup(x => x.BreedTypes).Returns(mockSet.Object);

            var stubMapper = new Mock<IMapper>();

            breedTypeServices = new BreedTypeServices(mockContext.Object, stubMapper.Object);
        }

        [TestMethod]
        public void Throw_ArgumentException_When_Executed_With_UnexistentBreedTypeName()
        {
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(()=> breedTypeServices.GetBreedTypeIdByBreedTypeName("Brontozav"));
        }

        [TestMethod]
        public void ReturnsInstanceOfTypeInt_When_Executed_With_Correct_BreedTypeName()
        {
            //Act & Assert
            Assert.IsInstanceOfType(breedTypeServices.GetBreedTypeIdByBreedTypeName("Mamarut"), typeof(int));
        }

        [TestMethod]
        public void ReturnsTheCorrectBreedTypeId_When_Executed_With_Correct_BreedTypeName()
        {
            //Arrange
            var expectedId = 2;
            
            //Act & Assert
            Assert.AreEqual(expectedId, breedTypeServices.GetBreedTypeIdByBreedTypeName("Kochugon"));
        }




    }
}
