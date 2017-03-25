using NUnit.Framework;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Trips
{
	[TestFixture]
	public class Price_Should
	{
		[TestCase(123.32452)]
		public void SetDataCorrectly(decimal price)
		{
			//Arrange
			var trip = new Trip { Price = price };

			//Act & Assert
			Assert.AreEqual(trip.Price, price);
		}
	}
}
