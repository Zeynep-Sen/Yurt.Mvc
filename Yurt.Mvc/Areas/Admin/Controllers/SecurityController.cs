using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Yurt.Mvc.DAL;
using Yurt.Mvc.Models;

namespace Yurt.Mvc.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {

        // GET: Admin/Security
        YurtContext ctx = new YurtContext();
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanici klc)
        {
            var kullaniciVarmi = ctx.Kullanicilar.FirstOrDefault(x => x.email == klc.email && x.Sifre == klc.Sifre);
            if (kullaniciVarmi!=null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciVarmi.email, false);
                return RedirectToAction("Index","Ogrenci");
            }
            else
            {
                   return View();
                ViewBag.girisHata = ("Kullanıcı adı ve ya şifre hatalı");
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return View("Login");
        }

    }
}