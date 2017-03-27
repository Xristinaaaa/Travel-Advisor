using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Controllers;

namespace TravelAdvisor.Web.UnitTests.Controllers.ListTripsControllerUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateListTripsController_WhenParamsAreValid()
		{
			// Arrange
			var mockedTripService = new Mock<ITripService>();
			var mockedMappingService = new Mock<IMappingService>();
			var listTripsController = new ListTripsController(mockedTripService.Object, mockedMappingService.Object);

			//Act & Assert
			Assert.That(listTripsController, Is.InstanceOf<ListTripsController>());
		}

		[Test]
		public void ThrowNullException_WhenTripServiceIsNull()
		{
			//Arrange
			Mock<ITripService> mockedRegistrationService = null;
			var mockedMappingService = new Mock<IMappingService>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new ListTripsController(mockedRegistrationService.Object, mockedMappingService.Object));
		}

		[Test]
		public void ThrowNullException_WhenMappingServiceIsNull()
		{
			//Arrange
			Mock<IMappingService> mockedMappingService = null;
			var mockedRegistrationService = new Mock<ITripService>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new ListTripsController(mockedRegistrationService.Object, mockedMappingService.Object));
		}
	}
}
