using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TravelAdvisor.Business.Identity;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic.Contracts;
using TravelAdvisor.Web.Models.Manage;
using TravelAdvisor.Web.Models.Trips;

namespace TravelAdvisor.Web.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
		private IUserService userService;
		private IMappingService mappingService;
		private IDestinationService destinationService;
		private ITripService tripService;

		public ManageController(IUserService userService, IMappingService mappingService, 
			IDestinationService destinationService, ITripService tripService)
		{
			Guard.WhenArgument(userService, "User service is null.").IsNull().Throw();
			Guard.WhenArgument(mappingService, "Mapping service is null.").IsNull().Throw();
			Guard.WhenArgument(destinationService, "Destination service is null.").IsNull().Throw();
			Guard.WhenArgument(tripService, "Trip service is null.").IsNull().Throw();

			this.userService = userService;
			this.mappingService = mappingService;
			this.destinationService = destinationService;
			this.tripService = tripService;
		}

		public ApplicationSignInManager SignInManager
        {
            get
            {
                 return HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
		
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";

            var userId = User.Identity.GetUserId();

			IndexViewModel model;
			if (TempData["Model"] != null)
			{
				model = (IndexViewModel)TempData["Model"];
			}
			else
			{
				model = new IndexViewModel();
			}

			model.HasPassword = HasPassword();
			model.Logins = await UserManager.GetLoginsAsync(userId);
			model.BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId);

			if (User.IsInRole("RegularUser") && model.UserTrips == null)
			{
				var userTrips = this.userService.GetUserTrips(userId);

				var userTripsModel = new TripsListViewModel();

				List<TripItemViewModel> tripsToAdd = new List<TripItemViewModel>();

				foreach (var item in userTrips)
				{
					TripItemViewModel userTrip = this.mappingService.Map<Trip, TripItemViewModel>(item);
					tripsToAdd.Add(userTrip);
				}

				userTripsModel.Trips = tripsToAdd;
				model.UserTrips = userTripsModel;
			}

			TempData.Remove("Model");
			return View(model);
        }

		//POST /Manage
		public ActionResult AddToWishList(int id)
		{
			var model = new IndexViewModel();
			var userId = this.User.Identity.GetUserId();

			Trip tripToService = this.tripService.FindTrip(id);
			this.userService.AddTripToWishlist(tripToService, userId);

			TripsListViewModel userTripsModel = new TripsListViewModel();
			var userTrips = this.userService.GetUserTrips(userId);

			List<TripItemViewModel> allTrips = new List<TripItemViewModel>();

			foreach (var item in userTrips)
			{
				TripItemViewModel userTrip = this.mappingService.Map<Trip, TripItemViewModel>(item);
				allTrips.Add(userTrip);
			}

			userTripsModel.Trips = allTrips;

			model.UserTrips = userTripsModel;

			TempData["Model"] = model;
			return RedirectToAction("Index");
		}

		// GET: /Manage/ChangePassword
		public ActionResult ChangePassword()
        {
            return View();
        }
		
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return this.RedirectToAction<ManageController>(c=>c.Index(ManageMessageId.ChangePasswordSuccess));
            }
            AddErrors(result);
            return View(model);
        }
		
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }
		
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
					return this.RedirectToAction<ManageController>(c => c.Index(ManageMessageId.SetPasswordSuccess));
                }
                AddErrors(result);
            }
			
            return View(model);
        }

#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }
#endregion
    }
}