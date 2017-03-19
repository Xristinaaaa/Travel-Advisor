using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Data.UnitOfWork;

namespace TravelAdvisor.Business.UnitTests.Data.UnitofWork
{
	[TestFixture]
	public class SaveChanges_Should
	{
		[Test]
		public void BeInvokedOnce()
		{
			//Arrange
			var mockedContext = new Mock<ITravelAdvisorDbContext>();
			var unitOfWork = new UnitOfWork(mockedContext.Object);

			//Act
			unitOfWork.SaveChanges();

			//Assert
			mockedContext.Verify(mock => mock.SaveChanges(), Times.Once());
		}
	}
}
