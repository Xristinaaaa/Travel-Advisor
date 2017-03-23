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

		public ActionResult Create()
		{
			return View();
		}
    }
}