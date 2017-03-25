using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarRentalModel
{
	[TestFixture]
	public class Car_Should
	{
		[TestCase(34)]
		public void SetDataCorrectly(int carId)
		{
			//Arrange
			var car = new Car { Id = carId };
			var carRental = new CarRental { Car = car };

			//Act & Assert
			Assert.AreEqual(carRental.Car.Id, carId);
		}
	}
}
