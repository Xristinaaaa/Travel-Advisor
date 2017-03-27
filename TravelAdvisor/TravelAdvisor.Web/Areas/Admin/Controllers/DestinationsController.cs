using System.IO;
using System.Web.Mvc;
using Bytes2you.Validation;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Areas.Admin.Controllers.Base;
using TravelAdvisor.Web.Areas.Admin.Models.Destinations;

namespace TravelAdvisor.Web.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class DestinationsController : BaseController
	{
		private IDestinationService destinationService;
		
		public DestinationsController(IDestinationService destinationService, IMappingService mappingService, IImageService imageService)
			:base(mappingService, imageService)
		{
			Guard.WhenArgument(destinationService, "Destination service is null.").IsNull().Throw();

			this.destinationService = destinationService;
		}

		// GET: Admin/Destinations
		public ActionResult Index()
        {
            return View();
        }

		// GET: Admin/Destinations/Create
		[HttpGet]
		public ActionResult Create()
		{
			return this.View();
		}

		// Post: Admin/Destinations/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(true)]
		public ActionResult Create(DestinationViewModel newDestination)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(newDestination);
			}
			
			var destinationToAdd = this.MappingService.Map<DestinationViewModel, Destination>(newDestination);

			if (newDestination.Image != null)
			{
				if (!this.ImageService.IsImageFile(newDestination.Image))
				{
					ModelState.AddModelError("Image", "The uploaded file is not an image!");
				}

				var path = this.ImageService.MapPath(destinationToAdd.ImagePath);
				newDestination.Image.SaveAs(path);
			}

			if (newDestination.ImageUrl == null && newDestination.Image == null)
			{
				destinationToAdd.ImageUrl = ControllersConstants.defaultDestinationUrl;
			}

			this.destinationService.AddDestination(destinationToAdd);
			return Redirect("/Admin/Administration");
		}
	}
}