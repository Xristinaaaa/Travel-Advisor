using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarRentalModel
{
	[TestFixture]
	public class Location_Should
	{
		[TestCase("BMW")]
		public void SetDataCorrectly(string location)
		{
			//Arrange
			var carRental = new CarRental { Location = location };

			//Act & Assert
			Assert.AreEqual(carRental.Location, location);
		}
	}
}
