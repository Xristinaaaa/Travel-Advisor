using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Users;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.RegistrationServiceUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateRegistrationService_WhenParamsAreValid()
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

			Assert.That(registrationService, Is.InstanceOf<RegistrationService>());
		}

		[Test]
		public void ThrowNullException_WhenRoleRepositoryIsNull()
		{
			Mock<IEFRepository<IdentityRole>> mockedRoleRepository = null;
			var mockedRegularUserRepository = new Mock<IEFRepository<RegularUser>>();
			var mockedAdminRepository = new Mock<IEFRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			Assert.Throws<NullReferenceException>(() =>
				new RegistrationService(
					mockedRoleRepository.Object,
					mockedRegularUserRepository.Object,
					mockedAdminRepository.Object,
					mockedUnitOfWork.Object
				)
			);
		}

		[Test]
		public void ThrowNullException_WhenUserRepositoryIsNull()
		{
			var mockedRoleRepository = new Mock<IEFRepository<IdentityRole>>();
			Mock<IEFRepository<RegularUser>> mockedRegularUserRepository = null;
			var mockedAdminRepository = new Mock<IEFRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			Assert.Throws<NullReferenceException>(() =>
				new RegistrationService(
					mockedRoleRepository.Object,
					mockedRegularUserRepository.Object,
					mockedAdminRepository.Object,
					mockedUnitOfWork.Object
				)
			);
		}

		[Test]
		public void ThrowNullException_WhenAdminRepositoryIsNull()
		{
			var mockedRoleRepository = new Mock<IEFRepository<IdentityRole>>();
			var mockedRegularUserRepository = new Mock<IEFRepository<RegularUser>>();
			Mock<IEFRepository<Admin>> mockedAdminRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			Assert.Throws<NullReferenceException>(() =>
				new RegistrationService(
					mockedRoleRepository.Object,
					mockedRegularUserRepository.Object,
					mockedAdminRepository.Object,
					mockedUnitOfWork.Object
				)
			);
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			var mockedRoleRepository = new Mock<IEFRepository<IdentityRole>>();
			var mockedRegularUserRepository = new Mock<IEFRepository<RegularUser>>();
			var mockedAdminRepository = new Mock<IEFRepository<Admin>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			Assert.Throws<NullReferenceException>(() =>
				new RegistrationService(
					mockedRoleRepository.Object,
					mockedRegularUserRepository.Object,
					mockedAdminRepository.Object,
					mockedUnitOfWork.Object
				)
			);
		}
	}
}
