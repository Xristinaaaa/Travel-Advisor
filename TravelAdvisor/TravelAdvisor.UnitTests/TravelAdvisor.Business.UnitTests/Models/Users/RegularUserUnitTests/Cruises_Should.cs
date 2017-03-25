using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Cruises;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.RegularUserUnitTests
{
	[TestFixture]
	public class Cruises_Should
	{
		[TestCase(3)]
		public void SetDataCorrectly(int cruiseId)
		{
			//Arrange
			var cruise = new Cruise { Id = cruiseId };
			var cruiseSet = new HashSet<Cruise> { cruise };
			var regularUser = new RegularUser { Cruises = cruiseSet };

			//Act & Assert
			Assert.AreEqual(regularUser.Cruises.First().Id, cruiseId);
		}
	}
}
