using NUnit.Framework;
using TestStack.FluentMVCTesting;
using TravelAdvisor.Web.Controllers;

namespace TravelAdvisor.Web.UnitTests.Controllers.ErrorPagesControllerUnitTests
{
	[TestFixture]
	public class ErrorPage404_Should
	{
		[Test]
		public void ReturnDefaultView()
		{
			//Arrange
			var controller = new ErrorPagesController();

			//Act & Assert
			controller.WithCallTo(c => c.Page404())
				.ShouldRenderView("Page404");
		}
	}
}
