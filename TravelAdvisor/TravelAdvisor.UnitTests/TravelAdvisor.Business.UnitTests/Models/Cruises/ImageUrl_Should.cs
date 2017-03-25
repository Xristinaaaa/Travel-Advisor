using NUnit.Framework;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.UnitTests.Models.Cruises
{
	[TestFixture]
	public class ImageUrl_Should
	{
		[TestCase("/Images/avata01.jpg")]
		[TestCase("/Images/avata02.png")]
		public void GetAndSetDataCorrectly(string testImageUrl)
		{
			//Arrange
			var cruise = new Cruise() { ImageUrl = testImageUrl };

			//Act & Assert
			Assert.AreEqual(cruise.ImageUrl, testImageUrl);
		}
	}
}
