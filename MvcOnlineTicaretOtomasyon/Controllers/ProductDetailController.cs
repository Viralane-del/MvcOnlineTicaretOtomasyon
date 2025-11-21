using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.value1 = c.Products.Where(x => x.ProductId == 1).ToList();
            cs.value2 = c.Details.Where(y => y.DetailId == 1).ToList();
            return View(cs);
            
        }
    }
}