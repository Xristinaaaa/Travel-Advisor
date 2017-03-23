using System.Linq;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Users;
using TravelAdvisor.Business.Services.Data.Contracts;

namespace TravelAdvisor.Business.Services.Data
{
	public class RegistrationService : IRegistrationService
	{
		private readonly IEFRepository<IdentityRole> userRolesRepo;
		private readonly IEFRepository<RegularUser> regularUserRepo;
		private readonly IEFRepository<Admin> adminRepo;
		private readonly IUnitOfWork unitOfWork;

		public RegistrationService(
			IEFRepository<IdentityRole> userRolesRepo,
			IEFRepository<RegularUser> regularUserRepo,
			IEFRepository<Admin> adminRepo,
			IUnitOfWork unitOfWork)
		{
			Guard.WhenArgument(userRolesRepo, "userRolesRepo").IsNull().Throw();
			Guard.WhenArgument(regularUserRepo, "userRepo").IsNull().Throw();
			Guard.WhenArgument(adminRepo, "adminRepo").IsNull().Throw();
			Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

			this.userRolesRepo = userRolesRepo;
			this.regularUserRepo = regularUserRepo;
			this.adminRepo = adminRepo;
			this.unitOfWork = unitOfWork;
		}

		public IQueryable<IdentityRole> GetAllUserRoles()
		{
			return this.userRolesRepo.All();
		}

		public ApplicationUser CreateApplicationUser(string email)
		{
			Guard.WhenArgument(email, "email").IsNullOrEmpty().Throw();

			ApplicationUser newUser = new ApplicationUser()
			{
				UserName = email,
				Email = email
			};

			return newUser;
		}

		public void CreateAdmin(string adminId)
		{
			Guard.WhenArgument(adminId, "adminId").IsNullOrEmpty().Throw();

			using (var uow = this.unitOfWork)
			{
				var admin = new Admin()
				{
					Id = adminId
				};

				this.adminRepo.Add(admin);

				uow.SaveChanges();
			}
		}

		public void CreateRegularUser(string userId)
		{
			Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

			using (var uow = this.unitOfWork)
			{
				var regularUser = new RegularUser()
				{
					Id = userId
				};

				this.regularUserRepo.Add(regularUser);

				uow.SaveChanges();
			}
		}
	}
}