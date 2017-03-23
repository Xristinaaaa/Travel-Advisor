﻿using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Models.Destinations;

namespace TravelAdvisor.Web.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		private int destinationsCount = 6;

		private IDestinationService destinationService;
		private IMappingService mappingService;

		public HomeController(IDestinationService destinationService, IMappingService mappingService)
		{
			Guard.WhenArgument(destinationService, "Destination service is null.").IsNull().Throw();
			Guard.WhenArgument(mappingService, "Mapping service is null.").IsNull().Throw();

			this.destinationService = destinationService;
			this.mappingService = mappingService;
		}

		// Get: /
		public ActionResult Index()
		{
			if (destinationService.GetAllDestinations().ToList().Count() > 0)
			{
				var destinations = destinationService.GetDestinations(0, ControllersConstants.ItemsPerPage)
					.Where(d => d.IsDeleted == false)
					.ProjectTo<DestinationViewModel>()
					.ToList();

				var destinationsModel = new DestinationsListViewModel() { Destinations = destinations };

				return this.View(destinationsModel);
			}
			else
			{
				return this.View();
			}
		}		

		// Post: /
		[HttpPost]
		public ActionResult GetDestinations()
		{
			var moreDestinations = destinationService.GetDestinations(0, destinationsCount + ControllersConstants.DestinationsBatchIncrease)
					.Where(d => d.IsDeleted == false)
					.ProjectTo<DestinationViewModel>()
					.ToList();

			destinationsCount += ControllersConstants.DestinationsBatchIncrease;

			var moreDestinationsModel = new DestinationsListViewModel() { Destinations = moreDestinations };

			return PartialView("PopularDestinations", moreDestinationsModel);
		}
	}
}