﻿using System.ComponentModel.DataAnnotations;

namespace TravelAdvisor.Web.Models.Account
{
	public class ForgotViewModel
	{
		[Required]
        [EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}