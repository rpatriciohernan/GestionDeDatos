USE [GD1C2017]
GO

  /*******************************************************/
 /*              CREACION DE ESTRUCTURA                 */
/*******************************************************/


-------------------------------------------------------------------------------------
--CREACION DE ESQUEMA--
-------------------------------------------------------------------------------------
IF EXISTS (SELECT name FROM sys.schemas WHERE name = N'overhead')
   BEGIN
      PRINT 'Dropping the Overhead schema'
      DROP SCHEMA [overhead]
END
GO

CREATE SCHEMA [overhead] AUTHORIZATION [gd]
GO

-------------------------------------------------------------------------------------
--TABLA ROLES--
-------------------------------------------------------------------------------------
if object_id(N'overhead.roles', N'U') is not null
	drop table overhead.roles
go
create table overhead.roles(
	id_rol int identity,
	rol_nombre varchar(15) NOT NULL,
	rol_estado varchar(10),
--	CONSTRAINT PK_RolesID PRIMARY KEY CLUSTERED (id_rol)
)
go

CREATE INDEX IN_Roles ON overhead.roles (rol_nombre, rol_estado)


-------------------------------------------------------------------------------------
--TABLA FUNCIONALIDADES--
-------------------------------------------------------------------------------------

if object_id(N'overhead.funcionalidades', N'U') is not null
	drop table overhead.funcionalidades
go
create table overhead.funcionalidades(
	id_funcionalidad int identity,
	funcionalidad_nombre varchar(100) NOT NULL,
--	CONSTRAINT PK_FuncionalidadesID PRIMARY KEY CLUSTERED (id_funcionalidad)
)
go

CREATE INDEX IN_Funcionalidades ON overhead.funcionalidades (funcionalidad_nombre)


-------------------------------------------------------------------------------------
--TABLA FUNCIONALIDADES ASIGNADAS--
-------------------------------------------------------------------------------------

if object_id(N'overhead.funcionalidades_asignadas', N'U') is not null
	drop table overhead.funcionalidades_asignadas
go
create table overhead.funcionalidades_asignadas(
	id_rol int NOT NULL,
	id_funcionalidad int NOT NULL,
--	CONSTRAINT PK_RolID_FuncionalidadesID PRIMARY KEY CLUSTERED (id_rol, id_funcionalidad),
--	CONSTRAINT FK_Roles FOREIGN KEY (id_rol) REFERENCES overhead.roles (id_rol)     
--		ON DELETE CASCADE    
--		ON UPDATE CASCADE,
--	CONSTRAINT FK_Funcionalidades FOREIGN KEY (id_funcionalidad) REFERENCES overhead.funcionalidades (id_funcionalidad)     
--		ON DELETE CASCADE    
--		ON UPDATE CASCADE
)
go

-------------------------------------------------------------------------------------
--TABLA CLIENTES--
-------------------------------------------------------------------------------------
if object_id(N'overhead.clientes', N'U') is not null
	drop table overhead.clientes
go
create table overhead.clientes(
	cliente_nombre varchar(255) NOT NULL,
	cliente_apellido varchar(255) NOT NULL,
	cliente_dni numeric(18,0) NOT NULL,
	cliente_mail varchar(50),
	cliente_telefono numeric(18,0) NOT NULL,
	cliente_domicilio varchar(255) NOT NULL,
	cliente_codigo_postal numeric(5,0),
	cliente_localidad varchar(255) NOT NULL,
	cliente_fecha_nacimiento datetime NOT NULL,
	cliente_estado varchar(10),
--	CONSTRAINT PK_ClienteDNI PRIMARY KEY CLUSTERED (cliente_dni),
--	CONSTRAINT AK_Telefono UNIQUE(cliente_telefono)
)
go

CREATE INDEX IN_Cliente ON overhead.clientes (cliente_nombre, cliente_apellido, cliente_dni, cliente_telefono)

-------------------------------------------------------------------------------------
--TABLA CHOFERES--
-------------------------------------------------------------------------------------
if object_id(N'overhead.choferes', N'U') is not null
	drop table overhead.choferes
