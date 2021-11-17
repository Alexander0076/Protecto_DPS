using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaterinaria.Models;

namespace Vaterinaria.Controllers
{
    public class personalController : Controller
    {
        VeterinariaEntities db = new VeterinariaEntities();
        ConsultasModels modelo = new ConsultasModels();
        // GET: personal
        public ActionResult Index()
        {
            return View(modelo.listaCita());
        }
        public ActionResult Detalle(String id)
        {
            return View("Detalle", modelo.listaBuscarCita(id));
        }
        public ActionResult Cerrar()
        {
            Session ["User"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Insertar()
        {

            List<Animal> lista1 = modelo.listaAnimal();
            List<SelectListItem> listaA = new List<SelectListItem>();
            List<personal> lista2 = modelo.listaPersonal();
            List<SelectListItem> listaP = new List<SelectListItem>();
            List<UsuarioCliente> lista3 = modelo.listaCliente();
            List<SelectListItem> listaC = new List<SelectListItem>();
            foreach (Animal item in lista1)
            {
                listaA.Add(new SelectListItem { Text = item.Tipo, Value = item.Id_TipoAnimal.ToString() });
            }

            foreach (personal item in lista2)
            {
                listaP.Add(new SelectListItem { Text = item.Nombre, Value = item.Id_personal.ToString() });
            }

            foreach(UsuarioCliente item in lista3)
            {
                listaC.Add(new SelectListItem { Text = item.Nombre, Value = item.Id_Usuario.ToString() });
            }

            ViewBag.listaCliente = listaC;
            ViewBag.listaPersonal = listaP;
            ViewBag.listaAnimal = listaA;
            return View();
        }

        public ActionResult Modificar(int id)
        {
            List<Animal> lista1 = modelo.listaAnimal();
            List<SelectListItem> listaA = new List<SelectListItem>();
            List<personal> lista2 = modelo.listaPersonal();
            List<SelectListItem> listaP = new List<SelectListItem>();
            List<Estado> lista3 = modelo.listaEstado();
            List<SelectListItem> listaE = new List<SelectListItem>();
            Citas cita = modelo.obtenerCita(id);
            foreach (Animal item in lista1)
            {
                if (item.Id_TipoAnimal == cita.Animal.Id_TipoAnimal)
                {
                    listaA.Add(new SelectListItem { Text = item.Tipo, Value = item.Id_TipoAnimal.ToString(), Selected = true });

                }
                else
                {
                    listaA.Add(new SelectListItem { Text = item.Tipo, Value = item.Id_TipoAnimal.ToString() });

                }

            }

            foreach (personal item in lista2)
            {
                if (item.Id_personal == cita.personal.Id_personal)
                {
                    listaP.Add(new SelectListItem { Text = item.Nombre, Value = item.Id_personal.ToString(), Selected = true });

                }
                else
                {
                    listaP.Add(new SelectListItem { Text = item.Nombre, Value = item.Id_personal.ToString() });

                }

            }

            foreach (Estado item in lista3)
            {
                if (item.Id_estado == cita.Estado.Id_estado)
                {
                    listaE.Add(new SelectListItem { Text = item.Tipo_estado, Value = item.Id_estado.ToString(), Selected = true });

                }
                else
                {
                    listaE.Add(new SelectListItem { Text = item.Tipo_estado, Value = item.Id_estado.ToString() });

                }

            }
            
            ViewBag.listaEstado = listaE;
            ViewBag.listaAnimal = listaA;
            ViewBag.listaPersonal = listaP;
            return View(modelo.obtenerCita(id));
        }

        [ActionName("Buscar")]
        public ActionResult buscar(String valor)
        {

            return View("Index", modelo.listaBuscarCita(valor));
        }


        [ActionName("Agregar")]
        public ActionResult insert(int listaPersonal, int listaAnimal, String Nombre_Propietario, String Raza, DateTime Fecha_cita, TimeSpan Hora_cita, String Nombre_Animal, int Edad, String Sexo)
        {

            Citas cita = new Citas();
            cita.Nombre_Propietario = Nombre_Propietario;
            cita.Id_TipoAnimal = listaAnimal;
            cita.Raza = Raza;
            cita.Fecha_cita = Fecha_cita;
            cita.Hora_cita = Hora_cita;
            cita.Nombre_Animal = Nombre_Animal;
            cita.Edad = Edad;
            cita.Sexo = Sexo;
            cita.Id_personal = listaPersonal;
            cita.Id_estado = 1;



            modelo.insertarCita(cita);
            TempData["mensajeCliente"] = "Se realizo su cita con exito";
            TempData["mensajePersonal"] = Nombre_Propietario + "Ha hecho una cita";
            return RedirectToAction("Index", modelo.listaCita());
        }
        [ActionName("Editar")]
        public ActionResult edit(int listaPersonal, int listaAnimal, int listaEstado, int Id_cita, String Nombre_Propietario, String Raza, DateTime Fecha_cita, TimeSpan Hora_cita, String Nombre_Animal, int Edad, String Sexo)
        {

            Citas cita = new Citas();
            cita.Id_cita = Id_cita;
            cita.Nombre_Propietario = Nombre_Propietario;
            cita.Id_TipoAnimal = listaAnimal;
            cita.Raza = Raza;
            cita.Fecha_cita = Fecha_cita;
            cita.Hora_cita = Hora_cita;
            cita.Nombre_Animal = Nombre_Animal;
            cita.Edad = Edad;
            cita.Sexo = Sexo;
            cita.Id_personal = listaPersonal;
            cita.Id_estado = listaEstado;

            modelo.editarCita(cita);
            TempData["mensajeCliente"] = "Ha modificado su cita";
            TempData["mensajePersonal"] = Nombre_Propietario + " Ha modificado su cita";
            return RedirectToAction("Index", modelo.listaCita());
        }
        public ActionResult Eliminar(int id)
        {

            modelo.eliminarCita(id);
            TempData["mensajeCliente"] = "Cita cancelada";
            TempData["mensajePersonal"] = id + " Ha cancelado su cita";
            return RedirectToAction("Index", modelo.listaCita());
        }
    }
}