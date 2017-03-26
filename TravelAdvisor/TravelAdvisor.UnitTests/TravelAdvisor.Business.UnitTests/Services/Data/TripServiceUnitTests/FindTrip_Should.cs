using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.TripServiceUnitTests
{
	[TestFixture]
	public class FindTrip_Should
	{
		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);
			var trip = new Mock<Trip>();

			//Act
			mockedRepository.Setup(repository => repository.GetFirst(x => x.Id == trip.Object.Id))
				.Returns(trip.Object);

			//Assert
			Assert.AreEqual(tripService.FindTrip(trip.Object.Id), It.IsAny<Trip>());
		}

		[Test]
		public void ReturnCorrectTrip_WhenInvoked()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);
			var trip = new Mock<Trip>();

			//Act
			var tripToCompare = new Mock<Trip>();
			mockedRepository.Setup(repository => repository.GetFirst(x => x.Id == trip.Object.Id))
				.Returns(() => trip.Object);

			Assert.AreNotEqual(tripService.FindTrip(trip.Object.Id), tripToCompare.Object);
		}

		[Test]
		public void ReturnNull_WhenNoSuchTrip()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			mockedRepository.Setup(repository => repository.GetFirst(x => x.Id == 3))
				.Returns(() => null);

			//Assert
			Assert.IsNull(tripService.FindTrip(3));
		}

		[Test]
		public void ThrowException_WhenNullTrip()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			Mock<Trip> trip = null;

			//Assert
			Assert.Throws<NullReferenceException>(() => tripService.FindTrip(trip.Object.Id));
		}
	}
}
