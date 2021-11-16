using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaterinaria.Models;

namespace Vaterinaria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Registrer()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string Usuario, string pass)
        {
            try
            {
                using (VeterinariaEntities db = new VeterinariaEntities())
                {
                    var list1 = from p in db.personal
                                where p.Usuario == Usuario.Trim() && p.pass == pass.Trim()
                                select p;

                    var list2 = from c in db.UsuarioCliente
                                where c.Usuario == Usuario.Trim() && c.pass == pass.Trim()
                                select c;

                    if(list1.Count() > 0)
                    {
                        personal user = list1.First();
                        Session["User"] = user;
                        return RedirectToAction("Index", "personal");

                    }
                    else if(list2.Count() > 0)
                    {
                        UsuarioCliente userc = list2.First();
                        Session["UserC"] = userc;
                        TempData["UserC"] = userc;
                        return RedirectToAction("Index", "Cliente");
                    }
                    else
                    {
                        TempData["mensaje"] = "Usuario no existe";
                        return RedirectToAction("Login", "Home");
                    }

                }
                
            }
            catch(Exception ex)
            {
                TempData["mensaje"] = "Ocurrio un error";
                return RedirectToAction("Login", "Home");
            }

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}