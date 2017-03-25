using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.FlightRequestModel
{
	[TestFixture]
	public class TravelClass_Should
	{
		[TestCase(TravelClass.BusinessClass)]
		public void SetDataCorrectly(TravelClass travelClass)
		{
			//Arrange
			var flightRequest = new FlightRequest { TravelClass = travelClass };

			//Act & Assert
			Assert.AreEqual(flightRequest.TravelClass, travelClass);
		}
	}
}
