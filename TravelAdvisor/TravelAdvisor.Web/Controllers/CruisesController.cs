using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TravelAdvisor.Business.Models.Cruises;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Models.Cruises;

namespace TravelAdvisor.Web.Controllers
{
    [Authorize]
    public class CruisesController : Controller
    {
        private ICruiseService cruiseService;
        private IMappingService mappingService;
        public CruisesController(ICruiseService cruiseService, IMappingService mappingService)
        {
            Guard.WhenArgument(cruiseService, "Cruise service is null.").IsNull().Throw();
            Guard.WhenArgument(mappingService, "Mapping service is null.").IsNull().Throw();

            this.mappingService = mappingService;
            this.cruiseService = cruiseService;
        }

        // GET: Cruises
        [HttpGet]
        public ActionResult Index()
        {
            var cruiseModel = new CruisesListViewModel();
            List<CruiseItemViewModel> cruisesToAdd = new List<CruiseItemViewModel>();

            if (this.cruiseService.GetAll().ToList().Count() > 0)
            {
                var cruises = this.cruiseService.GetAll()
                    .Where(c => c.IsDeleted == false && c.FreePlaces > 0)
                    .ToList();

                foreach (var item in cruises)
                {
                    CruiseItemViewModel cruise = this.mappingService.Map<Cruise, CruiseItemViewModel>(item);
                    cruisesToAdd.Add(cruise);
                }
            }

            cruiseModel.Cruises = cruisesToAdd;
            return this.View(cruiseModel);
        }
    }
}