using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaterinaria.Models;

namespace Vaterinaria.Controllers
{
    public class AdminController : Controller
    {
        ConsultasModels modelo = new ConsultasModels();
        // GET: Admin
        public ActionResult Index()
        {
            return View(modelo.listaPersonal());
        }
        public ActionResult Cerrar()
        {
            Session["Admin"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Insertar()
        {

            List<cargo> lista1 = modelo.listaCargo();
            List<SelectListItem> listaA = new List<SelectListItem>();
            foreach (cargo item in lista1)
            {
                listaA.Add(new SelectListItem { Text = item.Nombre_cargo, Value = item.Id_cargo.ToString() });
            }

           
            ViewBag.listaCargo = listaA;
            return View();
        }

        public ActionResult Modificar(int id)
        {
            List<cargo> lista1 = modelo.listaCargo();
            List<SelectListItem> listaA = new List<SelectListItem>();
            personal Personal = modelo.obtenerPersonal(id);
            foreach (cargo item in lista1)
            {
                if (item.Id_cargo == Personal.cargo.Id_cargo)
                {
                    listaA.Add(new SelectListItem { Text = item.Nombre_cargo, Value = item.Id_cargo.ToString(), Selected = true });

                }
                else
                {
                    listaA.Add(new SelectListItem { Text = item.Nombre_cargo, Value = item.Id_cargo.ToString() });

                }

            }
            
            
            ViewBag.listaCargo = listaA;
            return View(modelo.obtenerPersonal(id));
        }

        [ActionName("Buscar")]
        public ActionResult buscar(String valor)
        {

            return View("Index", modelo.listaBuscarPersonal(valor));
        }


        [ActionName("Agregar")]
        public ActionResult insert(int listaCargo, String Nombre, String sexo, DateTime Fecha_nac, String Usuario, String pass)
        {
            personal Personal = new personal();
            Personal.Nombre = Nombre;
            Personal.sexo = sexo;
            Personal.Fecha_nac = Fecha_nac;
            Personal.Id_cargo = listaCargo;
            Personal.Usuario = Usuario;
            Personal.pass = pass;
            
            modelo.insertarPersonal(Personal);
            TempData["mensajePersonal"] = "Se ha ingresado el personal " + Nombre;
            return RedirectToAction("Index", modelo.listaPersonal());
        }
        [ActionName("Editar")]
        public ActionResult edit(int Id_personal, int listaCargo, String Nombre, String sexo, DateTime Fecha_nac, String Usuario, String pass)
        {

            personal Personal = new personal();
            Personal.Id_personal = Id_personal;
            Personal.Nombre = Nombre;
            Personal.sexo = sexo;
            Personal.Fecha_nac = Fecha_nac;
            Personal.Id_cargo = listaCargo;
            Personal.Usuario = Usuario;
            Personal.pass = pass;

            modelo.editarPersonal(Personal);
            TempData["mensajePersonal"] = "Se ha modificado el personal " + Nombre;
            return RedirectToAction("Index", modelo.listaPersonal());
        }
        public ActionResult Eliminar(int id)
        {

            modelo.eliminarPersonal(id);
            TempData["mensajePersonal"] =" Personal eliminado";
            return RedirectToAction("Index", modelo.listaPersonal());
        }
    }
}