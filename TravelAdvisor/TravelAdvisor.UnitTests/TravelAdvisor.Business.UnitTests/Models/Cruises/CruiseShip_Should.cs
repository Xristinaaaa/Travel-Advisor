using NUnit.Framework;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.UnitTests.Models.Cruises
{
	[TestFixture]
	public class CruiseShip_Should
	{
		[TestCase("unknown")]
		public void GetAndSetDataCorrectly(string cruiseShip)
		{
			//Arrange
			var cruise = new Cruise() { CruiseShip = cruiseShip };

			//Act & Assert
			Assert.AreEqual(cruise.CruiseShip, cruiseShip);
		}
	}
}
