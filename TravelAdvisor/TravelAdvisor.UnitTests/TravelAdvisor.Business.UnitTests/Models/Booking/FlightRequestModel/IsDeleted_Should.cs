using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.FlightRequestModel
{
	[TestFixture]
	public class IsDeleted_Should
	{
		[TestCase(true)]
		[TestCase(false)]
		public void SetDataCorrectly(bool isDeleted)
		{
			//Arrange
			var flightRequest = new FlightRequest { IsDeleted = isDeleted };

			//Act & Assert
			Assert.AreEqual(flightRequest.IsDeleted, isDeleted);
		}
	}
}
