using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        Context c = new Context();
        public ActionResult Index()
        {
            var stf = c.Staffs.ToList();
            return View(stf);
        }
        [HttpGet]
        public ActionResult CreateStaff()
        {
            List<SelectListItem> dpt = (from x in c.Departments.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmentName,
                                                 Value = x.DepartmentId.ToString()
                                             }).ToList();
            ViewBag.p = dpt;
            return View();
        }
        [HttpPost]
        public ActionResult CreateStaff(Staff s)
        {
            if (Request.Files.Count > 0) 
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                s.StaffImage = path;
            }
            c.Staffs.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetStaff(int id) 
        {
            List<SelectListItem> dep = (from x in c.Departments.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmentName,
                                                 Value = x.DepartmentId.ToString()
                                             }).ToList();
            ViewBag.d = dep;
            var stf = c.Staffs.Find(id);
            return View("GetStaff",stf);
        }
        public ActionResult UpdateStaff(Staff staff) 
        {

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                staff.StaffImage = path;
            }
            var stf = c.Staffs.Find(staff.StaffId);
            stf.StaffName = staff.StaffName;
            stf.StaffSurName = staff.StaffSurName;
            stf.StaffImage = staff.StaffImage;
            stf.DepartmentId = staff.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffList() 
        {
            var query = c.Staffs.ToList();
            return View(query);
        }
    }

}