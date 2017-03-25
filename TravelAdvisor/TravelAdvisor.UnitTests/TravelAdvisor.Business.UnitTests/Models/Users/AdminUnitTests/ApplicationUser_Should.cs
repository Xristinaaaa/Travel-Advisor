using NUnit.Framework;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.AdminUnitTests
{
	[TestFixture]
	public class ApplicationUser_Should
	{
		[TestCase("asdfa123.sdf")]
		public void SetDataCorrectly(string userId)
		{
			//Arrange
			var applicationUser = new ApplicationUser { Id = userId };
			var admin = new Admin { ApplicationUser = applicationUser };

			//Act & Assert
			Assert.AreEqual(admin.ApplicationUser.Id, userId);
		}
	}
}
