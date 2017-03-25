using NUnit.Framework;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.RegularUserUnitTests
{
	[TestFixture]
	public class IsDeleted_Should
	{
		[TestCase(true)]
		[TestCase(false)]
		public void SetDataCorrectly(bool isDeleted)
		{
			//Arrange
			var regularUser = new RegularUser { IsDeleted = isDeleted };

			//Act & Assert
			Assert.AreEqual(regularUser.IsDeleted, isDeleted);
		}
	}
}
