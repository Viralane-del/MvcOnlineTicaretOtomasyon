using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var dpt = c.Departments.Where(x => x.Status  == true).ToList();
            return View(dpt);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(Department d) 
        {
             c.Departments.Add(d);
             c.SaveChanges();
             return RedirectToAction("Index");
        }
        public ActionResult DeleteDeparment(int id) 
        {
            var dpt = c.Departments.Find(id);
            dpt.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDepartment(int id)
        {
            var dpt = c.Departments.Find(id);
            return View("GetDepartment", dpt);
        }
        public ActionResult UpdateDepartment(Department d) 
        {
            var dpt = c.Departments.Find(d.DepartmentId);
            dpt.DepartmentName = d.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailDepartment(int id) 
        {
            var details = c.Staffs.Where(x => x.DepartmentId == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(details);
        }

        public ActionResult DepartmentSalesMovements(int id) 
        {
            var sales = c.SalesMovements.Where(x => x.StaffId == id).ToList();
            var per = c.Staffs.Where(x => x.StaffId == id).Select(y => y.StaffName + " " + y.StaffSurName).FirstOrDefault();
            ViewBag.dpers = per;
            return View(sales);
        }
    }
}