using NUnit.Framework;
using TravelAdvisor.Business.Models.Destinations;

namespace TravelAdvisor.Business.UnitTests.Models.Destinations
{
	[TestFixture]
	public class IsDeleted_Should
	{
		[TestCase(true)]
		[TestCase(false)]
		public void SetDataCorrectly(bool isDeleted)
		{
			//Arrange
			var destination = new Destination { IsDeleted = isDeleted };

			//Act & Assert
			Assert.AreEqual(destination.IsDeleted, isDeleted);
		}
	}
}
