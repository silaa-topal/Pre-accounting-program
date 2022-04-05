using erpV2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace erpV2.Controllers
{
    public class PersonnelController : Controller
    {
        Context c = new Context();
        // GET: Personnel
        public ActionResult Index()
        {
            var result = c.Personnels.Where(x => x.Status == true).ToList();
            return View(result);
        }

        public ActionResult NewPersonnel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewPersonnel(Personnel p)
        {
            c.Personnels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletePersonnel(int id)
        {
            var result = c.Personnels.Find(id);
            if (result != null)
            {
                result.Status = false;

                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult BringPersonnel(int id)
        {
            var result = c.Personnels.Find(id);
            return View("BringPersonnel", result);
        }

        [HttpPost]
        public ActionResult UpdatePersonnel(Personnel p)
        {
            var result = c.Personnels.Find(p.PersonnelID);
            result.PersonnelID = p.PersonnelID;
            result.PersonnelFirstname = p.PersonnelFirstname;
            result.PersonnelLastname = p.PersonnelLastname;
            result.PersonnelTitle = p.PersonnelTitle;
            result.PersonnelEmailAddress = p.PersonnelEmailAddress;
            result.Status = p.Status;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonnelDetails(int id)
        {
            var result = c.SalesTransactions.Where(x => x.PersonnelID == id).ToList();
            return View(result);
        }
    }
}