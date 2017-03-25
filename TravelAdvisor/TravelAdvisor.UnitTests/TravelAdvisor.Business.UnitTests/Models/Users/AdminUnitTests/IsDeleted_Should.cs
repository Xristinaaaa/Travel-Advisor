using NUnit.Framework;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.AdminUnitTests
{
	[TestFixture]
	public class IsDeleted_Should
	{
		[TestCase(true)]
		[TestCase(false)]
		public void SetDataCorrectly(bool isDeleted)
		{
			//Arrange
			var admin = new Admin { IsDeleted = isDeleted };

			//Act & Assert
			Assert.AreEqual(admin.IsDeleted, isDeleted);
		}
	}
}
