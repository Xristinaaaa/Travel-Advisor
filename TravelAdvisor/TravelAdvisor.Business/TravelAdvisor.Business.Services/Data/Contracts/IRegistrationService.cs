using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Services.Data.Contracts
{
	public interface IRegistrationService
	{
		IQueryable<IdentityRole> GetAllUserRoles();

		ApplicationUser CreateApplicationUser(string email);

		void CreateRegularUser(string userId);

		void CreateAdmin(string adminId);
	}
}
