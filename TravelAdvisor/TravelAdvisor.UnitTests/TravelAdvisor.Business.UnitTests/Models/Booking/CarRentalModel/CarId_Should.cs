using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarRentalModel
{
	[TestFixture]
	public class CarId_Should
	{
		[TestCase(1324)]
		public void SetDataCorrectly(int carId)
		{
			//Arrange
			var car = new Car { Id = carId };
			var carRental = new CarRental { CarId = carId};

			//Act & Assert
			Assert.AreEqual(carRental.CarId, carId);
		}
	}
}
