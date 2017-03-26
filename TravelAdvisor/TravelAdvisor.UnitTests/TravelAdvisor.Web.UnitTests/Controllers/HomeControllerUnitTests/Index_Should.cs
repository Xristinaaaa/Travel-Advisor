using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Web.Controllers;
using TravelAdvisor.Web.Models.Destinations;

namespace TravelAdvisor.Web.UnitTests.Controllers.HomeControllerUnitTests
{
	[TestFixture]
	public class Index_Should
	{
		[Test]
		public void ReturnDefaultView()
		{
			// Arrange
			var mockedDestinationService = new Mock<IDestinationService>();
			var homeController = new HomeController(mockedDestinationService.Object);

			// Act & Assert
			homeController
				.WithCallTo(c => c.Index())
				.ShouldRenderDefaultView();
		}
	}
}
