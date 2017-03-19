using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Data.UnitOfWork;

namespace TravelAdvisor.Business.UnitTests.Data.UnitofWork
{
	[TestFixture]
	public class Dispose_Should
	{
		[Test]
		public void BeInvokedOnce()
		{
			//Arrange
			var dbContext = new Mock<ITravelAdvisorDbContext>();
			var unitOfWork = new UnitOfWork(dbContext.Object);

			//Act
			unitOfWork.Dispose();

			//Assert
			dbContext.Verify(u => u.Dispose(), Times.Once);
		}
	}
}
