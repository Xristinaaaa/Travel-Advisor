using NUnit.Framework;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Trips
{
	[TestFixture]
	public class ImageUrl_Should
	{
		[TestCase("/Images/avata01.jpg")]
		[TestCase("/Images/avata02.png")]
		public void GetAndSetDataCorrectly(string testImageUrl)
		{
			//Arrange
			var trip = new Trip() { ImageUrl = testImageUrl };

			//Act & Assert
			Assert.AreEqual(trip.ImageUrl, testImageUrl);
		}
	}
}
