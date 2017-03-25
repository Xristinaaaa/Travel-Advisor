using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarModel
{
	[TestFixture]
	public class ImageUrl_Should
	{
		[TestCase("/Images/car.jpg")]
		[TestCase("/Images/car2.png")]
		public void GetAndSetDataCorrectly(string testImageUrl)
		{
			//Arrange
			var car = new Car() { ImageUrl = testImageUrl };

			//Act & Assert
			Assert.AreEqual(car.ImageUrl, testImageUrl);
		}
	}
}
