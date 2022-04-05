using erpV2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace erpV2.Controllers
{
    public class InvoiceController : Controller
    {
        Context c = new Context();
        // GET: Invoice
        public ActionResult Index()
        {
            var invoice = c.Invoices.ToList();
            return View(invoice);
        }

        public ActionResult NewInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewInvoice(Invoice i)
        {
            c.Invoices.Add(i);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dynamic()
        {
            ClassInvoice cs = new ClassInvoice();
            cs.value1 = c.Invoices.ToList();
            cs.value2 = c.InvoiceItems.ToList();
            return View(cs);
        }

        public ActionResult BringInvoice(int id)
        {
            var result=c.Invoices.Find(id);

            return View("BringInvoice",result);
        }

        [HttpPost]
        public ActionResult UpdateInvoice(Invoice i)
        {
            var invoice = c.Invoices.Find(i.InvoiceID);
            invoice.InvoiceID = i.InvoiceID ;
            invoice.InvoiceSerialNo = i.InvoiceSerialNo;
            invoice.InvoiceRowNo = i.InvoiceRowNo;
            invoice.InvoiceDate = i.InvoiceDate;
            invoice.InvoiceTime = i.InvoiceTime;
            invoice.TaxOffice = i.TaxOffice;
            invoice.Recipient = i.Recipient;
            invoice.Consigner = i.Consigner;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetails(int id)
        {
            var result = c.InvoiceItems.Where(x => x.InvoiceID == id).ToList();
            return View(result);
        }

        public ActionResult NewItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewItem(InvoiceItem i)
        {
            c.InvoiceItems.Add(i);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}