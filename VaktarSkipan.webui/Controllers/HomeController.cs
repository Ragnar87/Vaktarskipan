using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaktarSkipan.BLL.Entities;
using VaktarSkipan.BLL.DB;
using VaktarSkipan.BLL.Validators;
using System.Security;
using VaktarSkipan.webui.ExtendedAttributes;

namespace VaktarSkipan.webui.Controllers
{
    //[IsAdmin]
    [AdminCheck]
    [Authorize]
    public class HomeController : Controller
    {
        

        DatabaseModels dbm = new DatabaseModels();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Jobs()
        {
            return View(dbm.allJobs);
        }

        public ActionResult People()
        {

            return View(dbm.allPeoples);
        }

        public ActionResult Details(string id)
        {
            Person p = dbm.getPerson(id);

            if(p.Vaktir.Count > 0)
            {
                p.Vaktir = p.Vaktir.OrderBy(x => x.Date).ToList();
                p.Vaktir.Reverse();

            }

            return View(p);
        }

        public ActionResult DeletePerson(string id)
        {
            Person delPerson = dbm.getPerson(id);
            if (delPerson.Vaktir.Count == 0)
            {
                String output = delPerson.fullName() + " has been deleted";
                TempData["Success"] = output;
                dbm.deletePerson(delPerson);
            }
            else 
            {
                String output = delPerson.fullName() + " cannot be deleted, check jobs";
                TempData["Failure"] = output;
            }

            return RedirectToAction("People");
        }

        public ActionResult EditPerson(string id)
        {
            Person p = dbm.getPerson(id);

            return View(p);
        }

        [HttpPost]
        public ActionResult EditPerson(Person p)
        {
            if (ModelState.IsValid)
            {
                if (dbm.updatePerson(p))
                {
                    string output = p.fullName() + " has been updated";
                    TempData["Success"] = output;
                }
                else 
                {
                    string output = p.fullName() + " could not be updated";
                    TempData["Failure"] = output;  
                }

                return RedirectToAction("People");
            }

            return View(p);
        }

        public ActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePerson(Person p)
        {

            if (ModelState.IsValid)
            {
               if(dbm.addWorker(p))
               {
                   String output = p.fullName() + " has been added to database";
                   TempData["Success"] = output;
               }
               else 
               {
                   String output = "person id has to be unique";
                   TempData["Failure"] = output;
               }

                return RedirectToAction("People");
            }
            return View();
        }

        public ActionResult CreateJob()
        {
            PeopleJobvm viewModel = new PeopleJobvm();
            viewModel.ListOfPersons = dbm.allPeoples;
            return View(viewModel);
        }

        public ActionResult EditJob(int id)
        {
            Vaktir v = dbm.getVakt(id);

            PeopleJobvm viewModel = new PeopleJobvm();
            viewModel.job = v;
            viewModel.ListOfPersons = dbm.allPeoples;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditJob(PeopleJobvm viewModel)
        {
            if (ModelState.IsValid)
            {
            Vaktir v = new Vaktir();
            v.VaktID = viewModel.id;
            v.isFree = viewModel.job.isFree;
            v.Date = viewModel.job.Date;
                v.Start = viewModel.job.Start;
            v.End = viewModel.job.End;
            v.Type = viewModel.job.Type;
            v.PersonID = viewModel.job.PersonID;
            v.Person = dbm.getPerson(viewModel.job.PersonID);

            dbm.updateJob(v);

                String output = "vakt no"+ v.VaktID+ " has been updated";
                TempData["Success"] = output;

            return RedirectToAction("Jobs");
        }

            viewModel.ListOfPersons = dbm.allPeoples;
            return View(viewModel);
        }

        public ActionResult DeleteJob(int id)
        {
            Vaktir deleteVakt = dbm.getVakt(id);


            if (dbm.deleteJob(deleteVakt))
            {
                String output = "Vakt no: " + deleteVakt.VaktID + " has been deleted";
                TempData["Success"] = output;
            }
            else
            {
                String output = "Vakt no: " + deleteVakt.VaktID + " could not be deleted";
            }

            return RedirectToAction("Jobs");
        }

        [HttpPost]
        public ActionResult CreateJob(PeopleJobvm pjvm)
        {

            if (ModelState.IsValid)
            {
            Vaktir vakt = new Vaktir();
            vakt.Date = pjvm.job.Date;
            vakt.End = pjvm.job.End;
            vakt.Start = pjvm.job.Start;
            vakt.Type = pjvm.job.Type;
            vakt.PersonID = pjvm.job.PersonID;

            string id = pjvm.job.PersonID;
            vakt.Type = pjvm.job.Type;
            Person vaktPerson = new Person();

            vaktPerson = dbm.allPeoples.Find(x => x.PersonID.Equals(id));
            vakt.Person = vaktPerson;
            dbm.addJob(vakt);

                String output = "Vakt no: " + vakt.VaktID + " has been added to database";
                TempData["Success"] = output;

            return RedirectToAction("Jobs");
        }

            pjvm.ListOfPersons = dbm.allPeoples;
            return View(pjvm);
        }

        public ActionResult FreeVakt()
        {
            IEnumerable<Vaktir> lVaktir = dbm.allJobs;

            var lv =
                from v in lVaktir
                where v.isFree == true
                select v;

            return View(lv);
        }


        public ActionResult Take(int id)
        {
            Vaktir Vakt = dbm.allJobs.FirstOrDefault(v => v.VaktID == id);

            dbm.takeJob(Vakt);

            return RedirectToAction("FreeVakt");
        }
    }


}