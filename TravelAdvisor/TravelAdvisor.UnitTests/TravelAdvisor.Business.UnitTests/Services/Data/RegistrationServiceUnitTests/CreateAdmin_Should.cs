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
	public class CreateAdmin_Should
	{
		[Test]
		public void InvokeAddMethod_WhenParamsAreValid()
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

			mockedAdminRepository.Setup(repository => repository.Add(It.IsAny<Admin>()));
			registrationService.CreateAdmin("1");

			mockedAdminRepository.Verify(repository => repository.Add(It.IsAny<Admin>()), Times.Once);
		}

		[Test]
		public void InvokeSaveChanges_WhenAdminIsValid()
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

			mockedAdminRepository.Setup(repository => repository.Add(It.IsAny<Admin>()));
			registrationService.CreateAdmin("1");

			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenIdIsEmpty()
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

			Assert.Throws<ArgumentException>(() => registrationService.CreateAdmin(string.Empty));
		}
	}
}
