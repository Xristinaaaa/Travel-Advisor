using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Models.Trips;

namespace TravelAdvisor.Web.Controllers
{
    [Authorize]
    public class ListTripsController : Controller
    {
		private ITripService tripService;
		private IMappingService mappingService;

		public ListTripsController(ITripService tripService, IMappingService mappingService)
		{
			Guard.WhenArgument(tripService, "Trip service is null.").IsNull().Throw();
			Guard.WhenArgument(mappingService, "Mapping service is null.").IsNull().Throw();

			this.mappingService = mappingService;
			this.tripService = tripService;
		}

		// GET: ListTrips
        [HttpGet]
		public ActionResult Index()
		{
            var tripsModel = new TripsListViewModel();
            List<TripItemViewModel> tripsToAdd = new List<TripItemViewModel>();

            if (this.tripService.GetAllTrips().ToList().Count() > 0)
			{
				var trips = this.tripService.GetAllTrips()
					.Where(t => t.IsDeleted == false && t.FreePlaces > 0)
					.ToList();

				foreach (var item in trips)
				{
					TripItemViewModel trip = this.mappingService.Map<Trip, TripItemViewModel>(item);
					tripsToAdd.Add(trip);
				}
			}

            tripsModel.Trips = tripsToAdd;
            return this.View(tripsModel);
        }
    }
}