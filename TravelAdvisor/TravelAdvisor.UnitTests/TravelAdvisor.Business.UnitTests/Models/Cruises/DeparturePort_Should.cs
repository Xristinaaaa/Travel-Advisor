using NUnit.Framework;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.UnitTests.Models.Cruises
{
	[TestFixture]
	public class DeparturePort_Should
	{
		[TestCase("unknown")]
		public void GetAndSetDataCorrectly(string departurePort)
		{
			//Arrange
			var cruise = new Cruise() { DeparturePort = departurePort };

			//Act & Assert
			Assert.AreEqual(cruise.DeparturePort, departurePort);
		}
	}
}
