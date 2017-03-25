using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.MessageModel
{
	[TestFixture]
	public class Id_Should
	{
		[TestCase(5)]
		public void SetDataCorrectly(int messageId)
		{
			//Arrange
			var message = new Message { Id = messageId };

			//Act & Assert
			Assert.AreEqual(message.Id, messageId);
		}
	}
}
