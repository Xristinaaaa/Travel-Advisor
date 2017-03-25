using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.TripServiceUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateTripService_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var tripService = new TripService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act & Assert
			Assert.That(tripService, Is.InstanceOf<TripService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			//Arranger
			Mock<IEFRepository<Trip>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new TripService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Trip>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new TripService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
