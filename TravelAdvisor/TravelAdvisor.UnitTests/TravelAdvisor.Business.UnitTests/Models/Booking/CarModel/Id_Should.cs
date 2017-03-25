using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarModel
{
	[TestFixture]
	public class Id_Should
	{
		[TestCase(1231)]
		public void SetDataCorrectly(int carId)
		{
			//Arrange
			var car = new Car { Id = carId };

			//Act & Assert
			Assert.AreEqual(car.Id, carId);
		}
	}
}
