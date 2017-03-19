using System.Data.Entity;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Data.Repositories;
using TravelAdvisor.Business.Models.Destinations.Contracts;

namespace TravelAdvisor.Business.UnitTests.Data.Repository
{
	[TestFixture]
	public class GetById_Should
	{
		[Test]
		public void ReturnCorrectObject_WhenParamIsValid()
		{
			//Arrange
			var mockedDbSet = new Mock<DbSet<IDestination>>();
			var mockedDbContext = new Mock<ITravelAdvisorDbContext>();

			//Act
			mockedDbContext.Setup(mock => mock.Set<IDestination>()).Returns(mockedDbSet.Object);
			var animalRepository = new EFRepository<IDestination>(mockedDbContext.Object);

			var result = new Mock<IDestination>();
			mockedDbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(result.Object);

			//Assert
			var validId = 15;
			Assert.That(animalRepository.GetById(validId), Is.Not.Null);
			Assert.AreEqual(animalRepository.GetById(validId), result.Object);
		}
	}
}
