using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaterinaria.Models;

namespace Vaterinaria.Controllers
{
    public class AdminAnimalController : Controller
    {
        ConsultasModels modelo = new ConsultasModels();
        // GET: AdminAnimal
        public ActionResult Index()
        {
            return View(modelo.listaAnimal());
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


            return View(modelo.obtenerAnimal(id));
        }

        [ActionName("Buscar")]
        public ActionResult buscar(String valor)
        {

            return View("Index", modelo.listaBuscarAnimal(valor));
        }


        [ActionName("Agregar")]
        public ActionResult insert(String Tipo)
        {
            Animal animal = new Animal();
            animal.Tipo = Tipo;

            modelo.insertarAnimal(animal);
            TempData["mensajePersonal"] = "Se ha ingresado un nuevo tipo de animal";
            return RedirectToAction("Index", modelo.listaAnimal());
        }
        [ActionName("Editar")]
        public ActionResult edit(int Id_TipoAnimal, String Tipo)
        {
            Animal animal = new Animal();
            animal.Id_TipoAnimal = Id_TipoAnimal;
            animal.Tipo = Tipo;

            modelo.editarAnimal(animal);
            TempData["mensajePersonal"] = "Se ha modificado el tipo de animal";
            return RedirectToAction("Index", modelo.listaAnimal());
        }
        public ActionResult Eliminar(int id)
        {

            modelo.eliminarAnimal(id);
            TempData["mensajePersonal"] = " El tipo de animal se ha eliminado";
            return RedirectToAction("Index", modelo.listaAnimal());
        }
    }
}