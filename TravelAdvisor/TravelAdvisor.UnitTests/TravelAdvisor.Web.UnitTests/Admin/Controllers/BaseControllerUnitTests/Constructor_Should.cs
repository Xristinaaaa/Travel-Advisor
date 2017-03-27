using System;
using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Areas.Admin.Controllers.Base;

namespace TravelAdvisor.Web.UnitTests.Admin.Controllers.BaseControllerUnitTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateBaseController_WhenParamsAreValid()
		{
			// Arrange
			var mockedImageService = new Mock<IImageService>();
			var mockedMappingService = new Mock<IMappingService>();
			var baseController = new BaseController(mockedMappingService.Object, mockedImageService.Object);

			//Act & Assert
			Assert.That(baseController, Is.InstanceOf<BaseController>());
		}

		[Test]
		public void ThrowNullException_WhenImageServiceIsNull()
		{
			//Arrange
			Mock<IImageService> mockedImageService = null;
			var mockedMappingService = new Mock<IMappingService>();

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new BaseController(mockedMappingService.Object, mockedImageService.Object));
		}

		[Test]
		public void ThrowNullException_WhenMappingServiceIsNull()
		{
			//Arrange
			var mockedImageService = new Mock<IImageService>();
			Mock<IMappingService> mockedMappingService = null;

			//Act & Assert
			Assert.Throws<NullReferenceException>(() => new BaseController(mockedMappingService.Object, mockedImageService.Object));
		}
	}
}
