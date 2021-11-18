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

        public List<cargo> listaBuscarCargo(String Cargo)
        {

            if (Cargo.Equals(""))
            {
                return db.cargo.ToList();
            }
            else
            {
                var resultados = from cc in db.cargo
                                 where cc.Nombre_cargo.Contains(Cargo)
                                 select cc;
                return resultados.ToList();
            }
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

        public int eliminarCargo(int id)
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

        public List<UsuarioCliente> listaBuscarCliente(String Nombre)
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

        public List<Animal> listaBuscarAnimal(String Tipo)
        {

            if (Tipo.Equals(""))
            {
                return db.Animal.ToList();
            }
            else
            {
                var resultados = from cc in db.Animal
                                 where cc.Tipo.Contains(Tipo)
                                 select cc;
                return resultados.ToList();
            }
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
            cita.Id_estado = Citaid.Id_estado;

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

        //---------------------------------Tabla de estado de cita--------------------------------------------------------

        public List<Estado> listaEstado()
        {
            return db.Estado.ToList();
        }

        public List<Estado> listaBuscarEstado(String Tipo_estado)
        {

            if (Tipo_estado.Equals(""))
            {
                return db.Estado.ToList();
            }
            else
            {
                var resultados = from cc in db.Estado
                                 where cc.Tipo_estado.Contains(Tipo_estado)
                                 select cc;
                return resultados.ToList();
            }
        }

        public int insertarEstado(Estado Estado)
        {
            db.Estado.Add(Estado);
            return db.SaveChanges();

        }

        public int editarEstado(Estado Tipoid)
        {
            Estado estado = db.Estado.Find(Tipoid.Id_estado);
            estado.Tipo_estado = Tipoid.Tipo_estado;
            return db.SaveChanges();

        }

        public int eliminarEstado(int id)
        {
            Estado Tipo = db.Estado.Find(id);
            db.Estado.Remove(Tipo);
            return db.SaveChanges();
        }

        public Estado obtenerEstado(int id)
        {
            Estado Tipo = db.Estado.Find(id);
            return Tipo;
        }

        //---------------------------------Tabla de consultas--------------------------------------------------------

        public List<Contacto> listaContacto()
        {
            return db.Contacto.ToList();
        }

        public List<Contacto> listaBuscarContacto(String Nombre)
        {

            if (Nombre.Equals(""))
            {
                return db.Contacto.ToList();
            }
            else
            {
                var resultados = from cc in db.Contacto
                                 where cc.Nombre.Contains(Nombre)
                                 select cc;
                return resultados.ToList();
            }
        }

        public int insertarContacto(Contacto Nombre)
        {
            db.Contacto.Add(Nombre);
            return db.SaveChanges();

        }

        public int editarContacto(Contacto Nombreid)
        {
            Contacto contacto = db.Contacto.Find(Nombreid.Id_contacto);
            contacto.Nombre = Nombreid.Nombre;
            contacto.Email = Nombreid.Email;
            contacto.Phone = Nombreid.Phone;
            contacto.Mensaje = Nombreid.Mensaje;
            return db.SaveChanges();

        }

        public int eliminarContacto(int id)
        {
            Contacto contacto = db.Contacto.Find(id);
            db.Contacto.Remove(contacto);
            return db.SaveChanges();
        }

        public Contacto obtenerContacto(int id)
        {
            Contacto contacto = db.Contacto.Find(id);
            return contacto;
        }
    }
}