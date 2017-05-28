using System.Web.Mvc;
using TravelAdvisor.Business.Common.Constants;

namespace TravelAdvisor.Web.Areas.Admin.Controllers
{
	[Authorize(Roles = UserRoles.Admin)]
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