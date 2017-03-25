using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.FlightRequestModel
{
	[TestFixture]
	public class FromLocation_Should
	{
		[TestCase("London")]
		public void SetDataCorrectly(string fromLocation)
		{
			//Arrange
			var flightRequest = new FlightRequest { FromLocation = fromLocation };

			//Act & Assert
			Assert.AreEqual(flightRequest.FromLocation, fromLocation);
		}
	}
}
