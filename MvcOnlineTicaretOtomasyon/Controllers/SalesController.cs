using MvcOnlineTicaretOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var sales = c.SalesMovements.ToList();
            return View(sales);
        }
        [HttpGet]
        public ActionResult CreateSales() 
        {
            List<SelectListItem> values = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductId.ToString()
                                            }).ToList();
            ViewBag.p1 = values;
            List<SelectListItem> values2 = (from x in c.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + " " + x.CurrentSurName,
                                                Value = x.CurrentId.ToString()
                                            }).ToList();
            ViewBag.p2 = values2;
            List<SelectListItem> values3 = (from x in c.Staffs.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.StaffName + " " + x.StaffSurName,
                                                Value = x.StaffId.ToString()
                                            }).ToList();
            ViewBag.p3 = values3;
            return View();
        }
        [HttpPost]
        public ActionResult CreateSales(SalesMovement salesMovement)
        {
            salesMovement.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(salesMovement);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSales(int id) 
        {
            
            {
                List<SelectListItem> values = (from x in c.Products.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ProductName,
                                                   Value = x.ProductId.ToString()
                                               }).ToList();
                ViewBag.p1 = values;

                List<SelectListItem> values2 = (from x in c.Currents.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.CurrentName + " " + x.CurrentSurName,
                                                    Value = x.CurrentId.ToString()
                                                }).ToList();
                ViewBag.p2 = values2;

                List<SelectListItem> values3 = (from x in c.Staffs.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.StaffName + " " + x.StaffSurName,
                                                    Value = x.StaffId.ToString()
                                                }).ToList();
                ViewBag.p3 = values3;

                var sales = c.SalesMovements.Find(id);
                return View("GetSales", sales);
            }           

        }
        public ActionResult UpdateSales(SalesMovement sales)
        {
            var sl = c.SalesMovements.Find(sales.SalesId);
            sl.ProductId = sales.ProductId;
            sl.CurrentId = sales.CurrentId;
            sl.StaffId = sales.StaffId;
            sl.Quantity = sales.Quantity;
            sl.Price = sales.Price;
            sl.TotalPrice = sales.TotalPrice;
            sl.Date = sales.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetail(int id)
        {       
            var sales = c.SalesMovements.Where(x => x.SalesId == id).ToList();
            return View(sales);
        }
    }
}