using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Presentation.Attributes;
using Presentation.ViewModels;
using SecurityService;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private IAccountManager _accManager;

        public HomeController()
        {
            _accManager = new AccountManager();  //Imagine this is Ninject
        }

        [AntiDDOS(ActionName = "IndexGet", ForbidRefreshIntervalInSeconds = 5)]
        public ActionResult Index()
        {
            return View(new vmUserLogin());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AntiDDOS(ActionName = "IndexPost", ForbidRefreshIntervalInSeconds = 5)]
        public ActionResult Index([Bind(Include = "Username,Password")] vmUserLogin creds)
        {

            if (_accManager.AuthenticateUser(creds.Username, creds.Password))
            {
                FormsAuthentication.SetAuthCookie(creds.Username, false);
                return RedirectToAction("Welcome");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
            }

            return View();
        }

        [Authorize]
        public ActionResult Welcome()
        {
            ViewBag.Message = "Welcome Page";

            return View();
        }

        [Authorize(Users = "MasterUser")]
        public ActionResult Master()
        {
            ViewBag.Message = "See logged in users here";

            var vm = new List<vmUser>();

            var usrs = _accManager.GetAllUsers();

            foreach (var userData in usrs)
            {
                vm.Add(new vmUser { isLoggedIn = userData.isLoggedIn, Username = userData.Username });
            }


            return View(vm);
        }

        [HttpPost]
        public ActionResult LogOut(string Username)
        {
            if(HttpContext.User.Identity.Name == Username)
            {
                _accManager.SetUserIsLoggedOut(Username);
                FormsAuthentication.SignOut();
                return Json("Success");
            }
            else
            {
                return Json("Failed");
            }
        }
    }
}