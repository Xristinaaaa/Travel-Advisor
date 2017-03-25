using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.DestionationServiceUnitTests
{
	[TestFixture]
	public class FindByCountry_Should
	{
		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);
			var destination = new Mock<Destination>();

			//Act
			mockedRepository.Setup(repository => repository.GetFirst(x => x.Country == destination.Object.Country))
				.Returns(destination.Object);

			//Assert
			Assert.AreEqual(destinationService.FindByCountry(destination.Object.Country), It.IsAny<Destination>());
		}

		[Test]
		public void ReturnCorrectDestination_WhenInvoked()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);
			var destination = new Mock<Destination>();

			//Act
			var destinationToCompare = new Mock<Destination>();
			mockedRepository.Setup(repository => repository.GetFirst(x => x.Country == destination.Object.Country))
				.Returns(() => destination.Object);

			Assert.AreNotEqual(destinationService.FindByCountry(destination.Object.Country), destinationToCompare.Object);
		}

		[Test]
		public void ReturnNull_WhenNoSuchDestination()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			mockedRepository.Setup(repository => repository.GetFirst(x => x.Country == "Bulgaria"))
				.Returns(() => null);

			//Assert
			Assert.IsNull(destinationService.FindByCountry("Bulgaria"));
		}

		[Test]
		public void ThrowException_WhenNullDestination()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			Mock<Destination> destination = null;

			//Assert
			Assert.Throws<NullReferenceException>(() => destinationService.FindByCountry(destination.Object.Country));
		}
	}
}
