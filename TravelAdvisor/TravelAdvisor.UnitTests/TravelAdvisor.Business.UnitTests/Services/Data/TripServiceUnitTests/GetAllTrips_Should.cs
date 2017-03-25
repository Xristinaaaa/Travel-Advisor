using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.TripServiceUnitTests
{
	[TestFixture]
	public class GetAllTrips_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			tripService.GetAllTrips();

			//Assert
			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIqueryable_WhenInvoked()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Trip> result = new List<Trip>() { new Trip(), new Trip(), new Trip() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.IsInstanceOf<IQueryable<Trip>>(tripService.GetAllTrips());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Trip> result = new List<Trip>() { new Trip(), new Trip(), new Trip() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.AreEqual(tripService.GetAllTrips(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoDestinations()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Trip> result = new List<Trip>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.IsEmpty(tripService.GetAllTrips());
		}

		[Test]
		public void ThrowException_WhenNullTrip()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Trip> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.Throws<ArgumentNullException>(() => tripService.GetAllTrips());
		}
	}
}
