using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Areas.Admin.Controllers;
using TravelAdvisor.Web.Areas.Admin.Models.Destinations;

namespace TravelAdvisor.Web.UnitTests.Admin.Controllers.DestinationsControllerUnitTests
{
	[TestFixture]
	public class Create_Should
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
				.WithCallTo(c => c.Create())
				.ShouldRenderDefaultView();
		}

		[Test]
		public void ReturnViewWithModel()
		{
			// Arrange
			var mockedIDestinationService = new Mock<IDestinationService>();
			var mockedMappingService = new Mock<IMappingService>();
			var mockedImageService = new Mock<IImageService>();
			var destinationsController = new DestinationsController(mockedIDestinationService.Object, mockedMappingService.Object, mockedImageService.Object);

			destinationsController.ModelState.AddModelError("", "dummy error");

			DestinationViewModel model = new DestinationViewModel();

			// Act & Assert
			destinationsController
				.WithCallTo(c => c.Create(model))
				.ShouldRenderDefaultView()
				.WithModel(model);
		}

		//[Test]
		//public void RedirectToAction()
		//{
		//	// Arrange
		//	var mockedIDestinationService = new Mock<IDestinationService>();
		//	var mockedMappingService = new Mock<IMappingService>();
		//	var mockedImageService = new Mock<IImageService>();
		//	var destinationsController = new DestinationsController(mockedIDestinationService.Object, mockedMappingService.Object, mockedImageService.Object);

		//	DestinationViewModel model = new DestinationViewModel();

		//	// Act & Assert
		//	destinationsController
		//		.WithCallTo(c => c.Create(model))
		//		.ShouldRedirectTo("/Admin/Administration");
		//}
	}
}
