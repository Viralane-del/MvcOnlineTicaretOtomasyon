using MvcOnlineTicaretOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var charts = new Chart(600, 600);
            charts.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler",
                xValue: new[] { "Mobilya", "Televizyon", "Koltuklar" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(charts.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var results = c.Products.ToList();
            results.ToList().ForEach(x => xvalue.Add(x.ProductName));
            results.ToList().ForEach(y => yvalue.Add(y.Stock));
            var chart = new Chart(width: 1000, height: 1000)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(chart.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductResult() 
        {
            return Json(Productlist(), JsonRequestBehavior.AllowGet);
        }
        public List<Classes1> Productlist() 
        {
            List<Classes1> cs = new List<Classes1>();
            cs.Add(new Classes1()
            {
                productname = "Bilgisayar",
                stock = 105
            });
            cs.Add(new Classes1()
            {
                productname = "Beyaz Eşya",
                stock = 249
            });
            cs.Add(new Classes1()
            {
                productname = "Televizyon",
                stock = 10
            });
            cs.Add(new Classes1()
            {
                productname = "Mobilya",
                stock = 20
            });
            cs.Add(new Classes1()
            {
                productname = "Telefon",
                stock = 159
            });
            return cs;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductResult2() 
        {
            return Json(Productlist2(), JsonRequestBehavior.AllowGet);
        }
        public List<Classes2> Productlist2() 
        {
           List<Classes2> cs2 = new List<Classes2>();
            using (var context = new Context())
            {
                cs2 = context.Products.Select(x => new Classes2
                {
                    prdt = x.ProductName,
                    stk = x.Stock
                }).ToList();
            }
            return cs2;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}