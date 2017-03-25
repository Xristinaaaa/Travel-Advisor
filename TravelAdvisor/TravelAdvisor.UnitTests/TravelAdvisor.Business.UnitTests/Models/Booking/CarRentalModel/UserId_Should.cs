using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarRentalModel
{
	[TestFixture]
	public class UserId_Should
	{
		[TestCase("sffsdag.123")]
		public void SetDataCorrectly(string userId)
		{
			//Arrange
			var regularUser = new RegularUser { Id = userId };
			var carRental = new CarRental { UserId = regularUser.Id };

			//Act & Assert
			Assert.AreEqual(carRental.UserId, userId);
		}
	}
}
