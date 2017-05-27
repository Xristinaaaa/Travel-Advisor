using System.ComponentModel.DataAnnotations;

namespace TravelAdvisor.Web.Models.Account
{
	public class LoginViewModel
	{
		[Display(Name = "Email")]
		[EmailAddress]
		public string Email { get; set; }
        
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}
}