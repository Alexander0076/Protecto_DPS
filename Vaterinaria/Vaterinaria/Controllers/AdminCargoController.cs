using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaterinaria.Models;

namespace Vaterinaria.Controllers
{
    public class AdminCargoController : Controller
    {
        ConsultasModels modelo = new ConsultasModels();
        // GET: AdminCargo
        public ActionResult Index()
        {
            return View(modelo.listaCargo());
        }
        public ActionResult Cerrar()
        {
            Session["Admin"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Insertar()
        {
            
            return View();
        }

        public ActionResult Modificar(int id)
        {
            
            
            return View(modelo.obtenerCargo(id));
        }

        [ActionName("Buscar")]
        public ActionResult buscar(String valor)
        {

            return View("Index", modelo.listaBuscarCargo(valor));
        }


        [ActionName("Agregar")]
        public ActionResult insert(String Nombre_cargo)
        {
            cargo Cargo = new cargo();
            Cargo.Nombre_cargo = Nombre_cargo;

            modelo.insertarCargo(Cargo);
            TempData["mensajePersonal"] = "Se ha ingresado un nuevo cargo";
            return RedirectToAction("Index", modelo.listaPersonal());
        }
        [ActionName("Editar")]
        public ActionResult edit(int Id_cargo, String Nombre_cargo)
        {
            cargo Cargo = new cargo();
            Cargo.Id_cargo = Id_cargo;
            Cargo.Nombre_cargo = Nombre_cargo;

            modelo.editarCargo(Cargo);
            TempData["mensajePersonal"] = "Se ha modificado el cargo " + Nombre_cargo;
            return RedirectToAction("Index", modelo.listaCargo());
        }
        public ActionResult Eliminar(int id)
        {

            modelo.eliminarCargo(id);
            TempData["mensajePersonal"] = " Cargo eliminado";
            return RedirectToAction("Index", modelo.listaCargo());
        }
    }
}