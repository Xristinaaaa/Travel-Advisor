using NUnit.Framework;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.ApplicationUserUnitTests
{
	[TestFixture]
	public class Age_Should
	{
		[TestCase(22)]
		public void GetAndSetDataCorrectly(int userAge)
		{
			//Arrange
			var applicationUser = new ApplicationUser() { Age = userAge };

			//Act & Assert
			Assert.AreEqual(applicationUser.Age, userAge);
		}
	}
}
