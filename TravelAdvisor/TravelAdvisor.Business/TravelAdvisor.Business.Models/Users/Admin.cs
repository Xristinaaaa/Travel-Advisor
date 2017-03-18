using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAdvisor.Business.Models.Users.Contracts;

namespace TravelAdvisor.Business.Models.Users
{
	public class Admin : IAdmin
	{
		[Key, ForeignKey("ApplicationUser")]
		public string Id { get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; }

		public bool IsDeleted { get; set; }
	}
}
