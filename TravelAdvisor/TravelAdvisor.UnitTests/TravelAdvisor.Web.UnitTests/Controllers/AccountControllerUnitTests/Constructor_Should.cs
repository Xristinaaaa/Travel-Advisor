using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Web.Controllers;

namespace TravelAdvisor.Web.UnitTests.Controllers.AccountControllerUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateAccountController_WhenParamsAreValid()
		{
			// Arrange
			var mockedRegistrationService = new Mock<IRegistrationService>();
			var accountController = new AccountController(mockedRegistrationService.Object);

			//Act & Assert
			Assert.That(accountController, Is.InstanceOf<AccountController>());
		}

		[Test]
		public void ThrowNullException_WhenRegistrationServiceIsNull()
		{
			//Arrange
			Mock<IRegistrationService> mockedRegistrationService = null;

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new AccountController(mockedRegistrationService.Object));
		}
	}
}