go
create table overhead.choferes(
	chofer_nombre varchar(255) NOT NULL,
	chofer_apellido varchar(255) NOT NULL,
	chofer_dni numeric(18,0) NOT NULL,
	chofer_domicilio varchar(255) NOT NULL,
	chofer_localidad varchar(255) NOT NULL, 
	chofer_telefono varchar(18) NOT NULL,
	chofer_mail varchar(50) NOT NULL,
	chofer_fecha_nacimiento datetime NOT NULL,
	chofer_estado varchar(10),
--	CONSTRAINT PK_ChoferDNI PRIMARY KEY CLUSTERED (chofer_dni)
)
go

CREATE INDEX IN_Chofer ON overhead.choferes (chofer_nombre, chofer_apellido, chofer_dni)


-------------------------------------------------------------------------------------
--TABLA USUARIOS--
-------------------------------------------------------------------------------------

if object_id(N'overhead.usuarios', N'U') is not null
	drop table overhead.usuarios
go

create table overhead.usuarios(
	username varchar(20),
	usu_password varchar(255),
	usu_login_fallidos int,
	usu_dni numeric(18,0),
	usu_estado varchar(10),
--	CONSTRAINT PK_Username PRIMARY KEY CLUSTERED (username)
	)
go

-------------------------------------------------------------------------------------
--TABLA ROLES ASIGNADOS--
-------------------------------------------------------------------------------------

if object_id(N'overhead.roles_asignados', N'U') is not null
	drop table overhead.roles_asignados
go
create table overhead.roles_asignados(
	username varchar(20),
	id_rol int,
--	CONSTRAINT PK_Username_RolID PRIMARY KEY CLUSTERED (username, id_rol),
--	CONSTRAINT FK_Username FOREIGN KEY (username) REFERENCES overhead.usuarios (username)     
--		ON DELETE CASCADE    
--		ON UPDATE CASCADE,
--	CONSTRAINT FK_RolesAsignados FOREIGN KEY (id_rol) REFERENCES overhead.roles (id_rol)     
--		ON DELETE CASCADE    
--		ON UPDATE CASCADE
)
go

-------------------------------------------------------------------------------------
--TABLA MARCAS--
-------------------------------------------------------------------------------------

if object_id(N'overhead.marcas', N'U') is not null
	drop table overhead.marcas
go
create table overhead.marcas(
	id_marca int identity,
	marca_nombre varchar(255),
--	CONSTRAINT PK_MarcaID PRIMARY KEY CLUSTERED (id_marca)
)
go

CREATE INDEX IN_Marca ON overhead.marcas (marca_nombre)

-------------------------------------------------------------------------------------
--TABLA TURNOS--
-------------------------------------------------------------------------------------

if object_id(N'overhead.turnos', N'U') is not null
	drop table overhead.turnos
go
create table overhead.turnos(
	id_turno int identity,
	turno_descripcion varchar(255) NOT NULL,
	turno_hora_inicio Time NOT NULL,
	turno_hora_fin Time NOT NULL,
	turno_valor_km numeric(18,2) NOT NULL,
	turno_precio_base numeric(18,2) NOT NULL,
	turno_estado varchar(10) NOT NULL,
	--CONSTRAINT PK_TurnoID PRIMARY KEY CLUSTERED (id_turno)
)
go

CREATE INDEX IN_Turno ON overhead.turnos (turno_descripcion)

-------------------------------------------------------------------------------------
--TABLA AUTOMOVILES--
-------------------------------------------------------------------------------------

if object_id(N'overhead.automoviles', N'U') is not null
	drop table overhead.automoviles
go

