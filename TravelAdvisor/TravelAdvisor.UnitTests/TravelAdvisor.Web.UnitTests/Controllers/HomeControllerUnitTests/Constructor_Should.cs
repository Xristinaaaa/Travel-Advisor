using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Web.Controllers;

namespace TravelAdvisor.Web.UnitTests.Controllers.HomeControllerUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateAccountController_WhenParamsAreValid()
		{
			// Arrange
			var mockedDestinationService = new Mock<IDestinationService>();
			var homeController = new HomeController(mockedDestinationService.Object);

			//Act & Assert
			Assert.That(homeController, Is.InstanceOf<HomeController>());
		}

		[Test]
		public void ThrowNullException_WhenRegistrationServiceIsNull()
		{
			//Arrange
			Mock<IDestinationService> mockedRegistrationService = null;

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new HomeController(mockedRegistrationService.Object));
		}
	}
}
