using NUnit.Framework;
using TravelAdvisor.Business.Models.Destinations;

namespace TravelAdvisor.Business.UnitTests.Models.Destinations
{
	[TestFixture]
	public class Id_Should
	{
		[TestCase(1231)]
		public void SetDataCorrectly(int destinationId)
		{
			//Arrange
			var destination = new Destination { Id = destinationId };

			//Act & Assert
			Assert.AreEqual(destination.Id, destinationId);
		}
	}
}
