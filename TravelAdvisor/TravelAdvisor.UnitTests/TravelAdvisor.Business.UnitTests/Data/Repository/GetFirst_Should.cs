using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Data.Repositories;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Models.Destinations.Contracts;

namespace TravelAdvisor.Business.UnitTests.Data.Repository
{
	[TestFixture]
	public class GetFirst_Should
	{
		[TestCase("France")]
		public void ReturnCorrectObject_IfFound(string nameSearch)
		{
			// Arrange
			var data = new List<IDestination>
			{
				new Destination { Country = "France" },
				new Destination { Country = "Germany" },
			}.AsQueryable();

			var mockedSet = new Mock<IDbSet<IDestination>>();
			mockedSet.As<IQueryable<IDestination>>().Setup(x => x.Provider).Returns(data.Provider);
			mockedSet.As<IQueryable<IDestination>>().Setup(x => x.Expression).Returns(data.Expression);
			mockedSet.As<IQueryable<IDestination>>().Setup(x => x.ElementType).Returns(data.ElementType);
			mockedSet.As<IQueryable<IDestination>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

			var mockedDbContenxt = new Mock<ITravelAdvisorDbContext>();
			mockedDbContenxt.Setup(x => x.Set<IDestination>()).Returns(mockedSet.Object);

			// Act                           
			var repository = new EFRepository<IDestination>(mockedDbContenxt.Object);
			var result = repository.GetFirst(x => x.Country == nameSearch);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.AreEqual(result.Country, nameSearch);
		}
	}
}
