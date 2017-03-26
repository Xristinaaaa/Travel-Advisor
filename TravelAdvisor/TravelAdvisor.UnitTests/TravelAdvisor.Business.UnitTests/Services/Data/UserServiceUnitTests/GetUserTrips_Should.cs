using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Models.Users;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.UserServiceUnitTests
{
	[TestFixture]
	public class GetUserTrips_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IEFRepository<RegularUser>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			string userId = "afs4gdfg";
			var user = new Mock<RegularUser>();
			mockedRepository.Setup(repository => repository.GetById(userId)).Returns(user.Object);
			userService.GetUserTrips(userId);

			//Assert
			mockedRepository.Verify(repository => repository.GetById(It.IsAny<string>()), Times.Once);
		}
	}
}
