using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarModel
{
	[TestFixture]
	public class RentalPrice_Should
	{
		[TestCase(112222222.32452)]
		public void SetDataCorrectly(decimal price)
		{
			//Arrange
			var car = new Car { RentalPrice = price };

			//Act & Assert
			Assert.AreEqual(car.RentalPrice, price);
		}
	}
}
