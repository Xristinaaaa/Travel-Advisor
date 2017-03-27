using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Areas.Admin.Controllers;

namespace TravelAdvisor.Web.UnitTests.Admin.Controllers.DestinationsControllerUnitTests
{
	[TestFixture]
	public class Constructor_Shouldcs
	{
		[Test]
		public void CreateDestinationsController_WhenParamsAreValid()
		{
			// Arrange
			var mockedIDestinationService = new Mock<IDestinationService>();
			var mockedMappingService = new Mock<IMappingService>();
			var mockedImageService = new Mock<IImageService>();
			var destinationsController = new DestinationsController(mockedIDestinationService.Object, mockedMappingService.Object, mockedImageService.Object);

			//Act & Assert
			Assert.That(destinationsController, Is.InstanceOf<DestinationsController>());
		}

		[Test]
		public void ThrowNullException_WhenDestinationServiceIsNull()
		{
			//Arrange
			Mock<IDestinationService> mockedIDestinationService = null;
			var mockedMappingService = new Mock<IMappingService>();
			var mockedImageService = new Mock<IImageService>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new DestinationsController(mockedIDestinationService.Object, mockedMappingService.Object, mockedImageService.Object));
		}
	}
}
