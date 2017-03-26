using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Models.Trips;

namespace TravelAdvisor.Web.Controllers
{
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

		// GET: Trips
		public ActionResult Index()
		{
			if (tripService.GetAllTrips().ToList().Count() > 0)
			{
				var trips = tripService.GetAllTrips()
					.Where(d => d.IsDeleted == false && d.FreePlaces > 0)
					.ToList();

				var tripsModel = new TripsListViewModel();

				List<TripItemViewModel> tripsToAdd = new List<TripItemViewModel>();

				foreach (var item in trips)
				{
					TripItemViewModel trip = this.mappingService.Map<Trip, TripItemViewModel>(item);
					tripsToAdd.Add(trip);
				}

				tripsModel.Trips = tripsToAdd;

				return this.View(tripsModel);
			}
			else
			{
				return this.View();
			}
		}
    }
}