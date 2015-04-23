using NaGreen.Infrastructure.Base;
using NaGreen.Infrastructure.Implementation;
using NaGreen.Models;
using NaGreen.WebUi.Server.Base.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaGreen.Controllers
{
    public class LoginController : Controller
    {
        private IAuthProvider _authProvider;
        private IUsersService _usersService;

        public LoginController(IAuthProvider authProvider,IUsersService usersService)
        {
            _authProvider = authProvider;
            _usersService = usersService;
        }

        //
        // GET: /Login/
        public ViewResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            //var isUserAutheticated = true;
            IAuthProvider authProvider = new FormsAuthProvider();
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, string.Empty))
                {
                    //IHttpRequest request = new NaGreen.Infrastructure.Implementation.HttpRequest("");
                     return RedirectToAction("GetGameList", "Games");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            //if (!isUserAutheticated || !ModelState.IsValid)
            //{
            //    return View("Index");
            //}
            else
            {
                return RedirectToAction("GetGameList", "Games");
            }
        }
	}
}