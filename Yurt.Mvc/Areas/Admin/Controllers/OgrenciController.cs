using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yurt.Mvc.DAL;
using Yurt.Mvc.Models;

namespace Yurt.Mvc.Areas.Admin.Controllers
{   [Authorize]
    public class OgrenciController : Controller
    {
        // GET: Admin/Ogrenci
        YurtContext ctx = new YurtContext();
       
        public ActionResult Index()
        {
            List<SelectListItem> okulList = (from i in ctx.Okullar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Okul_Ad,
                                                 Value = i.OkulID.ToString()
                                             }).ToList();

            ViewBag.okulList = okulList;
            var ogrenciler = ctx.Ogrenciler.ToList();
            return View(ogrenciler);

        }
        public ActionResult OgrenciEkle()
        {
            List<SelectListItem> okulList = (from i in ctx.Okullar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Okul_Ad,
                                                 Value = i.OkulID.ToString()
                                             }).ToList();


            ViewBag.okulList = okulList;
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(Ogrenci ogr)
        {

            if (ModelState.IsValid)
            {
                var okl = ctx.Okullar.Find(ogr.okulId);
                ogr.okulu = okl;
                ctx.Ogrenciler.Add(ogr);
            }

            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Guncelle(int? id, Ogrenci o)
        {
            List<SelectListItem> okulList = (from i in ctx.Okullar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Okul_Ad,
                                                 Value = i.OkulID.ToString()
                                             }).ToList();

            ViewBag.okulList = okulList;
            var ogr = ctx.Ogrenciler.Find(id);

            if (ModelState.IsValid)
            {

                ctx.Ogrenciler.Add(o);
            }
            return View(ogr);
        }
        [HttpPost]
        public ActionResult Guncelle(Ogrenci ogr)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(ogr).State = EntityState.Modified;
                int sonuc = ctx.SaveChanges();
                if (sonuc > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public ActionResult OgrenciSil(int? id)
        {
            Ogrenci ogr = new Ogrenci();
            ogr = ctx.Ogrenciler.Find(id);
            ctx.Ogrenciler.Remove(ogr);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}