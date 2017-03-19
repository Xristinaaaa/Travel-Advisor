using System.Data.Entity;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Data.Repositories;
using TravelAdvisor.Business.Models.Destinations.Contracts;

namespace TravelAdvisor.Business.UnitTests.Data.Repository
{
	[TestFixture]
	public class Entities_Should
	{
		[Test]
		public void ReturnCorrectDbSet()
		{
			//Arrange
			var mockedDbContext = new Mock<ITravelAdvisorDbContext>();
			var mockedSet = new Mock<IDbSet<IDestination>>();
			
			//Act
			mockedDbContext.Setup(x => x.Set<IDestination>()).Returns(mockedSet.Object);
			var repository = new EFRepository<IDestination>(mockedDbContext.Object);

			//Assert
			Assert.NotNull(repository.Entities);
			Assert.IsInstanceOf(typeof(IDbSet<IDestination>), repository.Entities);
			Assert.AreSame(repository.Entities, repository.DbSet);
		}
	}
}