create table overhead.automoviles(
	auto_patente varchar(10) NOT NULL,
	id_marca int NOT NULL,
	auto_modelo varchar(255) NOT NULL,
	id_turno int,
	id_chofer numeric(18,0) NOT NULL,
	auto_estado varchar(10),	
	--CONSTRAINT PK_Patente PRIMARY KEY CLUSTERED (auto_patente),
	--CONSTRAINT FK_AutosMarcas FOREIGN KEY (id_marca) REFERENCES overhead.marcas (id_marca)     
	--	ON DELETE CASCADE    
	--	ON UPDATE CASCADE,
	--CONSTRAINT FK_AutosChoferes FOREIGN KEY (id_chofer) REFERENCES overhead.choferes (chofer_dni)     
	--	ON DELETE CASCADE    
	--	ON UPDATE CASCADE,
	--CONSTRAINT FK_AutosTurnos FOREIGN KEY (id_turno) REFERENCES overhead.turnos (id_turno)     
	--	ON DELETE CASCADE    
	--	ON UPDATE CASCADE
)
go

CREATE INDEX IN_Autos ON overhead.automoviles (auto_patente, id_marca, auto_modelo, id_chofer)



-------------------------------------------------------------------------------------
--TABLA AUTOMOVILES POR TURNO--
-------------------------------------------------------------------------------------

if object_id(N'overhead.autos_por_turnos', N'U') is not null
	drop table overhead.autos_por_turnos
go
create table overhead.autos_por_turnos(
	auto_patente varchar(10) NOT NULL,
	id_turno int NOT NULL 
--	CONSTRAINT PK_Patente_Turno PRIMARY KEY CLUSTERED (auto_patente, id_turno),
--	CONSTRAINT FK_AutosPatente FOREIGN KEY (auto_patente) REFERENCES overhead.automoviles (auto_patente)     
--		ON DELETE CASCADE    
--		ON UPDATE CASCADE,
--	CONSTRAINT FK_AutosTurno FOREIGN KEY (id_turno) REFERENCES overhead.turnos (id_turno)     
--		ON DELETE CASCADE    
--		ON UPDATE CASCADE
)
go


-------------------------------------------------------------------------------------
--TABLA FACTURACIONES--
-------------------------------------------------------------------------------------

if object_id(N'overhead.facturaciones', N'U') is not null
	drop table overhead.facturaciones
go
create table overhead.facturaciones(
	id_factura int identity,
	factura_fecha datetime,
	id_cliente numeric(18,0) NOT NULL,
	factura_fecha_inicio datetime NOT NULL,
	factura_fecha_fin datetime NOT NULL,
	factura_importe_total numeric(18,2),
--	CONSTRAINT PK_Factura PRIMARY KEY CLUSTERED (id_factura),
--	CONSTRAINT FK_FacturaCliente FOREIGN KEY (id_cliente) REFERENCES overhead.clientes (cliente_dni)     
--		ON DELETE CASCADE    
--		ON UPDATE CASCADE
)
go


-------------------------------------------------------------------------------------
--TABLA VIAJES--
-------------------------------------------------------------------------------------

if object_id(N'overhead.viajes', N'U') is not null
	drop table overhead.viajes
go

create table overhead.viajes(
	id_viaje int identity,
	id_chofer numeric(18,0) NOT NULL,
	id_automovil varchar(10) NOT NULL,
	id_turno int NOT NULL,
	viaje_cant_km numeric(18,0) NOT NULL,
	viaje_fecha_inicio datetime NOT NULL,
	viaje_fecha_fin datetime NOT NULL, 
	id_cliente numeric(18,0) NOT NULL,
	id_factura int,
/*	CONSTRAINT PK_ViajeID_AutoID_ClienteID PRIMARY KEY CLUSTERED (id_viaje, id_automovil, id_cliente),
	CONSTRAINT FK_ViajeChofer FOREIGN KEY (id_chofer) REFERENCES overhead.choferes (chofer_dni)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_ViajeTurno FOREIGN KEY (id_turno) REFERENCES overhead.turnos (id_turno)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_ViajeFactura FOREIGN KEY (id_factura) REFERENCES overhead.facturaciones (id_factura)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE */
)
go


-------------------------------------------------------------------------------------
--TABLA RENDICIONES--
-------------------------------------------------------------------------------------


if object_id(N'overhead.rendiciones', N'U') is not null
	drop table overhead.rendiciones
