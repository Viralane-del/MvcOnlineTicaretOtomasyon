using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var currents = c.Currents.Where(x => x.Status == true).ToList();
            return View(currents);
        }
        [HttpGet]
        public ActionResult CreateCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCurrent(Current current)
        {
            current.Status = true; 
            c.Currents.Add(current);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrent(int id)
        {
            var crt = c.Currents.Find(id);
            crt.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrent(int id) 
        {
            var cure = c.Currents.Find(id);
            return View("GetCurrent", cure);
        }
        public ActionResult UpdateCurrent(Current cr) 
        {
            if (!ModelState.IsValid)
            {
                return View("GetCurrent");
            }
            var current = c.Currents.Find(cr.CurrentId);
            current.CurrentName = cr.CurrentName;
            current.CurrentSurName = cr.CurrentSurName;
            current.CurrentCity = cr.CurrentCity;
            current.CurrentEmail = cr.CurrentEmail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesHistory(int id) 
        {
           var sales = c.SalesMovements.Where(x => x.CurrentId == id).ToList();
           var cr = c.Currents.Where(x => x.CurrentId == id).Select(x => x.CurrentName + " " + x.CurrentSurName).FirstOrDefault();
           ViewBag.cname = cr;
            return View(sales);
        }
    }
}