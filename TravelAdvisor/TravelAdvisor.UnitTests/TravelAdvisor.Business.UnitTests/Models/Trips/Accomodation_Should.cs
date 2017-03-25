using NUnit.Framework;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Trips
{
	[TestFixture]
	public class Accomodation_Should
	{
		[TestCase("Hotel Lovech")]
		public void SetDataCorrectly(string accomodation)
		{
			//Arrange
			var trip = new Trip { Accomodation = accomodation };

			//Act & Assert
			Assert.AreEqual(trip.Accomodation, accomodation);
		}
	}
}
