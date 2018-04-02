using AnimaniaConsole.Data;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using AnimaniaConsole.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace AnimaniaConsole.UnitTests.Services.LocationServicesTests
{
    [TestClass]
    public class GetLocationIdByLocationName_Should
    {
        private Mock<IAnimaniaConsoleContext> mockContext;
        private ILocationServices locationService;

        [TestInitialize]
        public void Initialize()
        {
            var data = new List<Location>
            {
                new Location {Id = 1, LocationName = "Sofia"},
                new Location {Id = 2, LocationName = "Plovdiv"},
            };

            var mockSet = data.GetQueryableMockDbSet();

            mockContext = new Mock<IAnimaniaConsoleContext>();
            mockContext.Setup(x => x.Locations).Returns(mockSet.Object);

            locationService = new LocationServices();
        }

        [TestMethod]
        public void Throw_ArgumentException_When_SuchLocationDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                locationService.GetLocationIdByLocationName(mockContext.Object, "Varna"));
        }

        [TestMethod]
        public void Return_LocationId_When_Executed()
        {
            //Act
            var locationId = locationService.GetLocationIdByLocationName(mockContext.Object, "Sofia");

            //Assert
            Assert.AreEqual(1, locationId);
        }

        [TestMethod]
        public void Return_InstanceOfTypeInt_When_Executed()
        {
            //Act
            var locationId = locationService.GetLocationIdByLocationName(mockContext.Object, "Sofia");

            //Assert
            Assert.IsInstanceOfType(locationId, typeof(int));
        }

    }
}
