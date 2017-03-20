using System.ComponentModel.DataAnnotations;

namespace TravelAdvisor.Web.Models.Account
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}