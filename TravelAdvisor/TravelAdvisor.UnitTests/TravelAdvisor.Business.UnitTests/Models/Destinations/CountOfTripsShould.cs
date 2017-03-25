using NUnit.Framework;
using TravelAdvisor.Business.Models.Destinations;

namespace TravelAdvisor.Business.UnitTests.Models.Destinations
{
	[TestFixture]
	public class CountOfTripsShould
	{
		[TestCase(12314)]
		public void SetDataCorrectly(int countOfTrips)
		{
			//Arrange
			var destination = new Destination { CountOfTrips = countOfTrips };

			//Act & Assert
			Assert.AreEqual(destination.CountOfTrips, countOfTrips);
		}
	}
}
