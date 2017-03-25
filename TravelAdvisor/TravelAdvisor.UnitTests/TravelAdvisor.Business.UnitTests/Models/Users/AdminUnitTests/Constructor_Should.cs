using System;
using System.Collections.Generic;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.AdminUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void IstanceAdmin()
		{
			//Arrange
			var admin = new Admin();

			//Act & Assert
			Assert.IsInstanceOf<Admin>(admin);
		}

		[Test]
		public void Constructor_ShouldInitializeCarRentalsCollection()
		{
			//Arrange
			var admin = new Admin();
			var carRentals = admin.CarRentals;

			//Act & Assert
			Assert.That(carRentals, Is.Not.Null.And.InstanceOf<HashSet<CarRental>>());
		}

		[Test]
		public void Constructor_ShouldInitializeFlightRequestsCollection()
		{
			//Arrange
			var admin = new Admin();
			var flightRequests = admin.FlightRequests;

			//Act & Assert
			Assert.That(flightRequests, Is.Not.Null.And.InstanceOf<HashSet<FlightRequest>>());
		}

		[Test]
		public void Constructor_ShouldInitializeMessagesCollection()
		{
			//Arrange
			var admin = new Admin();
			var messages = admin.Messages;

			//Act & Assert
			Assert.That(messages, Is.Not.Null.And.InstanceOf<HashSet<Message>>());
		}
	}
}
