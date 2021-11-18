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
        ConsultasModels modelo = new ConsultasModels();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Servicios()
        {

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Registrar()
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

                    var list3 = from a in db.administrador
                                where a.Usuario == Usuario.Trim() && a.pass == pass.Trim()
                                select a;

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

                    }else if(list3.Count() > 0)
                    {
                        administrador admin = list3.First();
                        Session["Admin"] = admin;
                        return RedirectToAction("Index", "Admin");
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
        [ActionName("Agregar")]
        public ActionResult insert(String Usuario, String pass, String Nombre, int Edad, String Sexo, String Direccion, String Telefono)
        {
            UsuarioCliente usuario = new UsuarioCliente();
            usuario.Usuario = Usuario;
            usuario.pass = pass;
            usuario.Nombre = Nombre;
            usuario.Edad = Edad;
            usuario.Sexo = Sexo;
            usuario.Direccion = Direccion;
            usuario.Telefono = Telefono;
            
            modelo.insertarCliente(usuario);
            TempData["mensajeCliente"] = "Registro exitoso";
            return RedirectToAction("Login", modelo.listaCliente());
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        

        [ActionName("AgregarMensaje")]
        public ActionResult insertar(String Nombre, String Email, String Phone, String Mensaje)
        {

            Contacto contacto = new Contacto();
            contacto.Nombre = Nombre;
            contacto.Email = Email;
            contacto.Phone = Phone;
            contacto.Mensaje = Mensaje;

            modelo.insertarContacto(contacto);
            TempData["mensajeCliente"] = "Gracias por constactarnos";
            return RedirectToAction("Contact", modelo.listaContacto());
        }
    }
}