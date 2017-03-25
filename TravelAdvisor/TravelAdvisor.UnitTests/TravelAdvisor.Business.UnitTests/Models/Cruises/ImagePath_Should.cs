using NUnit.Framework;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.UnitTests.Models.Cruises
{
	[TestFixture]
	public class ImagePath_Should
	{
		[TestCase("/Images/avata01.jpg")]
		[TestCase("/Images/avata02.png")]
		public void GetAndSetDataCorrectly(string testImagePath)
		{
			//Arrange
			var cruise = new Cruise() { ImagePath = testImagePath };

			//Act & Assert
			Assert.AreEqual(cruise.ImagePath, testImagePath);
		}
	}
}
