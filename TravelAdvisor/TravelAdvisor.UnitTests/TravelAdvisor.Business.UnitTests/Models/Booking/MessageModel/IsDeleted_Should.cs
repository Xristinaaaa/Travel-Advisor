using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.MessageModel
{
	[TestFixture]
	public class IsDeleted_Should
	{
		[TestCase(true)]
		[TestCase(false)]
		public void SetDataCorrectly(bool isDeleted)
		{
			//Arrange
			var message = new Message { IsDeleted = isDeleted };

			//Act & Assert
			Assert.AreEqual(message.IsDeleted, isDeleted);
		}
	}
}
