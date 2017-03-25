using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.MessageModel
{
	[TestFixture]
	public class Title_Should
	{
		[TestCase("Topic: ")]
		public void SetDataCorrectly(string title)
		{
			//Arrange
			var message = new Message { Title = title };

			//Act & Assert
			Assert.AreEqual(message.Title, title);
		}
	}
}
