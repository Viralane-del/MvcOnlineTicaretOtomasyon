using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;
namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Currents.Count().ToString();
            ViewBag.d1 = value1;
            var value2 = c.Products.Count().ToString();
            ViewBag.d2 = value2;
            var value3 = c.Staffs.Count().ToString();
            ViewBag.d3 = value3;
            var value4 = c.Categories.Count().ToString();
            ViewBag.d4 = value4;
            var value5 = c.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = value5;
            var value6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = value6;
            var value7 = c.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d7 = value7;
            var value8 = (from x in c.Products orderby x.SalesPrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = value8;
            var value9 = (from x in c.Products orderby x.SalesPrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = value9;
            var value10 = c.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d10 = value10;
            var value11 = c.Products.Count(x => x.ProductName == "Buzdolabi").ToString();
            ViewBag.d11 = value11;
            var value12 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d12 = value12;
            var value13 = c.SalesMovements.GroupBy(x => x.Product.ProductName).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d13 = value13;
            var value14 = c.SalesMovements.Sum(x => x.TotalPrice).ToString("0,00");
            ViewBag.d14 = value14;
            DateTime today = DateTime.Today;
            var value15 = c.SalesMovements.Count(x => x.Date == today).ToString();
            ViewBag.d15 = value15;
            var value16 = c.SalesMovements.Where(x => x.Date == today).Select(y => y.TotalPrice).DefaultIfEmpty(0).Sum().ToString("0,00");
            ViewBag.d16 = value16;
            return View();
        }
        public ActionResult EasyTables() 
        {
            var query = from x in c.Currents group x by x.CurrentCity into g 
                        select new ClassGroup
                        {
                            City = g.Key,
                            Number = g.Count()
                        };
            return View(query.ToList());
        }
        public PartialViewResult Partial1() 
        {
            var query1 = from x in c.Staffs group x by x.Department.DepartmentName into g
                         select new ClassGroup2
                         {
                             Department = g.Key,
                             Number = g.Count()
                         };
            return PartialView(query1.ToList());
        }
        public PartialViewResult Partial2()
        {
            var query2 = c.Currents.ToList();
            return PartialView(query2);
        }
        public PartialViewResult Partial3()
        {
            var query3 = c.Products.ToList();
            return PartialView(query3);
        }
        public PartialViewResult Partial4()
        {
            var query4 = from x in c.Products group x by x.Brand into g
                         select new ClassGroup3
                         {
                             Brand = g.Key,
                             Number = g.Count()
                         };
            return PartialView(query4.ToList());
        }
    }
}