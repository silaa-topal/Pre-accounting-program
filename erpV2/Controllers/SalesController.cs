using erpV2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace erpV2.Controllers
{
    public class SalesController : Controller
    {
        Context c = new Context();
        // GET: Sales
        public ActionResult Index()
        {
            var result = c.SalesTransactions.ToList();
            return View(result);
        }

        public ActionResult NewSales()
        {
            List<SelectListItem> product = (from x in c.Products.Where(x => x.Status == true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductID.ToString()

                                            }).ToList();
            ViewBag.prod = product;

            List<SelectListItem> customer = (from y in c.Customers.Where(x => x.Status == true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = y.CustomerName + " "+ y.CustomerSurname,
                                                Value = y.CustomerID.ToString()
                                            }).ToList();
            ViewBag.cust = customer;

            List<SelectListItem> personnel = (from p in c.Personnels.Where(x => x.Status == true).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = p.PersonnelFirstname + " "+ p.PersonnelLastname,                                                  
                                                  Value = p.PersonnelID.ToString()
                                              }).ToList();
            ViewBag.pers = personnel;

            
            return View();
        }

        [HttpPost]
        public ActionResult NewSales(SalesTransaction s)
        {
            if (ModelState.IsValid)
            {
                //s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                c.SalesTransactions.Add(s);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public ActionResult UpdateSales(int id)
        {
            List<SelectListItem> product = (from x in c.Products.Where(x => x.Status == true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductID.ToString()

                                            }).ToList();
            ViewBag.prod = product;

            List<SelectListItem> customer = (from y in c.Customers.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = y.CustomerName + " " + y.CustomerSurname,
                                                 Value = y.CustomerID.ToString()
                                             }).ToList();
            ViewBag.cust = customer;

            List<SelectListItem> personnel = (from p in c.Personnels.Where(x => x.Status == true).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = p.PersonnelFirstname + " " + p.PersonnelLastname,
                                                  Value = p.PersonnelID.ToString()
                                              }).ToList();
            ViewBag.pers = personnel;

            var result = c.SalesTransactions.Find(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateSales(SalesTransaction s)
        {
            var sales = c.SalesTransactions.Find(s.SalesID);
            sales.CustomerID = s.CustomerID;
            sales.ProductID = s.ProductID;
            sales.PersonnelID = s.PersonnelID;
            sales.SalesID = s.SalesID;
            sales.Price = s.Price;
            sales.Quantity = s.Quantity;
            sales.TotalPrice = s.TotalPrice;
            sales.Date = s.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SList()
        {
            var result = c.SalesTransactions.ToList();
            return View(result);
        }
    }
}