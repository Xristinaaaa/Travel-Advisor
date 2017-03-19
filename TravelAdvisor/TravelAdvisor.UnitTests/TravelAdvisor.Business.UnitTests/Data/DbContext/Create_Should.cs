using NUnit.Framework;
using TravelAdvisor.Business.Data;

namespace TravelAdvisor.Business.UnitTests.Data.DbContext
{
	[TestFixture]
	public class Create_Should
	{
		[Test]
		public void ReturnNewDbContext_WhenParamsAreValid()
		{
			// Arrange & Act
			var newContext = TravelAdvisorDbContext.Create();

			// Assert
			Assert.IsNotNull(newContext);
			Assert.IsInstanceOf<TravelAdvisorDbContext>(newContext);
		}
	}
}
