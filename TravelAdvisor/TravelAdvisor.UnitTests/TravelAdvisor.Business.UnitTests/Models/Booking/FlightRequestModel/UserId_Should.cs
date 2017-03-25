using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.FlightRequestModel
{
	[TestFixture]
	public class UserId_Should
	{
		[TestCase("sffsdag.123")]
		public void SetDataCorrectly(string userId)
		{
			//Arrange
			var regularUser = new RegularUser { Id = userId };
			var flightRequest = new FlightRequest { UserId = regularUser.Id };

			//Act & Assert
			Assert.AreEqual(flightRequest.UserId, userId);
		}
	}
}