go
create table overhead.rendiciones(
	id_rendicion int identity,
	id_chofer numeric(18,0) NOT NULL,
	id_turno int NOT NULL,
	rendicion_fecha datetime NOT NULL,
	rendicion_importe numeric(18,2) NOT NULL,
/*	CONSTRAINT PK_RendicionID PRIMARY KEY CLUSTERED (id_rendicion),
	CONSTRAINT FK_RendicionChofer FOREIGN KEY (id_chofer) REFERENCES overhead.choferes (chofer_dni)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_RendicionTurno FOREIGN KEY (id_turno) REFERENCES overhead.turnos (id_turno)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE*/
)
go


  /*******************************************************/
 /*               MIGRACION DE DATOS                    */
/*******************************************************/

-------------------------------------------------------------------------------------
--INICIACION ROLES--
-------------------------------------------------------------------------------------
insert into overhead.roles (rol_nombre)
values('Administradores');

insert into overhead.roles (rol_nombre)
values('Clientes');

insert into overhead.roles (rol_nombre)
values('Choferes');
go

-------------------------------------------------------------------------------------
--INICIACION FUNCIONALIDADES--
-------------------------------------------------------------------------------------
insert into overhead.funcionalidades (funcionalidad_nombre)
values ('Administrar Usuarios')

insert into overhead.funcionalidades (funcionalidad_nombre)
values ('Administrar Clientes')

insert into overhead.funcionalidades (funcionalidad_nombre)
values ('Registro de Viajes')

insert into overhead.funcionalidades (funcionalidad_nombre)
values ('Administrar Choferes')

insert into overhead.funcionalidades (funcionalidad_nombre)
values ('Consulta Movimientos Personales')

insert into overhead.funcionalidades (funcionalidad_nombre)
values ('Estadistica')

insert into overhead.funcionalidades (funcionalidad_nombre)
values ('Consulta Vehiculos')

insert into overhead.funcionalidades (funcionalidad_nombre)
values ('Facturacion del Cliente')

insert into overhead.funcionalidades (funcionalidad_nombre)
values ('Rendicion de cuenta del chofer')
go

-------------------------------------------------------------------------------------
--INICIACION USUARIOS--
-------------------------------------------------------------------------------------

INSERT INTO overhead.usuarios VALUES('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 0, '0', 'Activo')


-------------------------------------------------------------------------------------
--INICIACION ROLES ASIGNADOS--
-------------------------------------------------------------------------------------

INSERT INTO overhead.roles_asignados VALUES('admin', 1) 
INSERT INTO overhead.roles_asignados VALUES('admin', 2) 
INSERT INTO overhead.roles_asignados VALUES('admin', 3) 


-------------------------------------------------------------------------------------
--INICIACION FUNCIONALIDADES ASIGNADAS--
-------------------------------------------------------------------------------------
INSERT INTO overhead.funcionalidades_asignadas VALUES(1, 1)
INSERT INTO overhead.funcionalidades_asignadas VALUES(1, 2)
INSERT INTO overhead.funcionalidades_asignadas VALUES(1, 3)
INSERT INTO overhead.funcionalidades_asignadas VALUES(1, 4)
INSERT INTO overhead.funcionalidades_asignadas VALUES(1, 5)
INSERT INTO overhead.funcionalidades_asignadas VALUES(1, 6)
INSERT INTO overhead.funcionalidades_asignadas VALUES(1, 7)
INSERT INTO overhead.funcionalidades_asignadas VALUES(1, 8)
INSERT INTO overhead.funcionalidades_asignadas VALUES(1, 9)
INSERT INTO overhead.funcionalidades_asignadas VALUES(1, 10)

INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 1)
INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 3)
INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 4)
INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 7)
INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 9)

INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 1)
INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 3)
INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 5)
INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 6)
INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 7)
INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 8)

INSERT INTO overhead.funcionalidades_asignadas VALUES(4, 1)
INSERT INTO overhead.funcionalidades_asignadas VALUES(4, 5)

INSERT INTO overhead.funcionalidades_asignadas VALUES(5, 1)

INSERT INTO overhead.funcionalidades_asignadas VALUES(7, 1)

INSERT INTO overhead.funcionalidades_asignadas VALUES(11, 10)


