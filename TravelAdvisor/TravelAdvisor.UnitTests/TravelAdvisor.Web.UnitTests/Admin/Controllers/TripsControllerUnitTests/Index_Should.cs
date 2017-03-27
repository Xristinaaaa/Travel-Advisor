using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Areas.Admin.Controllers;
using TravelAdvisor.Web.Areas.Admin.Models.Trips;

namespace TravelAdvisor.Web.UnitTests.Admin.Controllers.TripsControllerUnitTests
{
	[TestFixture]
	public class Index_Should
	{
		[Test]
		public void ReturnDefaultView()
		{
			// Arrange
			var mockedIDestinationService = new Mock<IDestinationService>();
			var mockedTripService = new Mock<ITripService>();
			var mockedMappingService = new Mock<IMappingService>();
			var mockedImageService = new Mock<IImageService>();
			var tripsController = new TripsController(mockedTripService.Object, mockedIDestinationService.Object,
				mockedMappingService.Object, mockedImageService.Object);

			//Act & Assert
			tripsController
				.WithCallTo(c => c.Index())
				.ShouldRenderDefaultView();
		}

		[Test]
		public void ReturnDefaultViewWithViewbagOfCountries()
		{
			// Arrange
			var mockedIDestinationService = new Mock<IDestinationService>();
			var mockedTripService = new Mock<ITripService>();
			var mockedMappingService = new Mock<IMappingService>();
			var mockedImageService = new Mock<IImageService>();
			var tripsController = new TripsController(mockedTripService.Object, mockedIDestinationService.Object,
				mockedMappingService.Object, mockedImageService.Object);


			var countries = new List<string>();

			// Act 
			tripsController
				.WithCallTo(c => c.Create())
				.ShouldRenderDefaultView();

			//Assert
			Assert.AreEqual(countries, tripsController.ViewBag.Destinations);
		}
	}
}
