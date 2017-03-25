using NUnit.Framework;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.UnitTests.Models.Cruises
{
	[TestFixture]
	public class CruiseLine_Should
	{
		[TestCase("unknown")]
		public void GetAndSetDataCorrectly(string cruiseLine)
		{
			//Arrange
			var cruise = new Cruise() { CruiseLine = cruiseLine };

			//Act & Assert
			Assert.AreEqual(cruise.CruiseLine, cruiseLine);
		}
	}
}
