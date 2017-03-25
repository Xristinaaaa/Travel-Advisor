using NUnit.Framework;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Trips
{
	[TestFixture]
	public class ImagePath_Should
	{
		[TestCase("/Images/avata01.jpg")]
		[TestCase("/Images/avata02.png")]
		public void GetAndSetDataCorrectly(string testImagePath)
		{
			//Arrange
			var trip = new Trip() { ImagePath = testImagePath };

			//Act & Assert
			Assert.AreEqual(trip.ImagePath, testImagePath);
		}
	}
}
