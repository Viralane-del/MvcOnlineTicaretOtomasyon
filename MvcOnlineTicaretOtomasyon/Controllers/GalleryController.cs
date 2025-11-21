using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Products.ToList();
            return View(values);
        }
    }
}