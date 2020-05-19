using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yurt.Mvc.DAL;
using Yurt.Mvc.Models;

namespace Yurt.Mvc.Areas.Admin.Controllers
{  
    public class OgrenciController : Controller, IDisposable
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

            ViewBag.okulId = okulList;
            var ogrenciler = ctx.Ogrenciler.ToList();
            return View(ogrenciler);

        }
        public ActionResult OgrenciEkle()
        {
           
            var okulList = ctx.Okullar.ToList();
            ViewBag.okulId = okulList;
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(Ogrenci ogr)
        {

            try
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

            }
            catch (DbEntityValidationException ex)
            {
                Response.Write(ex);

            }
            return View();
        }
        public ActionResult Guncelle(int? id, Ogrenci o)
        {
           
            var okulList = ctx.Okullar.ToList();


            ViewBag.okulId = okulList;
            
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


            try
            {
                ctx.Entry(ogr).State = EntityState.Modified;
                int sonuc = ctx.SaveChanges();
                if (sonuc > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            catch (DbEntityValidationException ex)
            {
                Response.Write(ex);
                
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
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);

        }
    }
}