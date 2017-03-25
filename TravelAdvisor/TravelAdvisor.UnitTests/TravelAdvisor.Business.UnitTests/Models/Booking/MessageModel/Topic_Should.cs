using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.MessageModel
{
	[TestFixture]
	public class Topic_Should
	{
		[TestCase("Title")]
		public void SetDataCorrectly(string topic)
		{
			//Arrange
			var message = new Message { Topic = topic };

			//Act & Assert
			Assert.AreEqual(message.Topic, topic);
		}
	}
}
