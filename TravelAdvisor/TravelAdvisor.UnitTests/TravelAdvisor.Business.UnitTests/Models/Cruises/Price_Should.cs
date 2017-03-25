using NUnit.Framework;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.UnitTests.Models.Cruises
{
	[TestFixture]
	public class Price_Should
	{
		[TestCase(123.32452)]
		public void SetDataCorrectly(decimal price)
		{
			//Arrange
			var cruise = new Cruise { Price = price };

			//Act & Assert
			Assert.AreEqual(cruise.Price, price);
		}
	}
}
