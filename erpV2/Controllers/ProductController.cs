using erpV2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace erpV2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var products = c.Products.Where(x => x.Status==true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {

            List<SelectListItem> category = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.cat = category;
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var result = c.Products.Find(id);
            if(result != null)
            {
                result.Status = false;
               
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BringProduct(int id)
        {
            List<SelectListItem> category = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.cat = category;
            
            var result = c.Products.Find(id);
            return View("BringProduct", result);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product p)
        {
            var prdct = c.Products.Find(p.ProductID);
            prdct.ProductName = p.ProductName;
            prdct.ProductBrand = p.ProductBrand;
            prdct.Stock = p.Stock;
            prdct.SalePrice = p.SalePrice;
            prdct.PurchasePrice = p.PurchasePrice;
            prdct.ProductImage = p.ProductImage;
            prdct.ProductID = p.ProductID;
            prdct.Status = p.Status;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var result = c.Products.ToList();
            return View(result);
        }
    }
}