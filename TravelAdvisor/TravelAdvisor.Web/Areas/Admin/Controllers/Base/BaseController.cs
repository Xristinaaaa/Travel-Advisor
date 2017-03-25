using System.Web.Mvc;
using Bytes2you.Validation;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;

namespace TravelAdvisor.Web.Areas.Admin.Controllers.Base
{
    public class BaseController : Controller
	{
		private IMappingService mappingService;
		private IImageService imageService;

		public BaseController(IMappingService mappingService, IImageService imageService)
		{
			Guard.WhenArgument(mappingService, "Mapping service is null.").IsNull().Throw();
			Guard.WhenArgument(imageService, "Image service is null.").IsNull().Throw();

			this.mappingService = mappingService;
			this.imageService = imageService;
		}

		public IMappingService MappingService
		{
			get
			{
				return this.mappingService;
			}
		}

		public IImageService ImageService
		{
			get
			{
				return this.imageService;
			}
		}
	}
}