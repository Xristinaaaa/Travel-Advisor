using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.DestionationService
{
	[TestFixture]
	public class AddDestination_Should
	{
		[Test]
		public void BeInvoked_WhenDestinationIsValid()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var validDestination = new Mock<Destination>();
			destinationService.AddDestination(validDestination.Object);

			mockedRepository.Verify(repository => repository.Add(validDestination.Object));
		}

		[Test]
		public void BeInvokeOnceForTypeDestination_WhenParamsAreCorrect()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var validDestination = new Mock<Destination>();
			destinationService.AddDestination(validDestination.Object);

			mockedRepository.Verify(repository => repository.Add(It.IsAny<Destination>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenDestinationIsValid()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var validDestination = new Mock<Destination>();
			destinationService.AddDestination(validDestination.Object);

			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenDestinationIsInvalid()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<Destination> destinationToAdd = null;

			Assert.Throws<NullReferenceException>(() => destinationService.AddDestination(destinationToAdd.Object));
		}
	}
}
