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
	public class GetDestinations_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			destinationService.GetDestinations(1, 2);

			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIQueryable_WhenInvoked()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Destination> result = new List<Destination>() { new Destination(), new Destination(), new Destination() };
			mockedRepository.Setup(repository => repository.Entities).Returns(() => result.AsQueryable());

			Assert.IsInstanceOf<IQueryable<Destination>>(destinationService.GetDestinations(0, 3));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Destination> result = new List<Destination>() { new Destination(), new Destination() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.AreEqual(destinationService.GetDestinations(0, 2), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoDestinations()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Destination> result = new List<Destination>();
			mockedRepository.Setup(repository => repository.Entities).Returns(() => result.AsQueryable());

			Assert.IsEmpty(destinationService.GetDestinations(0, 1));
		}

		[Test]
		public void ThrowException_WhenNullDestination()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Destination> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.Throws<ArgumentNullException>(() => destinationService.GetDestinations(0, 1));
		}
	}
}