-------------------------------------------------------------------------------------
--INICIACION CLIENTES--
-------------------------------------------------------------------------------------

IF OBJECT_ID('sp_Clientes','P') IS NOT NULL
	DROP PROCEDURE sp_Clientes
GO
create procedure sp_Clientes
as
	insert into overhead.clientes 
		select Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Mail, Cliente_Telefono, Cliente_Direccion, Cliente_Fecha_Nac, 'Activo'
		from gd_esquema.Maestra
		group by Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Mail, Cliente_Telefono, Cliente_Direccion, Cliente_Fecha_Nac
go

execute sp_Clientes

	cliente_nombre varchar(255) NOT NULL,
	cliente_apellido varchar(255) NOT NULL,
	cliente_dni numeric(18,0) NOT NULL,
	cliente_mail varchar(50),
	cliente_telefono numeric(18,0) NOT NULL,
	cliente_domicilio varchar(255) NOT NULL,
	cliente_codigo_postal numeric(5,0),
	cliente_localidad varchar(255) NOT NULL,
	cliente_fecha_nacimiento datetime NOT NULL,
	cliente_estado varchar(10),
-------------------------------------------------------------------------------------
--INICIACION CHOFERES--
-------------------------------------------------------------------------------------

IF OBJECT_ID('sp_Choferes','P') IS NOT NULL
	DROP PROCEDURE sp_Choferes
GO

create procedure sp_Choferes
as
	insert into overhead.choferes
		select Chofer_Nombre, Chofer_Apellido, Chofer_Dni, Chofer_Direccion, Chofer_Telefono, Chofer_Mail, Chofer_Fecha_Nac, 'Activo'
		from gd_esquema.Maestra
		group by Chofer_Dni, Chofer_Nombre, Chofer_Apellido, Chofer_Mail, Chofer_Telefono, Chofer_Direccion, Chofer_Fecha_Nac
go

execute sp_Choferes


-- Usuarios
select * from overhead.usuarios

insert into overhead.usuarios (username, usu_password, usu_estado)
values('admin', 'g3JZVkkIqRRQLFFSF9MxAOXn+gTegIPfrZmbY+7UjuY=', 'Habilitado')

create procedure sp_Usuarios
as
	insert into overhead.usuarios (username, usu_password, usu_dni, usu_estado)
	select SUBSTRING(cliente_nombre,1,1)+SUBSTRING(cliente_apellido,1,1)+substring(convert(varchar,cliente_dni),4,5),
	HASHBYTES('SHA2_256', SUBSTRING(cliente_nombre,1,1)+SUBSTRING(cliente_apellido,1,1)+substring(convert(varchar,cliente_dni),4,5)),
	cliente_dni,'Habilitado'
	from overhead.clientes
go

execute sp_Usuarios

-- Marcas
insert into overhead.marcas (marca_nombre)
select Auto_Marca
from gd_esquema.Maestra
group by Auto_Marca
go

SELECT * FROM overhead.marcas

-- Turnos
insert into overhead.turnos (turno_descripcion, turno_hora_inicio, turno_hora_fin, turno_valor_km, turno_precio_base)
select Turno_Descripcion, Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Valor_Kilometro, Turno_Precio_Base
from gd_esquema.Maestra
group by Turno_Descripcion, Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Valor_Kilometro, Turno_Precio_Base
go

-- Automoviles
insert into overhead.automoviles (auto_patente, id_marca, auto_modelo, id_chofer, auto_licencia, auto_rodado)
select Auto_Patente, mc.id_marca,  m.Auto_Modelo, Chofer_Dni, Auto_Licencia, Auto_Rodado
from gd_esquema.Maestra m
left join overhead.marcas mc on (m.Auto_Marca = mc.marca_nombre)
group by Auto_Patente, mc.id_marca,  m.Auto_Modelo, Chofer_Dni, Auto_Licencia, Auto_Rodado
go

