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
	public class Login_Should
	{
		[Test]
		public void ReturnViewWithReturnUrlInViewBag()
		{
			// Arrange
			var mockedRegistrationService = new Mock<IRegistrationService>();
			var accountController = new AccountController(mockedRegistrationService.Object);

			string returnUrl = "url";

			// Act 
			accountController
				.WithCallTo(c => c.Login(returnUrl))
				.ShouldRenderDefaultView();

			//Assert
			Assert.AreEqual(returnUrl, accountController.ViewBag.ReturnUrl);
		}

		[Test]
		public void ReturnViewWithModel_IfModelstateIsInvalid()
		{
			// Arrange
			var mockedRegistrationService = new Mock<IRegistrationService>();
			var accountController = new AccountController(mockedRegistrationService.Object);

			accountController.ModelState.AddModelError("", "dummy error");

			LoginViewModel model = new LoginViewModel();
			string returnUrl = "url";

			// Act & Assert
			accountController
				.WithCallTo(c => c.Login(model, returnUrl))
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

			LoginViewModel model = new LoginViewModel();
			string returnUrl = "url";
			
			//Act & Assert
			Assert.IsInstanceOf<Task<ActionResult>>(accountController.Login(model, returnUrl));
		}
	}
}
