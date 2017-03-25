using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.FlightRequestModel
{
	[TestFixture]
	public class User_Should
	{
		[TestCase("asdfa123.sdf")]
		public void SetDataCorrectly(string userId)
		{
			//Arrange
			var regularUser = new RegularUser { Id = userId };
			var flightRequest = new FlightRequest { User = regularUser };

			//Act & Assert
			Assert.AreEqual(flightRequest.User.Id, userId);
		}
	}
}
