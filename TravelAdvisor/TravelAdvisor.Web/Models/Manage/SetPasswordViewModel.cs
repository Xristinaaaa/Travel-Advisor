using System.ComponentModel.DataAnnotations;
using TravelAdvisor.Business.Common.Constants;

namespace TravelAdvisor.Web.Models.Manage
{
	public class SetPasswordViewModel
	{
        [Required]
        [StringLength(ValidationConstants.MaxPasswordLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ValidationConstants.MinPasswordLength)]
        [RegularExpression(ValidationConstants.PasswordRegex)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm new password")]
		[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}
}