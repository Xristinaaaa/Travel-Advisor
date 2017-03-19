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
	public class Constructor_Should
	{
		[Test]
		public void ThrowArgumentNullException_WhenDbContextIsNull()
		{
			// Arrange              
			ITravelAdvisorDbContext nullContext = null;

			// Act & Assert
			Assert.That(() => new EFRepository<IDestination>(nullContext),
				Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Db context is null!"));
		}

		[Test]
		public void WorkCorrectly_WhenValidArgumentsPassed()
		{
			// Arrange
			var mockedDbContext = new Mock<ITravelAdvisorDbContext>();
			var mockedDestination = new Mock<DbSet<IDestination>>();
			mockedDbContext.Setup(x => x.Set<IDestination>()).Returns(mockedDestination.Object);

			// Act
			var repository = new EFRepository<IDestination>(mockedDbContext.Object);

			// Assert
			Assert.That(repository, Is.Not.Null);
		}

		[Test]
		public void SetContextCorrectly_WhenValidArgumentsPassed()
		{
			// Arrange
			var mockedDbContext = new Mock<ITravelAdvisorDbContext>();
			var mockedDestination = new Mock<DbSet<IDestination>>();
			mockedDbContext.Setup(x => x.Set<IDestination>()).Returns(mockedDestination.Object);

			// Act
			var repository = new EFRepository<IDestination>(mockedDbContext.Object);

			// Assert
			Assert.That(repository.Context, Is.Not.Null);
			Assert.That(repository.Context, Is.EqualTo(mockedDbContext.Object));
		}

		[Test]
		public void SetDbSetCorrectly_WhenValidArgumentsPassed()
		{
			// Arrange
			var mockedDbContext = new Mock<ITravelAdvisorDbContext>();
			var mockedDestination = new Mock<DbSet<IDestination>>();
			mockedDbContext.Setup(x => x.Set<IDestination>()).Returns(mockedDestination.Object);

			// Act
			var repository = new EFRepository<IDestination>(mockedDbContext.Object);

			// Assert
			Assert.That(repository.DbSet, Is.Not.Null);
			Assert.That(repository.DbSet, Is.EqualTo(mockedDestination.Object));
		}
	}
}