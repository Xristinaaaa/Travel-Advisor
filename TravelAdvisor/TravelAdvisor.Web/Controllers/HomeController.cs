using System.Web.Mvc;
using Bytes2you.Validation;
using TravelAdvisor.Business.Services.Data.Contracts;

namespace TravelAdvisor.Web.Controllers
{
	public class HomeController : Controller
	{
		private IDestinationService destinationService;

		public HomeController(IDestinationService destinationService)
		{
			Guard.WhenArgument(destinationService, "Destination service is null.").IsNull().Throw();

			this.destinationService = destinationService;
		}

		public ActionResult Index()
		{
			return View();
		}
		
	}
}