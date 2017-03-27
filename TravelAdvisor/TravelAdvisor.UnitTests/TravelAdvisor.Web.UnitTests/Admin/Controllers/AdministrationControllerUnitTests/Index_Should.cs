using NUnit.Framework;
using TestStack.FluentMVCTesting;
using TravelAdvisor.Web.Areas.Admin.Controllers;

namespace TravelAdvisor.Web.UnitTests.Admin.Controllers.AdministrationControllerUnitTests
{
	[TestFixture]
	public class Index_Should
	{
		[Test]
		public void ReturnDefaultView()
		{
			//Arrange
			var adminController = new AdministrationController();

			//Act & Assert
			adminController
				.WithCallTo(c => c.Index())
				.ShouldRenderDefaultView();
		}
	}
}
