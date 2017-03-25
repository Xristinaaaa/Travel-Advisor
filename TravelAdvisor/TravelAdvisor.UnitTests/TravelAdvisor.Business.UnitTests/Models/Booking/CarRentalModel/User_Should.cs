using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarRentalModel
{
	[TestFixture]
	public class User_Should
	{
		[TestCase("asdfa123.sdf")]
		public void SetDataCorrectly(string userId)
		{
			//Arrange
			var regularUser = new RegularUser { Id = userId };
			var carRental = new CarRental { User = regularUser };

			//Act & Assert
			Assert.AreEqual(carRental.User.Id, userId);
		}
	}
}
