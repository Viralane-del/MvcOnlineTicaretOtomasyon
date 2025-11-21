using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index(int page3 = 1)
        {
            var values = c.Invoices.ToList().ToPagedList(page3, 7);
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateInvoice(Invoice ınvoice)
        {
            c.Invoices.Add(ınvoice);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetInvoice(int id)
        {
            var invoice = c.Invoices.Find(id);
            return View("GetInvoice", invoice);
        }
        public ActionResult UpdateInvoice(Invoice I)
        {
            var invoice = c.Invoices.Find(I.InvoiceId);
            invoice.InvoiceSerialNumber = I.InvoiceSerialNumber;
            invoice.InvoicesEquence = I.InvoicesEquence;
            invoice.TaxOffice = I.TaxOffice;
            invoice.Date = I.Date;
            invoice.Hour = I.Hour;
            invoice.Receiver = I.Receiver;
            invoice.Delivered = I.Delivered;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceDetail(int id)
        {
            var values = c.InvoicePens.Where(x => x.InvoiceId == id).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreatePen()
        {
            return View();
        }
        public ActionResult CreatePen(InvoicePen p)
        {
            c.InvoicePens.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dynamic() 
        {
            Class3 cs = new Class3();
            cs.Value1 = c.Invoices.ToList();
            cs.Value2 = c.InvoicePens.ToList();
            return View(cs);
        }
        public ActionResult InvoiceSave(string InvoiceSerialNumber , string InvoicesEquence, DateTime Date , string Hour, string TaxOffice, string Receiver , string Delivered, string Total, InvoicePen[] pens)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceSerialNumber = InvoiceSerialNumber;
            invoice.InvoicesEquence = InvoicesEquence;
            invoice.Date = Date;
            invoice.Hour = Hour;
            invoice.TaxOffice = TaxOffice;
            invoice.Receiver = Receiver;
            invoice.Delivered = Delivered;
            invoice.Total = Convert.ToDecimal(Total);
            c.Invoices.Add(invoice);
            foreach (var item in pens) 
            {
                InvoicePen pen = new InvoicePen();
                pen.Description = item.Description;
                pen.Quantity = item.Quantity;
                pen.UnitPrice = item.UnitPrice;
                pen.Amount = item.Amount;
                pen.InvoiceId = invoice.InvoiceId;
                c.InvoicePens.Add(pen);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}