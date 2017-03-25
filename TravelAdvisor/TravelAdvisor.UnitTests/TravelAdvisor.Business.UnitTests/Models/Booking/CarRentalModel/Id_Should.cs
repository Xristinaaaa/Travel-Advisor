using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarRentalModel
{
	[TestFixture]
	public class Id_Should
	{
		[TestCase(1231)]
		public void SetDataCorrectly(int carRentalId)
		{
			//Arrange
			var carRental = new CarRental { Id = carRentalId };

			//Act & Assert
			Assert.AreEqual(carRental.Id, carRentalId);
		}
	}
}
