using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using erpV2.Models.Classes;

namespace erpV2.Controllers
{
    public class CustomerController : Controller
    {
        Context c = new Context();
        // GET: Customer
        public ActionResult Index()
        {
            var result = c.Customers.Where(x => x.Status == true).ToList();
            return View(result);
        }

        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(Customer k)
        {
            if (ModelState.IsValid)
            {
                k.Status = true;
                c.Customers.Add(k);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(k);
           
        }

        public ActionResult DeleteCustomer(int id)
        {
            var cus = c.Customers.Find(id);
            cus.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomer(int id)
        {
            var result = c.Customers.Find(id);
            return View("UpdateCustomer", result);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer k)
        {
            if (!ModelState.IsValid)
            {
                return View(k);
            }
            var result = c.Customers.Find(k.CustomerID);
            result.CustomerID = k.CustomerID;
            result.CustomerName = k.CustomerName;
            result.CustomerSurname = k.CustomerSurname;
            result.CustomerCity = k.CustomerCity;
            result.CustomerMailAddress = k.CustomerMailAddress;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerDetails(int id)
        {
            var result = c.SalesTransactions.Where(x => x.CustomerID == id).ToList();
            ViewBag.res = result;
            
            return View(result);
        }
    }
}