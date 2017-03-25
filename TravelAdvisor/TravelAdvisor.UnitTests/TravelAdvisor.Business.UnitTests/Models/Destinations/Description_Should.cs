using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Destinations;

namespace TravelAdvisor.Business.UnitTests.Models.Destinations
{
	[TestFixture]
	public class Description_Should
	{
		[Test]
		public void HaveCorrectMinLength()
		{
			//Arrange
			var descriptionProperty = typeof(Destination).GetProperty("Description");

			//Act
			var minLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
				.Cast<MinLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinDestinationDescriptionLength));
		}

		[Test]
		public void HaveCorrectMaxLength()
		{
			//Arrange
			var descriptionProperty = typeof(Destination).GetProperty("Description");

			//Act
			var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
				.Cast<MaxLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxDestinationDescriptionLength));
		}

		[TestCase("The best place in the world")]
		public void GetAndSetDataCorrectly(string description)
		{
			//Arrange
			var destination = new Destination() { Description = description };

			//Act & Assert
			Assert.AreEqual(destination.Description, description);
		}
	}
}
