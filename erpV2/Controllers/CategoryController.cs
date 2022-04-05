

using erpV2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace erpV2.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Categories.ToList();
            return View(values);
        }

        [HttpGet] //sayfayı getir
        public ActionResult AddCategory()
        {
            return View(); 
        }

        [HttpPost] //butonu çalıştır
        public ActionResult AddCategory(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

  
        public ActionResult DeleteCategory(int id)
        {
            var cat = c.Categories.Find(id);
            c.Categories.Remove(cat);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet] //sayfayı getir
        public ActionResult BringCategory(int id)
        {
            var cat = c.Categories.Find(id);
         
            return View("BringCategory", cat);
        }

        [HttpPost] //butonu çalıştır 
        public ActionResult EditCategory(Category k)
        {
            var ctg = c.Categories.Find(k.CategoryID);
            ctg.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}