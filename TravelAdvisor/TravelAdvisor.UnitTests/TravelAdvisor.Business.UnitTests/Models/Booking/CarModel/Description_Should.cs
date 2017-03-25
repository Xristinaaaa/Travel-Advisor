using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarModel
{
	[TestFixture]
	public class Description_Should
	{
		[Test]
		public void HaveCorrectMinLength()
		{
			//Arrange
			var descriptionProperty = typeof(Car).GetProperty("Description");

			//Act
			var minLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
				.Cast<MinLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinCarDescriptionLength));
		}

		[Test]
		public void HaveCorrectMaxLength()
		{
			//Arrange
			var descriptionProperty = typeof(Car).GetProperty("Description");

			//Act
			var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
				.Cast<MaxLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxCarDescriptionLength));
		}

		[TestCase("The best car in the world")]
		public void GetAndSetDataCorrectly(string description)
		{
			//Arrange
			var car = new Car() { Description = description };

			//Act & Assert
			Assert.AreEqual(car.Description, description);
		}
	}
}
