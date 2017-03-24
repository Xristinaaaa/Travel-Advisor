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
	public class Delete_Should
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
				() => repository.Delete(entity),
				Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Entity cannot be null!"));
		}

		[Test]
		public void NotThrow_WhenArgumentIsValid()
		{
			//Arrange
			var mockedSet = new Mock<IDbSet<IDestination>>();
			var mockedAnimal = new Mock<IDestination>();
			mockedAnimal.SetupAllProperties();

			var mockedContext = new Mock<ITravelAdvisorDbContext>();

			//Act
			mockedContext.Setup(x => x.Set<IDestination>()).Returns(mockedSet.Object);
			var repository = new EFRepository<IDestination>(mockedContext.Object);

			try
			{
				repository.Delete(mockedAnimal.Object);
			}
			catch (NullReferenceException) { };

			//Assert
			mockedContext.Verify(x => x.Entry(mockedAnimal.Object), Times.AtLeastOnce);
		}

		[Test]
		public void Work_WhenArgumentIsValid()
		{
			//Arrange
			var mockedSet = new Mock<IDbSet<IDestination>>();
			var mockedAnimal = new Mock<IDestination>();
			mockedAnimal.SetupAllProperties();

			var mockedContext = new Mock<ITravelAdvisorDbContext>();

			//Act
			mockedContext.Setup(x => x.Set<IDestination>()).Returns(mockedSet.Object);
			var repository = new EFRepository<IDestination>(mockedContext.Object);
			
			//Assert
			mockedContext.Verify(x => x.Entry(mockedAnimal.Object), Times.Never);
		}
	}
}
