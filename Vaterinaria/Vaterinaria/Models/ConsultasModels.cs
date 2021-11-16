using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vaterinaria.Models
{
    public class ConsultasModels
    {
        VeterinariaEntities db = new VeterinariaEntities();

        //----------------------Tabla Del Personal-----------------------------------
            public List<personal> listaPersonal()
        {
            return db.personal.ToList();
        }

        public List<personal> listaBuscarPersonal(String Nombre)
        {

            if (Nombre.Equals(""))
            {
                return db.personal.ToList();
            }
            else
            {
                var resultados = from cc in db.personal
                                 where cc.Nombre.Contains(Nombre)
                                 select cc;
                return resultados.ToList();
            }
        }


        public int insertarPersonal(personal Nombre)
        {
            db.personal.Add(Nombre);
            return db.SaveChanges();

        }

        public int editarPersonal(personal Nombreid)
        {
            personal Personal = db.personal.Find(Nombreid.Id_personal);
            Personal.Nombre = Nombreid.Nombre;
            Personal.sexo = Nombreid.sexo;
            Personal.Fecha_nac = Nombreid.Fecha_nac;
            Personal.Id_cargo = Nombreid.Id_cargo;
            Personal.Usuario = Nombreid.Usuario;
            Personal.pass = Nombreid.pass;
            return db.SaveChanges();

        }

        public int eliminarPersonal(int id)
        {
            personal Personal = db.personal.Find(id);
            db.personal.Remove(Personal);
            return db.SaveChanges();
        }

        public personal obtenerPersonal(int id)
        {
            personal Nombre = db.personal.Find(id);
            return Nombre;
        }
        //------------------------------Tabla De Cargo---------------------------------------------------


        public List<cargo> listaCargo()
        {
            return db.cargo.ToList();
        }

        public int insertarCargo(cargo Nombre_cargo)
        {
            db.cargo.Add(Nombre_cargo);
            return db.SaveChanges();

        }

        public int editarCargo(cargo cargoid)
        {
            cargo Cargo = db.cargo.Find(cargoid.Id_cargo);
            Cargo.Nombre_cargo = cargoid.Nombre_cargo;
            return db.SaveChanges();

        }

        public int eliminarCago(int id)
        {
            cargo Cargo = db.cargo.Find(id);
            db.cargo.Remove(Cargo);
            return db.SaveChanges();
        }

        public cargo obtenerCargo(int id)
        {
            cargo Cargo = db.cargo.Find(id);
            return Cargo;
        }


        //-------------------------------Tabla de Usuarios Clientes-----------------------------------------------

        public List<UsuarioCliente> listaCliente()
        {
            return db.UsuarioCliente.ToList();
        }

        public List<UsuarioCliente> listaBuscarClientes(String Nombre)
        {

            if (Nombre.Equals(""))
            {
                return db.UsuarioCliente.ToList();
            }
            else
            {
                var resultados = from cc in db.UsuarioCliente
                                 where cc.Nombre.Contains(Nombre)
                                 select cc;
                return resultados.ToList();
            }
        }


        public int insertarCliente(UsuarioCliente Nombre)
        {
            db.UsuarioCliente.Add(Nombre);
            return db.SaveChanges();

        }

        public int editarCliente(UsuarioCliente Nombreid)
        {
            UsuarioCliente cliente = db.UsuarioCliente.Find(Nombreid.Id_Usuario);
            cliente.Usuario = Nombreid.Usuario;
            cliente.pass = Nombreid.pass;
            cliente.Nombre = Nombreid.Nombre;
            cliente.Edad = Nombreid.Edad;
            cliente.Sexo = Nombreid.Sexo;
            cliente.Direccion = Nombreid.Direccion;
            cliente.Telefono = Nombreid.Telefono;
            
            return db.SaveChanges();

        }

        public int eliminarCliente(int id)
        {
            UsuarioCliente cliente = db.UsuarioCliente.Find(id);
            db.UsuarioCliente.Remove(cliente);
            return db.SaveChanges();
        }

        public UsuarioCliente obtenerCliente(int id)
        {
            UsuarioCliente Nombre = db.UsuarioCliente.Find(id);
            return Nombre;
        }

        //---------------------------------Tabla de el tipo de animal--------------------------------------------------------

        public List<Animal> listaAnimal()
        {
            return db.Animal.ToList();
        }

        public int insertarAnimal(Animal Tipo)
        {
            db.Animal.Add(Tipo);
            return db.SaveChanges();

        }

        public int editarAnimal(Animal Tipoid)
        {
            Animal animal = db.Animal.Find(Tipoid.Id_TipoAnimal);
            animal.Tipo = Tipoid.Tipo;
            return db.SaveChanges();

        }

        public int eliminarAnimal(int id)
        {
            Animal Tipo = db.Animal.Find(id);
            db.Animal.Remove(Tipo);
            return db.SaveChanges();
        }

        public Animal obtenerAnimal(int id)
        {
            Animal Tipo = db.Animal.Find(id);
            return Tipo;
        }

        //---------------------------------Tabla De Citas----------------------------------------------------

            

        public List<Citas> listaCita()
        {
            return db.Citas.ToList();
        }

        public List<Citas> listaBuscarCita(String Nombre_Propietario)
        {

            if (Nombre_Propietario.Equals(""))
            {
                return db.Citas.ToList();
            }
            else
            {
                var resultados = from cc in db.Citas
                                 where cc.Nombre_Propietario.Contains(Nombre_Propietario)
                                 select cc;
                return resultados.ToList();
            }
        }


        public int insertarCita(Citas Cita)
        {
            db.Citas.Add(Cita);
            return db.SaveChanges();

        }

        public int editarCita(Citas Citaid)
        {
            Citas cita = db.Citas.Find(Citaid.Id_cita);
            cita.Nombre_Propietario = Citaid.Nombre_Propietario;
            cita.Id_TipoAnimal = Citaid.Id_TipoAnimal;
            cita.Raza = Citaid.Raza;
            cita.Fecha_cita = Citaid.Fecha_cita;
            cita.Hora_cita = Citaid.Hora_cita;
            cita.Nombre_Animal = Citaid.Nombre_Animal;
            cita.Edad = Citaid.Edad;
            cita.Sexo = Citaid.Sexo;
            cita.Id_personal = Citaid.Id_personal;
            cita.Id_cliente = Citaid.Id_cliente;

            return db.SaveChanges();

        }

        public int eliminarCita(int id)
        {
            Citas Cita = db.Citas.Find(id);
            db.Citas.Remove(Cita);
            return db.SaveChanges();
        }

        public Citas obtenerCita(int id)
        {
            Citas Cita = db.Citas.Find(id);
            return Cita;
        }
    }
}