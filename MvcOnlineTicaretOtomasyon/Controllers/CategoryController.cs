using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
	public class CategoryController : Controller
	{
		// GET: Category
		Context c = new Context();
		public ActionResult Index(int page = 1)
		{
			var degerler = c.Categories.ToList().ToPagedList(page, 4);
			return View(degerler);
		}
		[HttpGet]
		public ActionResult CreateCategory()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateCategory(Category category)
		{
			c.Categories.Add(category);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteCategory(int id)
		{
			var ctg = c.Categories.Find(id);
			c.Categories.Remove(ctg);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult GetCategory(int id)
		{
			var updt = c.Categories.Find(id);
			return View("UpdateCategory", updt);
		}

		[HttpPost]
		public ActionResult UpdateCategory(Category ctg)
		{
			var upctg = c.Categories.Find(ctg.CategoryId);
			if (upctg == null)
			{
				return HttpNotFound("Kategori bulunamadı");
			}

			upctg.CategoryName = ctg.CategoryName;
			c.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult Deneme() 
		{
            Context c = new Context();
            Class2 cs = new Class2();
            cs.Categories = c.Categories
                             .Select(x => new SelectListItem
                             {
                                 Text = x.CategoryName,
                                 Value = x.CategoryId.ToString()
                             }).ToList();

            cs.Products = new List<SelectListItem>();
            return View(cs);
        }
		[HttpPost]
		public ActionResult ProductGet(int p) 
		{
			
            var productlist = (from x in c.Products
							   join y in c.Categories on x.Category.CategoryId equals
							   y.CategoryId
							   where x.Category.CategoryId == p
							   select new
							   {
								   Text = x.ProductName,
								   Value = x.ProductId.ToString()
							   }).ToList();


			return Json(productlist, JsonRequestBehavior.AllowGet);
			
        }
    }
}