using MvcOnlineTicaretOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentEmail"];
            var values = c.Messagess.Where(x => x.Buyer == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Currents.Where(x => x.CurrentEmail == mail).Select(y => y.CurrentId).FirstOrDefault();
            ViewBag.mid = mailid;
            var totalsales = c.SalesMovements.Where(x => x.CurrentId == mailid).Count();
            ViewBag.ts = totalsales;
            var totalamount = c.SalesMovements.Where(x => x.CurrentId == mailid).Sum(y => y.TotalPrice);
            ViewBag.ta = totalamount;
            var totalproduct = c.SalesMovements.Where(x => x.CurrentId == mailid).Sum(y => y.Quantity);
            ViewBag.tp = totalproduct;
            var namesurname = c.Currents.Where(x => x.CurrentEmail == mail).Select(y => y.CurrentName + " " + y.CurrentSurName).FirstOrDefault();
            ViewBag.ns = namesurname;
            var email = c.Currents.Where(x => x.CurrentEmail == mail).Select(y => y.CurrentEmail).FirstOrDefault();
            ViewBag.mail = email;
            var staffname = c.Messagess.Where(x => x.Buyer == mail).Select(x => x.Sender).FirstOrDefault();
            var staffimage = c.Staffs.Where(s => s.StaffName + " " + s.StaffSurName == staffname).Select(s => s.StaffImage).FirstOrDefault();
            ViewBag.image = staffimage;
            return View(values);
        }
        public ActionResult MyOrders()
        {
            var mail = (string)Session["CurrentEmail"];
            var id = c.Currents.Where(x => x.CurrentEmail == mail.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var values = c.SalesMovements.Where(x => x.CurrentId == id).ToList();
            return View(values);
        }
        public ActionResult İncomingMessages()
        {
            var mail = (string)Session["CurrentEmail"];
            var messages = c.Messagess.Where(x => x.Buyer == mail).OrderByDescending(x => x.MessageId).ToList();
            var outgoingmessages = c.Messagess.Count(x => x.Sender == mail).ToString();
            ViewBag.v2 = outgoingmessages;
            var incomingcount = c.Messagess.Count(x => x.Buyer == mail).ToString();
            ViewBag.v1 = incomingcount;
            return View(messages);
        }
        public ActionResult OutgoingMessages()
        {
            var mail = (string)Session["CurrentEmail"];
            var messages = c.Messagess.Where(x => x.Sender == mail).OrderByDescending(z => z.MessageId).ToList();
            var incomingcount = c.Messagess.Count(x => x.Buyer == mail).ToString();
            ViewBag.v1 = incomingcount;
            var outgoingmessages = c.Messagess.Count(x => x.Sender == mail).ToString();
            ViewBag.v2 = outgoingmessages;
            return View(messages);
        }
        public ActionResult MessageDetail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("İncomingMessages");
            }
            var message = c.Messagess.Where(x => x.MessageId == id).ToList();
            var mail = (string)Session["CurrentEmail"];
            var outgoingmessages = c.Messagess.Count(x => x.Sender == mail).ToString();
            ViewBag.v2 = outgoingmessages;
            var incomingcount = c.Messagess.Count(x => x.Buyer == mail).ToString();
            ViewBag.v1 = incomingcount;
            return View(message);
        }
        [HttpGet]
        public ActionResult CreateMessage()
        {
            var mail = (string)Session["CurrentEmail"];
            var outgoingmessages = c.Messagess.Count(x => x.Sender == mail).ToString();
            ViewBag.v2 = outgoingmessages;
            var incomingcount = c.Messagess.Count(x => x.Buyer == mail).ToString();
            ViewBag.v1 = incomingcount;
            return View();
        }
        [HttpPost]
        public ActionResult CreateMessage(Messages m)
        {
            var mail = (string)Session["CurrentEmail"];
            m.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Sender = mail;
            c.Messagess.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult CargoTracking(string p)
        {
            var cargos = from x in c.CargoDetails select x;
            cargos = cargos.Where(y => y.TrackingCode.Contains(p));
            return View(cargos.ToList());
        }
        public ActionResult CurrentCargoTracking(string id)
        {
            var details = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(details);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1() 
        {
            var mail = (string)Session["CurrentEmail"];
            var id = c.Currents.Where(x =>x.CurrentEmail == mail).Select(y =>y.CurrentId).FirstOrDefault();
            var currentfind = c.Currents.Find(id);
            return PartialView("Partial1", currentfind);
        }
        public PartialViewResult Partial2() 
        {
            var values = c.Messagess.Where(x => x.Sender == "admin").ToList();
            return PartialView(values);
        }
        public ActionResult CurrentİnfoUpdate(Current current) 
        {
            var cr = c.Currents.Find(current.CurrentId);
            cr.CurrentName = current.CurrentName;
            cr.CurrentSurName = current.CurrentSurName;
            cr.Password = current.Password;
            cr.CurrentCity = current.CurrentCity;
            cr.CurrentEmail = current.CurrentEmail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}