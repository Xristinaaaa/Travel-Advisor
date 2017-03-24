using System.Web.Mvc;

namespace TravelAdvisor.Web.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        // GET: Admin/Administration
        public ActionResult Index()
        {
            return View();
        }
	}
}