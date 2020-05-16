using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yurt.Mvc.DAL;
using Yurt.Mvc.Models;

namespace Yurt.Mvc.Areas.Admin.Controllers
{[Authorize]
    public class OkulController : Controller
    {
        // GET: Admin/Okul
        YurtContext ctx = new YurtContext();
        public ActionResult Index()
        {
            var Okullar = ctx.Okullar.ToList();
            return View(Okullar);
        }
        public ActionResult OkulEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OkulEkle(Okul okl)
        {

            if (ModelState.IsValid)
            {
                ctx.Okullar.Add(okl);
            }

            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult OkulGuncelle(int? id, Okul o)
        {

            var okl = ctx.Okullar.Find(id);

            if (ModelState.IsValid)
            {

                ctx.Okullar.Add(o);
            }
            return View(okl);
        }
        [HttpPost]
        public ActionResult OkulGuncelle(Okul okl)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(okl).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult OkulSil(int? id)
        {

            var okl = ctx.Okullar.Find(id);
            ctx.Okullar.Remove(okl);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}