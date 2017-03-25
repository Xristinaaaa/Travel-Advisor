using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarModel
{
	[TestFixture]
	public class IsDeleted_Should
	{
		[TestCase(true)]
		[TestCase(false)]
		public void SetDataCorrectly(bool isDeleted)
		{
			//Arrange
			var car = new Car { IsDeleted = isDeleted };

			//Act & Assert
			Assert.AreEqual(car.IsDeleted, isDeleted);
		}
	}
}
