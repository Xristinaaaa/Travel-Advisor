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

			registrationService.GetAllUserRoles();

			mockedRoleRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIqueriable_WhenInvoked()
		{
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

			IEnumerable<IdentityRole> result = new List<IdentityRole>() { new IdentityRole(), new IdentityRole() };
			mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.IsInstanceOf<IQueryable<IdentityRole>>(registrationService.GetAllUserRoles());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
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

			IEnumerable<IdentityRole> result = new List<IdentityRole>()
				{ new IdentityRole(), new IdentityRole() };
			mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.AreEqual(registrationService.GetAllUserRoles(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoRoles()
		{
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

			IEnumerable<IdentityRole> result = new List<IdentityRole>();
			mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.IsEmpty(registrationService.GetAllUserRoles());
		}

		[Test]
		public void ThrowException_WhenRoleIsNull()
		{
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

			IEnumerable<IdentityRole> result = null;
			mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.Throws<ArgumentNullException>(() => registrationService.GetAllUserRoles());
		}
	}
}
