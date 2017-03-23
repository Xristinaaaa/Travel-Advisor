using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAdvisor.Web.Areas.Admin.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Admin/Administration
		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}