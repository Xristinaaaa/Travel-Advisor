using NUnit.Framework;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.ApplicationUserUnitTests
{
	[TestFixture]
	public class ImageUrl_Should
	{
		[TestCase("/Images/avata01.jpg")]
		[TestCase("/Images/avata02.png")]
		public void GetAndSetDataCorrectly(string testImageUrl)
		{
			//Arrange
			var applicationUser = new ApplicationUser() { AvatarUrl = testImageUrl };

			//Act & Assert
			Assert.AreEqual(applicationUser.AvatarUrl, testImageUrl);
		}
	}
}
