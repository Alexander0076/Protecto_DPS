using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaterinaria.Models;

namespace Vaterinaria.Controllers
{
    public class AdminUsuarioController : Controller
    {
        ConsultasModels modelo = new ConsultasModels();
        // GET: AdminUsuario
        public ActionResult Index()
        {
            return View(modelo.listaCliente());
        }

        public ActionResult Insertar()
        {
            return View();
        }

        public ActionResult Modificar(int id)
        {
            
            return View(modelo.obtenerCliente(id));
        }

        [ActionName("Buscar")]
        public ActionResult buscar(String valor)
        {

            return View("Index", modelo.listaBuscarCliente(valor));
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
            TempData["mensajePersonal"] = "Se ha ingresado un nuevo usuario cliente";
            return RedirectToAction("Index", modelo.listaCliente());
        }
        [ActionName("Editar")]
        public ActionResult edit(int Id_Usuario, String Usuario, String pass, String Nombre, int Edad, String Sexo, String Direccion, String Telefono)
        {

            UsuarioCliente usuario = new UsuarioCliente();
            usuario.Id_Usuario = Id_Usuario;
            usuario.Usuario = Usuario;
            usuario.pass = pass;
            usuario.Nombre = Nombre;
            usuario.Edad = Edad;
            usuario.Sexo = Sexo;
            usuario.Direccion = Direccion;
            usuario.Telefono = Telefono;

            modelo.editarCliente(usuario);
            TempData["mensajePersonal"] = "Se ha modificado un usuario cliente";
            return RedirectToAction("Index", modelo.listaCliente());
        }
        public ActionResult Eliminar(int id)
        {

            modelo.eliminarCliente(id);
            TempData["mensajePersonal"] = "Usuario cliente eliminado";
            return RedirectToAction("Index", modelo.listaCliente());
        }
    }
}