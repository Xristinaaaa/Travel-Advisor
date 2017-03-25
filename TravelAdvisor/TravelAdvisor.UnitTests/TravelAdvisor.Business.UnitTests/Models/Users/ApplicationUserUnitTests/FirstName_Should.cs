using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.ApplicationUserUnitTests
{
	[TestFixture]
	public class FirstName_Should
	{
		[Test]
		public void HaveCorrectMinLength()
		{
			//Arrange
			var firstNameProperty = typeof(ApplicationUser).GetProperty("FirstName");

			//Act
			var minLengthAttribute = firstNameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
				.Cast<MinLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMinLength));
		}

		[Test]
		public void HaveCorrectMaxLength()
		{
			//Arrange
			var firstNameProperty = typeof(ApplicationUser).GetProperty("FirstName");

			//Act
			var maxLengthAttribute = firstNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
				.Cast<MaxLengthAttribute>()
				.FirstOrDefault();

			//Assert
			Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMaxLength));
		}

		[TestCase("Ivan")]
		public void GetAndSetDataCorrectly(string userFirstName)
		{
			//Arrange
			var applicationUser = new ApplicationUser() { FirstName = userFirstName };

			//Act & Assert
			Assert.AreEqual(applicationUser.FirstName, userFirstName);
		}
	}
}
