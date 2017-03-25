using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.AdminUnitTests
{
	[TestFixture]
	public class FlightRequests_Shouldcs
	{
		[TestCase(12)]
		public void SetDataCorrectly(int flightRequestId)
		{
			//Arrange
			var flightRequest = new FlightRequest { Id = flightRequestId };
			var flightRequestSet = new HashSet<FlightRequest> { flightRequest };
			var admin = new Admin { FlightRequests = flightRequestSet };

			//Act & Assert
			Assert.AreEqual(admin.FlightRequests.First().Id, flightRequestId);
		}
	}
}
