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

		[Test]
		public void ReturnViewWithModel()
		{
			// Arrange
			var mockedDestinationService = new Mock<IDestinationService>();
			var homeController = new HomeController(mockedDestinationService.Object);

			// Act
			var result = new List<Destination>() { new Destination(), new Destination() };
			mockedDestinationService.Setup(x => x.GetDestinations(0, 6))
				.Returns(result.AsQueryable());

			var destinationsModel = new DestinationsListViewModel();

			// Assert
			homeController
				.WithCallTo(c => c.Index())
				.ShouldRenderDefaultView()
				.WithModel(destinationsModel);
		}
	}
}
