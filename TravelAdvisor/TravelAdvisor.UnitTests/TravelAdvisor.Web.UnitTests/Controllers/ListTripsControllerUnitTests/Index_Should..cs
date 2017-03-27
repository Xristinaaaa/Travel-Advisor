using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Controllers;
using TravelAdvisor.Web.Models.Trips;

namespace TravelAdvisor.Web.UnitTests.Controllers.ListTripsControllerUnitTests
{
	[TestFixture]
	public class Index_Should
	{
		[Test]
		public void ReturnDefaultView()
		{
			// Arrange
			var mockedTripService = new Mock<ITripService>();
			var mockedMappingService = new Mock<IMappingService>();
			var listTripsController = new ListTripsController(mockedTripService.Object, mockedMappingService.Object);

			// Act & Assert
			listTripsController
				.WithCallTo(c => c.Index())
				.ShouldRenderDefaultView();
		}

		[Test]
		public void InvokeServiceMethod()
		{
			// Arrange
			var mockedTripService = new Mock<ITripService>();
			var mockedMappingService = new Mock<IMappingService>();
			var listTripsController = new ListTripsController(mockedTripService.Object, mockedMappingService.Object);

			//Act
			listTripsController.Index();

			//Assert
			mockedTripService.Verify(x => x.GetAllTrips(), Times.Once());
		}

		[Test]
		public void ReturnViewWithModel()
		{
			// Arrange
			var mockedTripService = new Mock<ITripService>();
			var mockedMappingService = new Mock<IMappingService>();
			var listTripsController = new ListTripsController(mockedTripService.Object, mockedMappingService.Object);
			
			//Act
			var tripsModel = new TripsListViewModel();
			var trips = new List<Trip>() { new Trip(), new Trip() };

			mockedTripService.Setup(s => s.GetAllTrips()).Returns(trips.AsQueryable());

			// Assert
			listTripsController
				.WithCallTo(c => c.Index())
				.ShouldRenderDefaultView()
				.WithModel<TripsListViewModel>();
		}

		[Test]
		public void ReturnViewWithoutModel_IfNoTrips()
		{
			// Arrange
			var mockedTripService = new Mock<ITripService>();
			var mockedMappingService = new Mock<IMappingService>();
			var listTripsController = new ListTripsController(mockedTripService.Object, mockedMappingService.Object);

			//Act
			var trips = new List<Trip>();

			mockedTripService.Setup(s => s.GetAllTrips()).Returns(trips.AsQueryable());

			// Assert
			listTripsController
				.WithCallTo(c => c.Index())
				.ShouldRenderDefaultView();
		}
	}
}
