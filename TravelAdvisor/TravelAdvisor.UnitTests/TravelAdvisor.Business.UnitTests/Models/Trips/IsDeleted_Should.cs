using NUnit.Framework;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Trips
{
	[TestFixture]
	public class IsDeleted_Should
	{
		[TestCase(true)]
		[TestCase(false)]
		public void SetDataCorrectly(bool isDeleted)
		{
			//Arrange
			var trip = new Trip { IsDeleted = isDeleted };

			//Act & Assert
			Assert.AreEqual(trip.IsDeleted, isDeleted);
		}
	}
}
