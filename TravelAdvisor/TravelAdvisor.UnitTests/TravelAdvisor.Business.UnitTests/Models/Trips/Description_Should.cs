using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.UnitTests.Models.Trips
{
	[TestFixture]
	public class Description_Should
	{
		[Test]
		public void HaveCorrectMinLength()
		{
			//Arrange
			var descriptionProperty = typeof(Trip).GetProperty("Description");

			//Act
			var minLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
				.Cast<MinLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinTripDescriptionLength));
		}

		[Test]
		public void HaveCorrectMaxLength()
		{
			//Arrange
			var descriptionProperty = typeof(Trip).GetProperty("Description");

			//Act
			var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
				.Cast<MaxLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxTripDescriptionLength));
		}

		[TestCase("The best trip.")]
		public void GetAndSetDataCorrectly(string description)
		{
			//Arrange
			var trip = new Trip() { Description = description };

			//Act & Assert
			Assert.AreEqual(trip.Description, description);
		}
	}
}
