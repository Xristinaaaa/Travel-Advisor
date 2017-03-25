using NUnit.Framework;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.RegularUserUnitTests
{
	[TestFixture]
	public class ApplicationUser_Should
	{
		[TestCase("asdfa123.sdf")]
		public void SetDataCorrectly(string userId)
		{
			//Arrange
			var applicationUser = new ApplicationUser { Id = userId };
			var regularUser = new RegularUser { ApplicationUser = applicationUser };

			//Act & Assert
			Assert.AreEqual(regularUser.ApplicationUser.Id, userId);
		}
	}
}
