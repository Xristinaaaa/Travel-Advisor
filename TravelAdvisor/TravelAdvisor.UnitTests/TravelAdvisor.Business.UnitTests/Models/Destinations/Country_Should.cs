using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Destinations;

namespace TravelAdvisor.Business.UnitTests.Models.Destinations
{
	[TestFixture]
	public class Country_Should
	{
		[Test]
		public void HaveCorrectMinLength()
		{
			//Arrange
			var countryProperty = typeof(Destination).GetProperty("Country");

			//Act
			var minLengthAttribute = countryProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
				.Cast<MinLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinCountryLength));
		}

		[Test]
		public void HaveCorrectMaxLength()
		{
			//Arrange
			var countryProperty = typeof(Destination).GetProperty("Country");

			//Act
			var maxLengthAttribute = countryProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
				.Cast<MaxLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxCountryLength));
		}

		[TestCase("Bulgaria")]
		public void GetAndSetDataCorrectly(string countryName)
		{
			//Arrange
			var destination = new Destination() { Country = countryName };

			//Act & Assert
			Assert.AreEqual(destination.Country, countryName);
		}
	}
}
