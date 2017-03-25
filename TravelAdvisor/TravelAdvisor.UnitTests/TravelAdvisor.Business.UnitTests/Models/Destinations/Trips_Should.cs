using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Destinations
{
	[TestFixture]
	public class Trips_Should
	{
		[TestCase(3)]
		public void SetDataCorrectly(int tripId)
		{
			//Arrange
			var trip = new Trip { Id = tripId };
			var tripSet = new HashSet<Trip> { trip };
			var destination = new Destination { Trips = tripSet };

			//Act & Assert
			Assert.AreEqual(destination.Trips.First().Id, tripId);
		}
	}
}
