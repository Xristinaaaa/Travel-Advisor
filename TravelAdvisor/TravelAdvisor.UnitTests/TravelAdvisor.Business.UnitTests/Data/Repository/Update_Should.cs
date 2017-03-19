using System;
using System.Data.Entity;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Data.Repositories;
using TravelAdvisor.Business.Models.Destinations.Contracts;

namespace TravelAdvisor.Business.UnitTests.Data.Repository
{
	[TestFixture]
	public class Update_Should
	{
		[Test]
		public void ThrowArgumentNullException_WhenArgumentIsNull()
		{
			//Arrange
			var mockedSet = new Mock<DbSet<IDestination>>();
			var mockedDbContext = new Mock<ITravelAdvisorDbContext>();

			//Act
			mockedDbContext.Setup(mock => mock.Set<IDestination>()).Returns(mockedSet.Object);
			var repository = new EFRepository<IDestination>(mockedDbContext.Object);
			IDestination entity = null;

			//Assert
			Assert.That(
				() => repository.Update(entity),
				Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Entity cannot be null!"));
		}

		[Test]
		public void NotThrow_WhenArgumentIsValid()
		{
			//Arrange
			var mockedSet = new Mock<IDbSet<IDestination>>();
			var mockedDestination = new Mock<IDestination>();
			mockedDestination.SetupAllProperties();

			var mockedDbContext = new Mock<ITravelAdvisorDbContext>();

			//Act
			mockedDbContext.Setup(x => x.Set<IDestination>()).Returns(mockedSet.Object);
			var repository = new EFRepository<IDestination>(mockedDbContext.Object);

			try
			{
				repository.Update(mockedDestination.Object);
			}
			catch (NullReferenceException) { };

			//Assert
			mockedDbContext.Verify(x => x.Entry(mockedDestination.Object), Times.AtLeastOnce);
		}
	}
}
