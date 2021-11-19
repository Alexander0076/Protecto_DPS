/*Creación de la base de datos*/
CREATE DATABASE Veterinaria
go


/*Identificamos que base vamos a utilizar*/
use Veterinaria
go

/*Creamos la tabla de Admin*/

CREATE TABLE administrador(
Id_admin int identity(1,1) PRIMARY KEY,
Usuario varchar(100),
pass varchar(100)
)
GO

CREATE TABLE Contacto(
Id_contacto int identity(1,1) PRIMARY KEY,
Nombre Varchar (100),
Email Varchar (100),
Phone Varchar (20),
Mensaje text
)
GO

/*Creamos la tabla de cargo*/
CREATE TABLE cargo(
Id_cargo int identity(1,1) PRIMARY KEY,
Nombre_cargo varchar(100)
)
GO

/*Crearemos la tababla Personal*/
CREATE TABLE personal(
Id_personal int identity(1,1) PRIMARY KEY,
Nombre varchar(100),
sexo varchar(20),
Fecha_nac date,
Id_cargo INT FOREIGN KEY REFERENCES cargo(Id_cargo),
Usuario varchar(100),
pass varchar(100)
)
GO

/*Creamos la tabla de Usuario Clientes*/
CREATE TABLE UsuarioCliente(
Id_Usuario int identity(1,1) PRIMARY KEY,
Usuario varchar(100),
pass varchar(100),
Nombre varchar(100),
Edad int,
Sexo varchar(10),
Direccion varchar(100),
Telefono varchar(12)
)
GO

/*Creamos la tabla de Tipo animal*/
CREATE TABLE Animal(
Id_TipoAnimal int identity(1,1) PRIMARY KEY,
Tipo varchar(100),
)
GO

CREATE TABLE Estado(
Id_estado int identity(1,1) PRIMARY KEY,
Tipo_estado varchar (100)
)
GO

/*Creamos la tabla de citas*/
CREATE TABLE Citas(
Id_cita int identity(1,1) PRIMARY KEY,
Nombre_Propietario varchar(100),
Id_TipoAnimal INT FOREIGN KEY REFERENCES Animal(Id_TipoAnimal),
Raza varchar(100),
Fecha_cita date,
Hora_cita time,
Nombre_Animal varchar(100),
Edad int,
Sexo varchar(10),
Id_personal INT FOREIGN KEY REFERENCES personal(Id_personal),
Id_cliente INT FOREIGN KEY REFERENCES UsuarioCliente(Id_Usuario),
Id_estado INT FOREIGN KEY REFERENCES Estado(Id_estado)
)
GO

/*Consultas*/

SELECT * FROM personal inner join cargo  on personal.Id_cargo = cargo.Id_cargo 
SELECT * FROM UsuarioCliente
SELECT * FROM Citas
SELECT * FROM administrador
SELECT * FROM cargo
SELECT * FROM Estado
SELECT * FROM Contacto
SELECT * FROM Animal

INSERT INTO Estado VALUES('Activa')
INSERT INTO Estado VALUES('Finalizada')
INSERT INTO Estado VALUES('Cancelada')
INSERT INTO UsuarioCliente VALUES('cliente','12345','Ulises',19,'Masculino','Zacamil','7125-4039')
INSERT INTO cargo values('Veterinario')
INSERT INTO personal VALUES('Alexander Elías','Masculino','2002-10-02',1,'uliseselias007@gmail.com','123')
INSERT INTO administrador VALUES('admin','1234')
INSERT INTO Animal values('Perro')
