using System.ComponentModel.DataAnnotations;
using TravelAdvisor.Business.Common.Constants;

namespace TravelAdvisor.Web.Models.Account
{
	public class RegisterViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[StringLength(ValidationConstants.MaxPasswordLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ValidationConstants.MinPasswordLength)]
        [RegularExpression(ValidationConstants.PasswordRegex)]
        [DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		public string UserRole { get; set; }
	}
}