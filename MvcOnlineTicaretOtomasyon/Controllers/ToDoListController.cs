using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Currents.Count().ToString();
            ViewBag.v1 = value1;
            var value2 = c.Products.Count().ToString();
            ViewBag.v2 = value2;
            var value3 = c.Categories.Count().ToString();
            ViewBag.v3 = value3;
            var value4 = c.Staffs.Count().ToString();
            ViewBag.v4 = value4;

            var todolist = c.ToDoLists.ToList();
            return View(todolist);
        }
    }
}