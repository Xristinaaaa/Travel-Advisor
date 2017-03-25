using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Users;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.RegistrationServiceUnitTests
{
	[TestFixture]
	public class GetAll_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			//Arrange
			var mockedRoleRepository = new Mock<IEFRepository<IdentityRole>>();
			var mockedRegularUserRepository = new Mock<IEFRepository<RegularUser>>();
			var mockedAdminRepository = new Mock<IEFRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var registrationService = new RegistrationService(
				mockedRoleRepository.Object,
				mockedRegularUserRepository.Object,
				mockedAdminRepository.Object,
				mockedUnitOfWork.Object
			);

			//Act
			registrationService.GetAllUserRoles();

			//Assert
			mockedRoleRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIqueryable_WhenInvoked()
		{
			//Arrange
			var mockedRoleRepository = new Mock<IEFRepository<IdentityRole>>();
			var mockedRegularUserRepository = new Mock<IEFRepository<RegularUser>>();
			var mockedAdminRepository = new Mock<IEFRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var registrationService = new RegistrationService(
				mockedRoleRepository.Object,
				mockedRegularUserRepository.Object,
				mockedAdminRepository.Object,
				mockedUnitOfWork.Object
			);

			//Act
			IEnumerable<IdentityRole> result = new List<IdentityRole>() { new IdentityRole(), new IdentityRole() };
			mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.IsInstanceOf<IQueryable<IdentityRole>>(registrationService.GetAllUserRoles());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arrange
			var mockedRoleRepository = new Mock<IEFRepository<IdentityRole>>();
			var mockedRegularUserRepository = new Mock<IEFRepository<RegularUser>>();
			var mockedAdminRepository = new Mock<IEFRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var registrationService = new RegistrationService(
				mockedRoleRepository.Object,
				mockedRegularUserRepository.Object,
				mockedAdminRepository.Object,
				mockedUnitOfWork.Object
			);

			//Act
			IEnumerable<IdentityRole> result = new List<IdentityRole>()
				{ new IdentityRole(), new IdentityRole() };
			mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.AreEqual(registrationService.GetAllUserRoles(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoRoles()
		{
			//Arrange
			var mockedRoleRepository = new Mock<IEFRepository<IdentityRole>>();
			var mockedRegularUserRepository = new Mock<IEFRepository<RegularUser>>();
			var mockedAdminRepository = new Mock<IEFRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var registrationService = new RegistrationService(
				mockedRoleRepository.Object,
				mockedRegularUserRepository.Object,
				mockedAdminRepository.Object,
				mockedUnitOfWork.Object
			);

			//Act
			IEnumerable<IdentityRole> result = new List<IdentityRole>();
			mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.IsEmpty(registrationService.GetAllUserRoles());
		}

		[Test]
		public void ThrowException_WhenRoleIsNull()
		{
			//Arrange
			var mockedRoleRepository = new Mock<IEFRepository<IdentityRole>>();
			var mockedRegularUserRepository = new Mock<IEFRepository<RegularUser>>();
			var mockedAdminRepository = new Mock<IEFRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var registrationService = new RegistrationService(
				mockedRoleRepository.Object,
				mockedRegularUserRepository.Object,
				mockedAdminRepository.Object,
				mockedUnitOfWork.Object
			);

			//Act
			IEnumerable<IdentityRole> result = null;
			mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.Throws<ArgumentNullException>(() => registrationService.GetAllUserRoles());
		}
	}
}
