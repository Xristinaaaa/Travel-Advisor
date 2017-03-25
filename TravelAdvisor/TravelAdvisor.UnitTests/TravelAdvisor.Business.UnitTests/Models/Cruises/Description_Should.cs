using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.UnitTests.Models.Cruises
{
	[TestFixture]
	public class Description_Should
	{
		[Test]
		public void HaveCorrectMinLength()
		{
			//Arrange
			var descriptionProperty = typeof(Cruise).GetProperty("Description");

			//Act
			var minLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
				.Cast<MinLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinCruiseDescriptionLength));
		}

		[Test]
		public void HaveCorrectMaxLength()
		{
			//Arrange
			var descriptionProperty = typeof(Cruise).GetProperty("Description");

			//Act
			var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
				.Cast<MaxLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxCruiseDescriptionLength));
		}

		[TestCase("The best cruise in the world")]
		public void GetAndSetDataCorrectly(string description)
		{
			//Arrange
			var cruise = new Cruise() { Description = description };

			//Act & Assert
			Assert.AreEqual(cruise.Description, description);
		}
	}
}
