using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.DestionationServiceUnitTests
{
	[TestFixture]
	public class AddDestination_Should
	{
		[Test]
		public void BeInvoked_WhenDestinationIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);
			var validDestination = new Mock<Destination>();

			//Act
			destinationService.AddDestination(validDestination.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(validDestination.Object));
		}

		[Test]
		public void BeInvokeOnceForTypeDestination_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);
			var validDestination = new Mock<Destination>();

			//Act
			destinationService.AddDestination(validDestination.Object);
			
			//Assert
			mockedRepository.Verify(repository => repository.Add(It.IsAny<Destination>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenDestinationIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);
			var validDestination = new Mock<Destination>();

			//Act
			destinationService.AddDestination(validDestination.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenDestinationIsInvalid()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<Destination> destinationToAdd = null;

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => destinationService.AddDestination(destinationToAdd.Object));
		}
	}
}
