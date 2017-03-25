using NUnit.Framework;
using TravelAdvisor.Business.Models.Destinations;

namespace TravelAdvisor.Business.UnitTests.Models.Destinations
{
	[TestFixture]
	public class ImageUrl_Should
	{
		[TestCase("/Images/avata01.jpg")]
		[TestCase("/Images/avata02.png")]
		public void GetAndSetDataCorrectly(string testImageUrl)
		{
			//Arrange
			var destination = new Destination() { ImageUrl = testImageUrl };

			//Act & Assert
			Assert.AreEqual(destination.ImageUrl, testImageUrl);
		}
	}
}
