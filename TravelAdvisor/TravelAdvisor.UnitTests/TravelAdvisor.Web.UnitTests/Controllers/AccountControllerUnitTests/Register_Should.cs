using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using TravelAdvisor.Business.Identity;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Web.Controllers;
using TravelAdvisor.Web.Models.Account;

namespace TravelAdvisor.Web.UnitTests.Controllers.AccountControllerUnitTests
{
	[TestFixture]
	public class Register_Should
	{
		[Test]
		public void ReturnViewWithModel_IfModelstateIsInvalid()
		{
			// Arrange
			var mockedRegistrationService = new Mock<IRegistrationService>();
			var accountController = new AccountController(mockedRegistrationService.Object);

			accountController.ModelState.AddModelError("", "dummy error");

			RegisterViewModel model = new RegisterViewModel();

			// Act & Assert
			accountController
				.WithCallTo(c => c.Register(model))
				.ShouldRenderDefaultView()
				.WithModel(model);
		}

		[Test]
		public void ReturnActionResult_WhenInvoked()
		{
			// Arrange
			var mockedSignInManager = new Mock<ApplicationSignInManager>();
			var mockedRegistrationService = new Mock<IRegistrationService>();
			var accountController = new AccountController(mockedRegistrationService.Object);

			RegisterViewModel model = new RegisterViewModel();

			//Act & Assert
			Assert.IsInstanceOf<Task<ActionResult>>(accountController.Register(model));
		}
	}
}
