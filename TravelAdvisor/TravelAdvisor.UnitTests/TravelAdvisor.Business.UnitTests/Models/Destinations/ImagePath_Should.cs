using NUnit.Framework;
using TravelAdvisor.Business.Models.Destinations;

namespace TravelAdvisor.Business.UnitTests.Models.Destinations
{
	[TestFixture]
	public class ImagePath_Should
	{
		[TestCase("/Images/avata01.jpg")]
		[TestCase("/Images/avata02.png")]
		public void GetAndSetDataCorrectly(string testImagePath)
		{
			//Arrange
			var destination = new Destination() { ImagePath = testImagePath };

			//Act & Assert
			Assert.AreEqual(destination.ImagePath, testImagePath);
		}
	}
}
