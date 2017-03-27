using Moq;
using NUnit.Framework;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Areas.Admin.Controllers.Base;

namespace TravelAdvisor.Web.UnitTests.Admin.Controllers.BaseControllerUnitTests
{
	[TestFixture]
	public class MappinService_Should
	{
		[Test]
		public void ReturnMappingServiceInstance()
		{           
			// Arrange
			var mockedImageService = new Mock<IImageService>();
			var mockedMappingService = new Mock<IMappingService>();
			var baseController = new BaseController(mockedMappingService.Object, mockedImageService.Object);

			//Act & Assert
			Assert.IsInstanceOf<IMappingService>(baseController.MappingService);
		}
	}
}
