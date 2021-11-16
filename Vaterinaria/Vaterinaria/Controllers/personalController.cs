using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vaterinaria.Controllers
{
    public class personalController : Controller
    {
        // GET: personal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cerrar()
        {
            Session ["User"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}