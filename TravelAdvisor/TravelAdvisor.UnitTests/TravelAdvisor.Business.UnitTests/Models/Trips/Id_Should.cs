using NUnit.Framework;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Trips
{
	[TestFixture]
	public class Id_Should
	{
		[TestCase(1231)]
		public void SetDataCorrectly(int tripId)
		{
			//Arrange
			var trip = new Trip { Id = tripId };

			//Act & Assert
			Assert.AreEqual(trip.Id, tripId);
		}
	}
}
