using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.RegularUserUnitTests
{
	[TestFixture]
	public class Trips_Should
	{
		[TestCase(12)]
		public void SetDataCorrectly(int tripId)
		{
			//Arrange
			var trip = new Trip { Id = tripId };
			var tripSet = new HashSet<Trip> { trip };
			var regularUser = new RegularUser { Trips = tripSet };

			//Act & Assert
			Assert.AreEqual(regularUser.Trips.First().Id, tripId);
		}
	}
}
