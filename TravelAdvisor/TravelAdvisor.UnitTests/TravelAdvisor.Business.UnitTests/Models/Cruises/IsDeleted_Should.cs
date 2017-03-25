using NUnit.Framework;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.UnitTests.Models.Cruises
{
	[TestFixture]
	public class IsDeleted_Should
	{
		[TestCase(true)]
		[TestCase(false)]
		public void SetDataCorrectly(bool isDeleted)
		{
			//Arrange
			var cruise = new Cruise { IsDeleted = isDeleted };

			//Act & Assert
			Assert.AreEqual(cruise.IsDeleted, isDeleted);
		}
	}
}
