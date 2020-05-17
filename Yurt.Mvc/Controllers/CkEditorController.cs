using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yurt.Mvc.Controllers
{  [AllowAnonymous]
    public class CkEditorController : Controller
    {
        // GET: CkEditor
        public ActionResult Index()
        {
            return View();
        }
    }
}