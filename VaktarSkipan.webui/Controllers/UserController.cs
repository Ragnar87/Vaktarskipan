using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaktarSkipan.BLL.DB;
using VaktarSkipan.BLL.Entities;
using VaktarSkipan.webui.Concrete;

namespace VaktarSkipan.webui.Controllers
{
    public class UserController : Controller
    {
        DatabaseModels dbm = new DatabaseModels();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            Authprovider fAuth = new Authprovider();
            if (ModelState.IsValid)
            {
                if (fAuth.Authenticate(model.UserName, model.Password))
                {
                    LoggedIn.username = model.UserName;
                    return Redirect("UserMain");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                }
            }
            return View();
              


        }
        [Authorize]
        public ActionResult UserMain()
        {
            var vaktir = from v in dbm.allJobs
                         where v.PersonID == LoggedIn.username
                         select v;
            return View(vaktir);



        }
        /*[Authorize]
        [HttpGet]
        public ActionResult FreeVakts()
        {


            var lv =
                from v in dbm.allJobs
                where v.isFree == true
                select v;

            return View(lv);
        }*/

        [Authorize]
        [HttpGet]
        public ActionResult FreeVakts(int id = 0)
        {
            if(id==1)
            {
                ModelState.AddModelError("", "you are already working at this time");

            }

            var lv =
                from v in dbm.allJobs
                where v.isFree == true
                select v;

            return View(lv);
        }

        [Authorize]
        public ActionResult TakeVakt(int id)
        {
            Vaktir Vakt = dbm.allJobs.FirstOrDefault(v => v.VaktID == id);

            if (dbm.takeJob(Vakt))
                return RedirectToAction("FreeVakts");

            return RedirectToAction("FreeVakts/1");
        }
        [Authorize]
        public ActionResult release(int id)
        {
            Vaktir Vakt = dbm.allJobs.FirstOrDefault(v => v.VaktID == id);

            dbm.releaseJob(Vakt);

            return RedirectToAction("UserMain");
        }
        [Authorize]
        public ActionResult StarvsfolkaListi()
        {
            var person = from p in dbm.allPeoples
                         select p;

            return View(person);
        }

    }
}