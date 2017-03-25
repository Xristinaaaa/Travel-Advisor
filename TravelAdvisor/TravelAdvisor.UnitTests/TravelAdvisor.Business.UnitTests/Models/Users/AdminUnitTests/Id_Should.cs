using System;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.AdminUnitTests
{
	[TestFixture]
	public class Id_Should
	{
		[TestCase("sddddfsdf")]
		public void SetDataCorrectly(string userId)
		{
			//Arrange
			var admin = new Admin { Id = userId };

			//Act & Assert
			Assert.AreEqual(admin.Id, userId);
		}
	}
}
