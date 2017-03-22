using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.DestionationService
{
	[TestFixture]
	public class GetAllDestinations_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			destinationService.GetAllDestinations();

			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIqueryable_WhenInvoked()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Destination> result = new List<Destination>() { new Destination(), new Destination(), new Destination() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.IsInstanceOf<IQueryable<Destination>>(destinationService.GetAllDestinations());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Destination> result = new List<Destination>() { new Destination(), new Destination(), new Destination() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.AreEqual(destinationService.GetAllDestinations(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoDestinations()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Destination> result = new List<Destination>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.IsEmpty(destinationService.GetAllDestinations());
		}

		[Test]
		public void ThrowException_WhenNullDestination()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Destination> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.Throws<ArgumentNullException>(() => destinationService.GetAllDestinations());
		}
	}
}