-- Autos Por Turno
insert into overhead.autos_por_turnos
select a.auto_patente, t.id_turno
from gd_esquema.Maestra m
left join overhead.marcas mc on (mc.marca_nombre = m.Auto_Marca)
left join overhead.automoviles a on (a.auto_patente = m.Auto_Patente
	and a.id_marca = mc.id_marca)
left join overhead.turnos t on (t.turno_descripcion = m.Turno_Descripcion)
group by a.auto_patente, t.id_turno
go

-- Viajes
insert into overhead.viajes (id_chofer, id_automovil, id_turno, viaje_cant_km, viaje_fecha, id_factura, id_cliente)
select Chofer_Dni, Auto_Patente, t.id_turno, Viaje_Cant_Kilometros, Viaje_Fecha, Factura_Nro, Cliente_Dni
from gd_esquema.Maestra m
left join overhead.turnos t on (m.Turno_Descripcion = t.turno_descripcion)
group by Chofer_Dni, Auto_Patente, t.id_turno, Viaje_Cant_Kilometros, Viaje_Fecha, Factura_Nro, Cliente_Dni
go

-- Rendiciones
insert into overhead.rendiciones
select Rendicion_Nro, Chofer_Dni, t.id_turno, Rendicion_Fecha, Rendicion_Importe
from gd_esquema.Maestra m
left join overhead. turnos t on (t.turno_descripcion = m.Turno_Descripcion)
where Rendicion_Nro is not null
group by Rendicion_Nro, Chofer_Dni, t.id_turno, Rendicion_Fecha, Rendicion_Importe
go

-- Facturaciones
insert into overhead.facturaciones
select 
Factura_Nro, Factura_Fecha, Cliente_Dni, Factura_Fecha_Inicio, Factura_Fecha_Fin, 
sum(t.turno_precio_base + v.viaje_cant_km*t.turno_valor_km)
from gd_esquema.Maestra m
left join overhead.turnos t on (m.Turno_Descripcion = t.turno_descripcion)
left join overhead.viajes v on (v.id_chofer = m.Chofer_Dni
	and v.id_automovil = m.Auto_Patente
	and v.id_turno = t.id_turno
	and v.id_cliente = m.Cliente_Dni)
	and convert(varchar,v.viaje_fecha,102) between convert(varchar,m.Factura_Fecha_Inicio,102) and convert(varchar,m.Factura_Fecha_Fin,102)
where m.Factura_Nro is not null
group by Factura_Nro, Factura_Fecha, Cliente_Dni, Factura_Fecha_Inicio, Factura_Fecha_Fin
go

SELECT * FROM overhead.usuarios

UPDATE overhead.usuarios
SET usu_estado = 'Activo'
WHERE username = 'prodr142';

SELECT * FROM overhead.roles

SELECT * FROM overhead.funcionalidades_asignadas

INSERT INTO overhead.roles_asignados VALUES('admin', 1) 
INSERT INTO overhead.roles_asignados VALUES('admin', 2) 
INSERT INTO overhead.roles_asignados VALUES('admin', 3) 

INSERT INTO overhead.usuarios VALUES('admin', 'w23e', 0, '0', 'Activo')

INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 7)
INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 9)
INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 3)
INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 3)
INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 5)
INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 4)
INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 6)
INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 7)
INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 8)


UPDATE overhead.funcionalidades_asignadas
SET id_rol = 'Registro de Viajes'
WHERE id_funcionalidad = 7
SELECT * FROM overhead.funcionalidades
SELECT * FROM overhead.automoviles
SELECT * FROM overhead.funcionalidades_asignadas
UPDATE overhead.roles SET rol_nombre ='Administradores', rol_estado = 'Activo' WHERE id_rol = 0
SELECT * FROM overhead.roles
INSERT INTO overhead.funcionalidades_asignadas VALUES(1,7) 



SELECT f.funcionalidad_nombre FROM overhead.funcionalidades_asignadas rf
	JOIN overhead.funcionalidades f ON rf.id_funcionalidad = f.id_funcionalidad AND rf.id_rol = 2


	UPDATE overhead.usuarios SET usu_login_fallidos=0, usu_estado='Activo' WHERE username = 'admin'
	select * from overhead.choferes