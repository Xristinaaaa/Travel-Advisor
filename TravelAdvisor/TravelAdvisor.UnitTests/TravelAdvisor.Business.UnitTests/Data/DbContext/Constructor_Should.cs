using NUnit.Framework;
using TravelAdvisor.Business.Data;
using TravelAdvisor.Business.Data.Contracts;

namespace TravelAdvisor.Business.UnitTests.Data.DbContext
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void ReturnInstanceOfITravelAdvisorDbContext_WhenParamsAreValid()
		{
			//Arrange
			var context = new TravelAdvisorDbContext();

			//Act & Assert
			Assert.IsInstanceOf<TravelAdvisorDbContext>(context);
		}
	}
}
