using NUnit.Framework;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.UnitTests.Models.Cruises
{
	[TestFixture]
	public class FreePlaces_Should
	{
		[TestCase(10)]
		public void SetDataCorrectly(int freePlaces)
		{
			//Arrange
			var cruise = new Cruise { FreePlaces = freePlaces };

			//Act & Assert
			Assert.AreEqual(cruise.FreePlaces, freePlaces);
		}
	}
}
