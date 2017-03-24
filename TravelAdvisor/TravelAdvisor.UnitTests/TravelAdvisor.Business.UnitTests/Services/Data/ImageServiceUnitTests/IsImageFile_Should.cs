using System;
using System.Web;
using NUnit.Framework;
using TravelAdvisor.Business.Services.Data;

namespace TravelAdvisor.Business.UnitTests.Services.Data.ImageServiceUnitTests
{
	[TestFixture]
	public class IsImageFile_Should
	{
		[TestCase(null)]
		public void ReturnTrue_WhenFileIsValid(HttpPostedFileBase file)
		{
			//Arrange
			var imageService = new ImageService();

			//Act & Assert
			Assert.IsTrue(imageService.IsImageFile(file));
		}
	}
}
