using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Controllers;

namespace TravelAdvisor.Web.UnitTests.Controllers.ManageControllerUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateListManageController_WhenParamsAreValid()
		{
			// Arrange
			var mockedUserService = new Mock<IUserService>();
			var mockedMappingService = new Mock<IMappingService>();
			var mockedDestinationService = new Mock<IDestinationService>();
			var mockedTripService = new Mock<ITripService>();
			var manageController = new ManageController(mockedUserService.Object, mockedMappingService.Object,
				mockedDestinationService.Object, mockedTripService.Object);

			//Act & Assert
			Assert.That(manageController, Is.InstanceOf<ManageController>());
		}

		[Test]
		public void ThrowNullException_WhenTripServiceIsNull()
		{
			// Arrange
			var mockedUserService = new Mock<IUserService>();
			var mockedMappingService = new Mock<IMappingService>();
			var mockedDestinationService = new Mock<IDestinationService>();
			Mock<ITripService> mockedTripService = null;

			//Act & Assert
			Assert.Throws<NullReferenceException>(
				() => new ManageController(mockedUserService.Object, mockedMappingService.Object, mockedDestinationService.Object, mockedTripService.Object));
		}

		[Test]
		public void ThrowNullException_WhenMappingServiceIsNull()
		{
			//Arrange
			var mockedUserService = new Mock<IUserService>();
			Mock<IMappingService> mockedMappingService = null;
			var mockedDestinationService = new Mock<IDestinationService>();
			var mockedTripService = new Mock<ITripService>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(
				() => new ManageController(mockedUserService.Object, mockedMappingService.Object, mockedDestinationService.Object, mockedTripService.Object));
		}

		[Test]
		public void ThrowNullException_WhenDestinationServiceIsNull()
		{
			//Arrange
			var mockedUserService = new Mock<IUserService>();
			var mockedMappingService = new Mock<IMappingService>();
			Mock<IDestinationService> mockedDestinationService = null;
			var mockedTripService = new Mock<ITripService>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(
				() => new ManageController(mockedUserService.Object, mockedMappingService.Object, mockedDestinationService.Object, mockedTripService.Object));
		}

		[Test]
		public void ThrowNullException_WhenUserServiceIsNull()
		{
			//Arrange
			Mock<IUserService> mockedUserService = null;
			var mockedMappingService = new Mock<IMappingService>();
			var mockedDestinationService = new Mock<IDestinationService>();
			var mockedTripService = new Mock<ITripService>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(
				() => new ManageController(mockedUserService.Object, mockedMappingService.Object, mockedDestinationService.Object, mockedTripService.Object));
		}
	}
}
