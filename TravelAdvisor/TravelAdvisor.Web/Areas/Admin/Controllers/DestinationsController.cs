using System.IO;
using System.Web.Mvc;
using Bytes2you.Validation;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Models.Destinations;

namespace TravelAdvisor.Web.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class DestinationsController : Controller
	{
		private IMappingService mappingService;
		private IImageService imageService;
		private IDestinationService destinationService;
		
		public DestinationsController(IDestinationService destinationService, IMappingService mappingService, IImageService imageService)
		{
			Guard.WhenArgument(destinationService, "Destination service is null.").IsNull().Throw();
			Guard.WhenArgument(mappingService, "Mapping service is null.").IsNull().Throw();
			Guard.WhenArgument(imageService, "Image service is null.").IsNull().Throw();

			this.destinationService = destinationService;
			this.mappingService = mappingService;
			this.imageService = imageService;
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
		public ActionResult Create(DestinationViewModel newDestination)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(newDestination);
			}
			
			var destinationToAdd = this.mappingService.Map<DestinationViewModel, Destination>(newDestination);

			if (newDestination.Image != null)
			{
				if (!this.imageService.IsImageFile(newDestination.Image))
				{
					ModelState.AddModelError("Image", "The uploaded file is not an image!");
				}

				var path = Path.Combine(this.Server.MapPath(destinationToAdd.ImagePath));
				newDestination.Image.SaveAs(path);
			}

			if (newDestination.ImageUrl == null && newDestination.Image == null)
			{
				destinationToAdd.ImageUrl = ControllersConstants.defaultDestinationUrl;
			}

			this.destinationService.AddDestination(destinationToAdd);
			return Redirect("/");
		}
	}
}