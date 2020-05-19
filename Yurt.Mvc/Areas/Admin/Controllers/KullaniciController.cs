using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yurt.Mvc.DAL;
using Yurt.Mvc.Models;

namespace Yurt.Mvc.Areas.Admin.Controllers
{    [AllowAnonymous]
    public class KullaniciController : Controller,IDisposable
    {
        // GET: Admin/Kullanici
        YurtContext ctx = new YurtContext();
       
        public ActionResult Kaydol()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Kaydol(Kullanici klc)
        {
            var kullaniciVarmi = ctx.Kullanicilar.FirstOrDefault(x => x.email == klc.email );

            if (kullaniciVarmi == null && ModelState.IsValid)
            {
                ctx.Kullanicilar.Add(klc);
            }
            else ViewBag.kulVar = "Bu emaile sahip kullanıcı var";
            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Login", "Security");
               

            }
           
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}