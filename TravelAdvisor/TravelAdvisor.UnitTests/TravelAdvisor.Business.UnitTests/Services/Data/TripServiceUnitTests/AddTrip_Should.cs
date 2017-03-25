using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.TripServiceUnitTests
{
	[TestFixture]
	public class AddTrip_Should
	{
		[Test]
		public void BeInvoked_WhenTripIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);
			var trip = new Mock<Trip>();

			//Act
			tripService.AddTrip(trip.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(trip.Object));
		}

		[Test]
		public void BeInvokeOnceForTypeTrip_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);
			var trip = new Mock<Trip>();

			//Act
			tripService.AddTrip(trip.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(It.IsAny<Trip>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenTripIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);
			var trip = new Mock<Trip>();

			//Act
			tripService.AddTrip(trip.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenTripIsInvalid()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<Trip> trip = null;

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => tripService.AddTrip(trip.Object));
		}
	}
}
