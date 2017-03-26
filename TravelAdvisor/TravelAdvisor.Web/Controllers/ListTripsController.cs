using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Web.Models.Trips;

namespace TravelAdvisor.Web.Controllers
{
    public class ListTripsController : Controller
    {
		private ITripService tripService;

		public ListTripsController(ITripService tripService)
		{
			Guard.WhenArgument(tripService, "Trip service is null.").IsNull().Throw();

			this.tripService = tripService;
		}

		// GET: Trips
		public ActionResult Index()
		{
			if (tripService.GetAllTrips().ToList().Count() > 0)
			{
				var trips = tripService.GetAllTrips()
					.Where(d => d.IsDeleted == false && d.FreePlaces > 0 && d.StartDate < DateTime.UtcNow)
					.ProjectTo<TripItemViewModel>()
					.ToList();

				var tripsModel = new TripsListViewModel() { Trips = trips};

				return this.View(tripsModel);
			}
			else
			{
				return this.View();
			}
		}
    }
}