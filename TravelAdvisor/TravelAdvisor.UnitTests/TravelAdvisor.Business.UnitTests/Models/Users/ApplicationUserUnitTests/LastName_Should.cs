using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.ApplicationUserUnitTests
{
	[TestFixture]
	public class LastName_Should
	{
		[Test]
		public void HaveCorrectMinLength()
		{
			//Arrange
			var lastNameProperty = typeof(ApplicationUser).GetProperty("LastName");

			//Act
			var minLengthAttribute = lastNameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
				.Cast<MinLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMinLength));
		}

		[Test]
		public void HaveCorrectMaxLength()
		{
			//Arrange
			var lastNameProperty = typeof(ApplicationUser).GetProperty("LastName");

			//Act
			var maxLengthAttribute = lastNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
				.Cast<MaxLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMaxLength));
		}

		[TestCase("Ivanov")]
		public void GetAndSetDataCorrectly(string userLastName)
		{
			//Arrange
			var applicationUser = new ApplicationUser() { LastName = userLastName };

			//Act & Assert
			Assert.AreEqual(applicationUser.LastName, userLastName);
		}

	}
}
