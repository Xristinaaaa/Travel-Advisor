using System.Collections.Generic;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Cruises;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.RegularUserUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void InstantiateRegularUser()
		{
			//Arrange
			var regularUser = new RegularUser();

			//Act & Assert
			Assert.IsInstanceOf<RegularUser>(regularUser);
		}

		[Test]
		public void Constructor_ShouldInitializeCarRentalsCollection()
		{
			//Arrange
			var regularUser = new RegularUser();
			var carRentals = regularUser.CarRentals;

			//Act & Assert
			Assert.That(carRentals, Is.Not.Null.And.InstanceOf<HashSet<CarRental>>());
		}

		[Test]
		public void Constructor_ShouldInitializeCruisesCollection()
		{
			//Arrange
			var regularUser = new RegularUser();
			var flightRequests = regularUser.Cruises;

			//Act & Assert
			Assert.That(flightRequests, Is.Not.Null.And.InstanceOf<HashSet<Cruise>>());
		}

		[Test]
		public void Constructor_ShouldInitializeMessagesCollection()
		{
			//Arrange
			var regularUser = new RegularUser();
			var messages = regularUser.Messages;

			//Act & Assert
			Assert.That(messages, Is.Not.Null.And.InstanceOf<HashSet<Message>>());
		}
	}
}
