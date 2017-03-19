using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Data.UnitOfWork;

namespace TravelAdvisor.Business.UnitTests.Data.UnitofWork
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void ThrowArgumentNullException_WhenDbContextIsNull()
		{
			//Arrange
			ITravelAdvisorDbContext nullContext = null;

			//Act & Assert
			Assert.That(() => new UnitOfWork(nullContext),
				Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Db context is null!"));
		}

		[Test]
		public void ShouldWork_WhenParamsAreValid()
		{
			//Arrange & Act
			var mockDbContext = new Mock<ITravelAdvisorDbContext>();
			var uow = new UnitOfWork(mockDbContext.Object);

			//Assert
			Assert.IsNotNull(uow);
		}

		[Test]
		public void CreateUowThatImplementsIDisposableAndIUnitOfWork_WhenParametersAreValid()
		{
			//Arrange & Act
			var mockDbContext = new Mock<ITravelAdvisorDbContext>();
			var uow = new UnitOfWork(mockDbContext.Object);

			//Assert
			Assert.IsInstanceOf<IDisposable>(uow);
			Assert.IsInstanceOf<IUnitOfWork>(uow);
		}
	}
}
