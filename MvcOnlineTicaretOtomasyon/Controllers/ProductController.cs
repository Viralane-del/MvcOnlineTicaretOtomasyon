using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicaretOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index(int page1 = 1, string searchString = "")
        {
            var search = c.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                search = search.Where(y => y.ProductName.ToLower().Contains(searchString.ToLower()));
            }

            var pagedProducts = search.OrderBy(p => p.ProductId).ToPagedList(page1, 5);

            ViewBag.srch = searchString;

            return View(pagedProducts);
        }


        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> products = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.p = products;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var product = c.Products.Find(id);
            product.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> products = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.p = products;
            var getproduct = c.Products.Find(id);
            return View("GetProduct", getproduct);
        }
        public ActionResult UpdateProduct(Product p)
        {
            var prd = c.Products.Find(p.ProductId);
            prd.SalesPrice = p.SalesPrice;
            prd.Status = p.Status;
            prd.CategoryId = p.CategoryId;
            prd.Brand = p.Brand;
            prd.PurchasePrice = p.PurchasePrice;
            prd.Stock = p.Stock;
            prd.ProductName = p.ProductName;
            prd.ProductImage = p.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList() 
        {
            var values = c.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Sell(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index"); // id yoksa Index'e dön
            }
            List<SelectListItem> values3 = (from x in c.Staffs.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.StaffName + " " + x.StaffSurName,
                                                Value = x.StaffId.ToString()
                                            }).ToList();
            ViewBag.p3 = values3;           
            var value1 = c.Products.Find(id);
            if (value1 == null) return HttpNotFound();
            ViewBag.p1 = value1.ProductId;
            ViewBag.p2 = value1.SalesPrice;           
            return View();
        }
        [HttpPost]
        public ActionResult Sell(SalesMovement S)
        {
            S.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(S);
            c.SaveChanges();
            return RedirectToAction("Index", "Sales");
        }
    }
}