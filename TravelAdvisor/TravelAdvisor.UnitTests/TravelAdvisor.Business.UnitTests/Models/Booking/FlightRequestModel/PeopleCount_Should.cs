using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.FlightRequestModel
{
	[TestFixture]
	public class PeopleCount_Should
	{
		[TestCase(213)]
		public void SetDataCorrectly(int count)
		{
			//Arrange
			var flightRequest = new FlightRequest { PeopleCount = count };

			//Act & Assert
			Assert.AreEqual(flightRequest.PeopleCount, count);
		}
	}
}
