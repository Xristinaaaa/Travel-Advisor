using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.MessageModel
{
	[TestFixture]
	public class Text_Should
	{
		[Test]
		public void HaveCorrectMinLength()
		{
			//Arrange
			var descriptionProperty = typeof(Message).GetProperty("Text");

			//Act
			var minLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
				.Cast<MinLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinMessageText));
		}

		[Test]
		public void HaveCorrectMaxLength()
		{
			//Arrange
			var descriptionProperty = typeof(Message).GetProperty("Text");

			//Act
			var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
				.Cast<MaxLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxMessageText));
		}

		[TestCase("Best regards")]
		public void GetAndSetDataCorrectly(string text)
		{
			//Arrange
			var message = new Message() { Text = text };

			//Act & Assert
			Assert.AreEqual(message.Text, text);
		}
	}
}
