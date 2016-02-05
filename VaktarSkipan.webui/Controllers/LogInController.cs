using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaktarSkipan.BLL.DB;
using VaktarSkipan.webui.Concrete;

namespace VaktarSkipan.webui.Controllers
{
    public class LogInController : Controller
    {
    Authprovider authProvider = new Authprovider();
         
        public ViewResult Login() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    LoggedIn.username = model.UserName;
                    if (LoggedIn.username == "Admin")
                        return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                    else
                        return Redirect(returnUrl ?? Url.Action("UserMain", "User"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}