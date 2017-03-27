using System.Web.Mvc;

namespace TravelAdvisor.Web.Controllers
{
    public class ErrorPagesController : Controller
	{
		//GET: ErrorPage 400
		public ActionResult Page400()
		{
			return View();
		}

		//GET: ErrorPage 404
		public ActionResult Page404()
		{
			return View();
		}

		//GET: ErrorPage 500
		public ActionResult Page500()
		{
			return View();
		}
	}
}