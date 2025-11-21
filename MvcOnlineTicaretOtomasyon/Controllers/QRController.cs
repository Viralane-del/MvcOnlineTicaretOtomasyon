using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicaretOtomasyon.Controllers
{
    public class QRController : Controller
    {
        // GET: OR
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Code) 
        {
            using (MemoryStream ms = new MemoryStream()) 
            {
               QRCodeGenerator qRCode = new QRCodeGenerator();
               QRCodeGenerator.QRCode code = qRCode.CreateQrCode(Code, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap Image = code.GetGraphic(10)) 
                {
                    Image.Save(ms, ImageFormat.Png);
                    ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
                return View();
        }
    }
}