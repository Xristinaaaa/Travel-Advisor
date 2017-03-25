using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarRentalModel
{
	[TestFixture]
	public class IsDeleted_Should
	{
		[TestCase(true)]
		[TestCase(false)]
		public void SetDataCorrectly(bool isDeleted)
		{
			//Arrange
			var carRental = new CarRental { IsDeleted = isDeleted };

			//Act & Assert
			Assert.AreEqual(carRental.IsDeleted, isDeleted);
		}
	}
}
