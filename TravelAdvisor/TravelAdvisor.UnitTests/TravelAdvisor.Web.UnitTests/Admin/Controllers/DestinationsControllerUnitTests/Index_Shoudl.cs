using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Areas.Admin.Controllers;

namespace TravelAdvisor.Web.UnitTests.Admin.Controllers.DestinationsControllerUnitTests
{
	[TestFixture]
	public class Index_Shoudl
	{
		[Test]
		public void ReturnDefaultView()
		{
			// Arrange
			var mockedIDestinationService = new Mock<IDestinationService>();
			var mockedMappingService = new Mock<IMappingService>();
			var mockedImageService = new Mock<IImageService>();
			var destinationsController = new DestinationsController(mockedIDestinationService.Object, mockedMappingService.Object, mockedImageService.Object);

			//Act & Assert
			destinationsController
				.WithCallTo(c => c.Index())
				.ShouldRenderDefaultView();
		}
	}
}
