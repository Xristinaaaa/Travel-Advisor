using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Web.Areas.Admin.Models.Destinations;
using TravelAdvisor.Web.Models.Destinations;

namespace TravelAdvisor.Web.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		private int destinationsCount = 6;

		private IDestinationService destinationService;

		public HomeController(IDestinationService destinationService)
		{
			Guard.WhenArgument(destinationService, "Destination service is null.").IsNull().Throw();

			this.destinationService = destinationService;
		}

		// GET: /
		public ActionResult Index()
		{
			if (this.destinationService.GetAllDestinations().ToList().Count() > 0)
			{
				var destinations = this.destinationService.GetDestinations(0, ControllersConstants.ItemsPerPage)
					.Where(d => d.IsDeleted == false)
					.ProjectTo<DestinationItemViewModel>()
					.OrderBy(x=>x.Country)
					.ToList();

				var destinationsModel = new DestinationsListViewModel() { Destinations = destinations };

				return this.View(destinationsModel);
			}
			else
			{
				return this.View();
			}
		}		

		// POST: /
		[HttpPost]
		public ActionResult GetDestinations()
		{
			var moreDestinations = this.destinationService.GetDestinations(0, destinationsCount + ControllersConstants.DestinationsBatchIncrease)
					.Where(d => d.IsDeleted == false)
					.ProjectTo<DestinationItemViewModel>()
					.ToList();

			destinationsCount += ControllersConstants.DestinationsBatchIncrease;

			var moreDestinationsModel = new DestinationsListViewModel() { Destinations = moreDestinations };

			return PartialView("PopularDestinations", moreDestinationsModel);
		}
	}
}