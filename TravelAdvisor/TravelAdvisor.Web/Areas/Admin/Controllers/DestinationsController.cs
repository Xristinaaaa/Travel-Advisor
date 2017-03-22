using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAdvisor.Web.Areas.Admin.Controllers
{
    public class DestinationsController : Controller
    {
        // GET: Admin/Destinations
        public ActionResult Index()
        {
            return View();
        }
    }
}