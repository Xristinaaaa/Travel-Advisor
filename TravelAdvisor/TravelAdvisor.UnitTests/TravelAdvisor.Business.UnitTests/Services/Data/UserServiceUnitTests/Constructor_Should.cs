using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Users;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.UserServiceUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateTripService_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<RegularUser>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act & Assert
			Assert.That(userService, Is.InstanceOf<UserService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			//Arrange
			Mock<IEFRepository<RegularUser>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new UserService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<RegularUser>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new UserService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
