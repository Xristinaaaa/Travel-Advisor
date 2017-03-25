using System;
using System.Collections.Generic;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Destinations
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void IstanceDestination()
		{
			//Arrange
			var destination = new Destination();

			//Act & Assert
			Assert.IsInstanceOf<Destination>(destination);
		}

		[Test]
		public void Constructor_ShouldInitializeTripsCollection()
		{
			//Arrange
			var destination = new Destination();
			var trips = destination.Trips;

			//Act & Assert
			Assert.That(trips, Is.Not.Null.And.InstanceOf<HashSet<Trip>>());
		}

		[TestCase("Bulgaria")]
		public void Constructor_ShouldSetCountryName(string country)
		{
			//Arrange
			var destination = new Destination(country);

			//Act & Assert
			Assert.AreEqual(country, destination.Country);
		}
	}
}
