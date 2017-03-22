using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Models.Destinations;

namespace TravelAdvisor.Web.Controllers
{
	public class HomeController : Controller
	{
		private const int ItemsPerPage = 6;
		private const int StartIndex = 0;
		private const int DestinationsBatchIncrease = 3;
		private int DestinationsCount = 6;

		private IDestinationService destinationService;
		private IMappingService mappingService;

		public HomeController(IDestinationService destinationService, IMappingService mappingService)
		{
			Guard.WhenArgument(destinationService, "Destination service is null.").IsNull().Throw();
			Guard.WhenArgument(mappingService, "Mapping service is null.").IsNull().Throw();

			this.destinationService = destinationService;
			this.mappingService = mappingService;
		}

		public ActionResult Index()
		{
			var destinations = destinationService.GetDestinations(0, ItemsPerPage)
				.Where(d=>d.IsDeleted == false)
				.ProjectTo<DestinationViewModel>()
				.ToList();
			
			var destinationsModel = new DestinationsListViewModel() { Destinations = destinations };

			return this.View(destinationsModel);
		}		

		[HttpPost]
		public ActionResult GetDestinations()
		{
			var moreDestinations = destinationService.GetDestinations(0, DestinationsCount + DestinationsBatchIncrease)
					.Where(d => d.IsDeleted == false)
					.ProjectTo<DestinationViewModel>()
					.ToList();

			DestinationsCount += DestinationsBatchIncrease;

			var moreDestinationsModel = new DestinationsListViewModel() { Destinations = moreDestinations };

			return PartialView("PopularDestinations", moreDestinationsModel);
		}
	}
}