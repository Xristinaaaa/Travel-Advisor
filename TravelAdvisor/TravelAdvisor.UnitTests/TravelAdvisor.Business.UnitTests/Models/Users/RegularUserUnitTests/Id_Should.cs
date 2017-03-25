using System;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.RegularUserUnitTests
{
	[TestFixture]
	public class Id_Should
	{
		[TestCase("sddddfsdf")]
		public void SetDataCorrectly(string userId)
		{
			//Arrange
			var regularUser = new RegularUser { Id = userId};

			//Act & Assert
			Assert.AreEqual(regularUser.Id, userId);
		}
	}
}
