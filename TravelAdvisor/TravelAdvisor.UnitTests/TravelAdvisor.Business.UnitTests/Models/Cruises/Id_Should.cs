using NUnit.Framework;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.UnitTests.Models.Cruises
{
	[TestFixture]
	public class Id_Should
	{
		[TestCase(1231)]
		public void SetDataCorrectly(int cruiseId)
		{
			//Arrange
			var cruise = new Cruise { Id = cruiseId };

			//Act & Assert
			Assert.AreEqual(cruise.Id, cruiseId);
		}
	}
}
