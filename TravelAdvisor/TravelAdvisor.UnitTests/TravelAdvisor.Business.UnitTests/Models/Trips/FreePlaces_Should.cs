using NUnit.Framework;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Trips
{
	[TestFixture]
	public class FreePlaces_Should
	{
		[TestCase(20)]
		public void SetDataCorrectly(int freePlaces)
		{
			//Arrange
			var trip = new Trip { FreePlaces = freePlaces };

			//Act & Assert
			Assert.AreEqual(trip.FreePlaces, freePlaces);
		}
	}
}
