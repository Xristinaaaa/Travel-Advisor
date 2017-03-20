using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelAdvisor.Business.Common.Constants;

namespace TravelAdvisor.Business.Models.Users
{
	public class ApplicationUser : IdentityUser
	{
		[MinLength(ValidationConstants.NameMinLength)]
		[MaxLength(ValidationConstants.NameMaxLength)]
		public string FirstName { get; set; }

		[MinLength(ValidationConstants.NameMinLength)]
		[MaxLength(ValidationConstants.NameMaxLength)]
		public string LastName { get; set; }
		
		public int Age { get; set; }

		public string AvatarUrl { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}
}
