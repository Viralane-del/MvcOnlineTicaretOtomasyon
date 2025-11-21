using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicaretOtomasyon.Models.Classes;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Current current)
        {
            c.Currents.Add(current);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrentLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentLogin1(Current current)
        {
            var information = c.Currents.FirstOrDefault(x => x.CurrentEmail == current.CurrentEmail && x.Password == current.Password);
            if (information != null)
            {
                FormsAuthentication.SetAuthCookie(information.CurrentEmail, false);
                Session["CurrentEmail"] = information.CurrentEmail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var informations = c.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.UserName, false);
                Session["UserName"] = informations.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}