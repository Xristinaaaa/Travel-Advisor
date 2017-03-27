using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Areas.Admin.Controllers;

namespace TravelAdvisor.Web.UnitTests.Admin.Controllers.TripsControllerUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateTripsController_WhenParamsAreValid()
		{
			// Arrange
			var mockedIDestinationService = new Mock<IDestinationService>();
			var mockedTripService = new Mock<ITripService>();
			var mockedMappingService = new Mock<IMappingService> ();
			var mockedImageService = new Mock<IImageService>();
			var tripsController = new TripsController(mockedTripService.Object, mockedIDestinationService.Object,
				mockedMappingService.Object, mockedImageService.Object);

			//Act & Assert
			Assert.That(tripsController, Is.InstanceOf<TripsController>());
		}

		[Test]
		public void ThrowNullException_WhenDestinationServiceIsNull()
		{
			//Arrange
			Mock<IDestinationService> mockedIDestinationService = null;
			var mockedTripService = new Mock<ITripService>();
			var mockedMappingService = new Mock<IMappingService>();
			var mockedImageService = new Mock<IImageService>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new TripsController(mockedTripService.Object, mockedIDestinationService.Object,
				mockedMappingService.Object, mockedImageService.Object));
		}

		[Test]
		public void ThrowNullException_WhenTripServiceIsNull()
		{
			//Arrange
			var mockedIDestinationService = new Mock<IDestinationService>();
			Mock<ITripService> mockedTripService = null;
			var mockedMappingService = new Mock<IMappingService>();
			var mockedImageService = new Mock<IImageService>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new TripsController(mockedTripService.Object, mockedIDestinationService.Object,
				mockedMappingService.Object, mockedImageService.Object));
		}

		[Test]
		public void ThrowNullException_WhenMappingServiceIsNull()
		{
			//Arrange
			var mockedIDestinationService = new Mock<IDestinationService>();
			var mockedTripService = new Mock<ITripService>();
			Mock<IMappingService> mockedMappingService = null;
			var mockedImageService = new Mock<IImageService>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new TripsController(mockedTripService.Object, mockedIDestinationService.Object,
				mockedMappingService.Object, mockedImageService.Object));
		}

		[Test]
		public void ThrowNullException_WhenImageServiceIsNull()
		{
			//Arrange
			var mockedIDestinationService = new Mock<IDestinationService>();
			var mockedTripService = new Mock<ITripService>();
			var mockedMappingService = new Mock<IMappingService>();
			Mock<IImageService> mockedImageService = null;

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new TripsController(mockedTripService.Object, mockedIDestinationService.Object,
				mockedMappingService.Object, mockedImageService.Object));
		}
	}
}
