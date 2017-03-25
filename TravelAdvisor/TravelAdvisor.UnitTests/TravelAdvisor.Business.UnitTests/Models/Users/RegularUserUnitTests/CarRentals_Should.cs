using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.RegularUserUnitTests
{
	[TestFixture]
	public class CarRentals_Should
	{
		[TestCase(3)]
		public void SetDataCorrectly(int carRentalId)
		{
			//Arrange
			var carRental = new CarRental { Id = carRentalId };
			var carRentalSet = new HashSet<CarRental> { carRental };
			var regularUser = new RegularUser { CarRentals = carRentalSet };

			//Act & Assert
			Assert.AreEqual(regularUser.CarRentals.First().Id, carRentalId);
		}
	}
}
