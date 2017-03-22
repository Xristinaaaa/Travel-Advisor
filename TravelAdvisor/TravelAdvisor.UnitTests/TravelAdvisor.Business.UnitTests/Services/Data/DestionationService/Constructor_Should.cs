using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.DestionationService
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateDestinationService_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var destinationService = new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object);

			Assert.That(destinationService, Is.InstanceOf<DestinationService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			Mock<IEFRepository<Destination>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			Assert.Throws<NullReferenceException>(() => new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			var mockedRepository = new Mock<IEFRepository<Destination>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			Assert.Throws<NullReferenceException>(() => new DestinationService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
