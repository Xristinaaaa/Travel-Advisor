using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.FlightRequestModel
{
	[TestFixture]
	public class Id_Should
	{
		[TestCase(5)]
		public void SetDataCorrectly(int flightRequestId)
		{
			//Arrange
			var flightRequest = new FlightRequest { Id = flightRequestId };

			//Act & Assert
			Assert.AreEqual(flightRequest.Id, flightRequestId);
		}
	}
}
