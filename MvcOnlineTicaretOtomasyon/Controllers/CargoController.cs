using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var cargos = from x in c.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                cargos = cargos.Where(y => y.TrackingCode.Contains(p));
            }
            return View(cargos.ToList());
        }
        [HttpGet]
        public ActionResult CreateCargo() 
        {
            string trackingCode = GenerateTrackingCode();
            ViewBag.takipkod = trackingCode;
            return View();
        }
        [HttpPost]
        public ActionResult CreateCargo(CargoDetail cd)
        {
            c.CargoDetails.Add(cd);
            c.SaveChanges();
            return View();
        }
        private string GenerateTrackingCode() 
        {
           Random rnd = new Random();
           int number = rnd.Next(100000, 999999);
           return  "TRK" + number;
        }

        public ActionResult CargoTracking(string id)
        {
            //z = "TRK736451";
            var details = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();         
            return View(details);
        }
    }
}