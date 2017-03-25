using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.FlightRequestModel
{
	[TestFixture]
	public class ToLocation_Should
	{
		[TestCase("Munchen")]
		public void SetDataCorrectly(string toLocation)
		{
			//Arrange
			var flightRequest = new FlightRequest { ToLocation = toLocation };

			//Act & Assert
			Assert.AreEqual(flightRequest.ToLocation, toLocation);
		}
	}
}
