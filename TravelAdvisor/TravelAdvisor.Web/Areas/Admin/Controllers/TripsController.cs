using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bytes2you.Validation;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Areas.Admin.Controllers.Base;
using TravelAdvisor.Web.Areas.Admin.Models.Trips;

namespace TravelAdvisor.Web.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	public class TripsController : BaseController
	{
		private ITripService tripService;
		private IDestinationService destinationService;

		public TripsController(ITripService tripService, IDestinationService destinationService, IMappingService mappingService, IImageService imageService)
			:base(mappingService, imageService)
		{
			Guard.WhenArgument(tripService, "Trip service is null.").IsNull().Throw();
			Guard.WhenArgument(destinationService, "Destination service is null.").IsNull().Throw();

			this.tripService = tripService;
			this.destinationService = destinationService;
		}

		// GET: Admin/Trips
		public ActionResult Index()
		{
			return View();
		}

		// GET: Admin/Trips/Create
		[HttpGet]
		public ActionResult Create()
		{
			var countries = new List<string>();

			foreach (var item in destinationService.GetAllDestinations().ToList())
			{
				countries.Add(item.Country);
			}

			this.ViewBag.Destinations = countries;
			return this.View();
		}

		// Post: Admin/Trips/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(TripViewModel newTrip)
		{
			if (!this.ModelState.IsValid)
			{
				var countries = new List<string>();

				foreach (var item in destinationService.GetAllDestinations().ToList())
				{
					countries.Add(item.Country);
				}

				this.ViewBag.Destinations = countries;
				return this.View(newTrip);
			}

			var tripToAdd = this.MappingService.Map<TripViewModel, Trip>(newTrip);
			
			tripToAdd.Destination.Country = newTrip.Destination;
			tripToAdd.Destination = this.destinationService.FindByCountry(newTrip.Destination);
			tripToAdd.DestinationId = tripToAdd.Destination.Id;

			if (newTrip.ImagePath != null)
			{
				if (!this.ImageService.IsImageFile(newTrip.ImagePath))
				{
					ModelState.AddModelError("Image", "The uploaded file is not an image!");
				}
				
				var path = this.ImageService.MapPath(tripToAdd.ImagePath).Substring(0,73)+ "\\Images\\"+newTrip.ImagePath.FileName;
				newTrip.ImagePath.SaveAs(path);
				tripToAdd.ImagePath = "~/Images/" + newTrip.ImagePath.FileName;
			}

			if (newTrip.ImageUrl == null && newTrip.ImagePath == null)
			{
				tripToAdd.ImageUrl = ControllersConstants.defaultDestinationUrl;
			}

			this.tripService.AddTrip(tripToAdd);
			return Redirect("/Admin/Administration");
		}
	}
}