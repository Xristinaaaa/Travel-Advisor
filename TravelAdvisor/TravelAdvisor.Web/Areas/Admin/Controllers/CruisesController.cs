using Bytes2you.Validation;
using System.Collections.Generic;
using System.Web.Mvc;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Cruises;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Areas.Admin.Controllers.Base;
using TravelAdvisor.Web.Areas.Admin.Models.Cruises;

namespace TravelAdvisor.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CruisesController : BaseController
    {
        private ICruiseService cruiseService;
        public CruisesController(ICruiseService cruiseService, IMappingService mappingService, IImageService imageService) 
            : base(mappingService, imageService)
        {
            Guard.WhenArgument(cruiseService, "Cruise service is null.").IsNull().Throw();

            this.cruiseService = cruiseService;
        }

        // GET: Admin/Cruises/Create
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Cruises/Create
        [HttpGet]
        public ActionResult Create()
        {
            var ships = new List<string>();
            var shipsFile = Server.MapPath("~/App_Data/ships.txt");
            
            if (System.IO.File.Exists(shipsFile))
            {
                var data = System.IO.File.ReadAllLines(shipsFile);

                foreach (var ship in data)
                {
                    ships.Add(ship);
                }
            }

            var lines = new List<string>();
            var linesFile = Server.MapPath("~/App_Data/cruiseLines.txt");

            if (System.IO.File.Exists(linesFile))
            {
                var data = System.IO.File.ReadAllLines(linesFile);

                foreach (var line in data)
                {
                    lines.Add(line);
                }
            }

            var ports = new List<string>();
            var portsFile = Server.MapPath("~/App_Data/departurePorts.txt");

            if (System.IO.File.Exists(portsFile))
            {
                var data = System.IO.File.ReadAllLines(portsFile);

                foreach (var port in data)
                {
                    ports.Add(port);
                }
            }

            this.ViewBag.Ships = ships;
            this.ViewBag.Lines = lines;
            this.ViewBag.Ports = ports;

            return this.View();
        }

        // POST: Admin/Cruises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult Create(CruiseViewModel newCruise)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(newCruise);
            }

            var cruiseToAdd = this.MappingService.Map<CruiseViewModel, Cruise>(newCruise);

            if (newCruise.Image != null)
            {
                if (!this.ImageService.IsImageFile(newCruise.Image))
                {
                    ModelState.AddModelError("Image", "The uploaded file is not an image!");
                }

                var path = this.ImageService.MapPath(cruiseToAdd.ImagePath);
                newCruise.Image.SaveAs(path);
            }

            if (newCruise.ImageUrl == null && newCruise.Image == null)
            {
                cruiseToAdd.ImageUrl = ControllersConstants.defaultImageUrl;
            }

            this.cruiseService.AddCruise(cruiseToAdd);
            return Redirect("/Admin/Administration");
        }
    }
}