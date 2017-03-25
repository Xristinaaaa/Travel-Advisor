using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.CarModel
{
	[TestFixture]
	public class Model_Shouldcs
	{
		[TestCase("BMW")]
		public void SetDataCorrectly(string model)
		{
			//Arrange
			var car = new Car { Model = model };

			//Act & Assert
			Assert.AreEqual(car.Model, model);
		}
	}
}
