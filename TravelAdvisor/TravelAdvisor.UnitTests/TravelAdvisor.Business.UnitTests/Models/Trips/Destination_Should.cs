using NUnit.Framework;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Trips
{
	[TestFixture]
	public class Destination_Should
	{
		[TestCase(3)]
		public void SetDataCorrectly(int destinationId)
		{
			//Arrange
			var destination = new Destination { Id = destinationId };
			var trip = new Trip { Destination = destination };

			//Act & Assert
			Assert.AreEqual(trip.Destination.Id, destinationId);
		}
	}
}
