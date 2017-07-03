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
--CREACION DE TABLAS--
-------------------------------------------------------------------------------------

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
	CONSTRAINT PK_RolesID PRIMARY KEY CLUSTERED (id_rol)
)
go

CREATE INDEX IN_Roles ON overhead.roles (rol_nombre, rol_estado);


-------------------------------------------------------------------------------------
--TABLA FUNCIONALIDADES--
-------------------------------------------------------------------------------------
if object_id(N'overhead.funcionalidades', N'U') is not null
	drop table overhead.funcionalidades
go
create table overhead.funcionalidades(
	id_funcionalidad int identity,
	funcionalidad_nombre varchar(100) NOT NULL,
	CONSTRAINT PK_FuncionalidadesID PRIMARY KEY CLUSTERED (id_funcionalidad)
)
go

CREATE INDEX IN_Funcionalidades ON overhead.funcionalidades (funcionalidad_nombre);


-------------------------------------------------------------------------------------
--TABLA FUNCIONALIDADES ASIGNADAS--
-------------------------------------------------------------------------------------
if object_id(N'overhead.funcionalidades_asignadas', N'U') is not null
	drop table overhead.funcionalidades_asignadas
go
create table overhead.funcionalidades_asignadas(
	id_rol int NOT NULL,
	id_funcionalidad int NOT NULL,
	CONSTRAINT PK_RolID_FuncionalidadesID PRIMARY KEY CLUSTERED (id_rol, id_funcionalidad),
	CONSTRAINT FK_Roles FOREIGN KEY (id_rol) REFERENCES overhead.roles (id_rol)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_Funcionalidades FOREIGN KEY (id_funcionalidad) REFERENCES overhead.funcionalidades (id_funcionalidad)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE
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
	cliente_localidad varchar(255),
	cliente_fecha_nacimiento datetime NOT NULL,
	cliente_estado varchar(10),
	CONSTRAINT PK_ClienteDNI PRIMARY KEY CLUSTERED (cliente_dni),
	CONSTRAINT AK_Telefono UNIQUE(cliente_telefono)
)
go

CREATE INDEX IN_Cliente ON overhead.clientes (cliente_nombre, cliente_apellido, cliente_dni, cliente_telefono);


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
	chofer_localidad varchar(255),
	chofer_telefono numeric(18,0) NOT NULL,
	chofer_mail varchar(50) NOT NULL,
	chofer_fecha_nacimiento datetime NOT NULL,
	chofer_estado varchar(10),
	CONSTRAINT PK_ChoferDNI PRIMARY KEY CLUSTERED (chofer_dni)
)
go

CREATE INDEX IN_Chofer ON overhead.choferes (chofer_nombre, chofer_apellido, chofer_dni);


-------------------------------------------------------------------------------------
--TABLA USUARIOS--
-------------------------------------------------------------------------------------
if object_id(N'overhead.usuarios', N'U') is not null
	drop table overhead.usuarios
go
create table overhead.usuarios(
	username varchar(20),
	usu_password varchar(50),
	usu_login_fallidos int,
	usu_dni numeric(18,0),
	usu_estado varchar(10),
	CONSTRAINT PK_Username PRIMARY KEY CLUSTERED (username)
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
	CONSTRAINT PK_Username_RolID PRIMARY KEY CLUSTERED (username, id_rol),
	CONSTRAINT FK_Username FOREIGN KEY (username) REFERENCES overhead.usuarios (username)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_RolesAsignados FOREIGN KEY (id_rol) REFERENCES overhead.roles (id_rol)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE
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
	CONSTRAINT PK_MarcaID PRIMARY KEY CLUSTERED (id_marca)
)
go

CREATE INDEX IN_Marca ON overhead.marcas (marca_nombre);


-------------------------------------------------------------------------------------
--TABLA TURNOS--
-------------------------------------------------------------------------------------
if object_id(N'overhead.turnos', N'U') is not null
	drop table overhead.turnos
go
create table overhead.turnos(
	id_turno int identity,
	turno_descripcion varchar(255) NOT NULL,
	turno_hora_inicio numeric(18,0) NOT NULL,
	turno_hora_fin numeric(18,0) NOT NULL,
	turno_valor_km numeric(18,2) NOT NULL,
	turno_precio_base numeric(18,2) NOT NULL,
	turno_estado varchar(10) NOT NULL,
	CONSTRAINT PK_TurnoID PRIMARY KEY CLUSTERED (id_turno)
)
go

CREATE INDEX IN_Turno ON overhead.turnos (turno_descripcion);


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
	auto_licencia varchar(26),
	auto_rodado varchar(26),
	id_chofer numeric(18,0) NOT NULL,
	auto_estado varchar(10),	
	CONSTRAINT PK_Patente PRIMARY KEY CLUSTERED (auto_patente),
	CONSTRAINT FK_AutosMarcas FOREIGN KEY (id_marca) REFERENCES overhead.marcas (id_marca)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_AutosChoferes FOREIGN KEY (id_chofer) REFERENCES overhead.choferes (chofer_dni)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE
)
go

CREATE INDEX IN_Autos ON overhead.automoviles (auto_patente, id_marca, auto_modelo, id_chofer);


-------------------------------------------------------------------------------------
--TABLA AUTOMOVILES POR TURNO--
-------------------------------------------------------------------------------------
if object_id(N'overhead.autos_por_turnos', N'U') is not null
	drop table overhead.autos_por_turnos
go
create table overhead.autos_por_turnos(
	auto_patente varchar(10) NOT NULL,
	id_turno int NOT NULL 
	CONSTRAINT PK_Patente_Turno PRIMARY KEY CLUSTERED (auto_patente, id_turno),
	CONSTRAINT FK_AutosPatente FOREIGN KEY (auto_patente) REFERENCES overhead.automoviles (auto_patente)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_AutosTurno FOREIGN KEY (id_turno) REFERENCES overhead.turnos (id_turno)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE
)
go


-------------------------------------------------------------------------------------
--TABLA FACTURACIONES--
-------------------------------------------------------------------------------------
if object_id(N'overhead.facturaciones', N'U') is not null
	drop table overhead.facturaciones
go
create table overhead.facturaciones(
	id_factura numeric(18,0),
	factura_fecha datetime,
	id_cliente numeric(18,0) NOT NULL,
	factura_fecha_inicio datetime NOT NULL,
	factura_fecha_fin datetime NOT NULL,
	factura_importe_total numeric(18,2),
	CONSTRAINT PK_Factura PRIMARY KEY CLUSTERED (id_factura),
	CONSTRAINT FK_FacturaCliente FOREIGN KEY (id_cliente) REFERENCES overhead.clientes (cliente_dni)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE
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
	id_factura numeric(18,0),	
	CONSTRAINT PK_ViajeID_AutoID_ClienteID PRIMARY KEY CLUSTERED (id_viaje, id_automovil, id_cliente),
	CONSTRAINT AK_ClienteID_Fecha UNIQUE (id_cliente, viaje_fecha_inicio),
	CONSTRAINT FK_ViajeChofer FOREIGN KEY (id_chofer) REFERENCES overhead.choferes (chofer_dni)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_ViajeTurno FOREIGN KEY (id_turno) REFERENCES overhead.turnos (id_turno)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_ViajeFactura FOREIGN KEY (id_factura) REFERENCES overhead.facturaciones (id_factura)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE
)
go


-------------------------------------------------------------------------------------
--TABLA VIAJES DUPLCIADOS--
-------------------------------------------------------------------------------------
if object_id(N'overhead.viajes_duplicados', N'U') is not null
	drop table overhead.viajes_duplicados
go
create table overhead.viajes_duplicados(
	id_viaje int identity,
	id_chofer numeric(18,0) NOT NULL,
	id_automovil varchar(10) NOT NULL,
	id_turno int NOT NULL,
	viaje_cant_km numeric(18,0) NOT NULL,
	viaje_fecha datetime NOT NULL,
	id_cliente numeric(18,0) NOT NULL,
	id_factura numeric(18,0)
)
go


-------------------------------------------------------------------------------------
--TABLA RENDICIONES--
-------------------------------------------------------------------------------------
if object_id(N'overhead.rendiciones', N'U') is not null
	drop table overhead.rendiciones
go
create table overhead.rendiciones(
	id_rendicion numeric(18,0),
	id_chofer numeric(18,0) NOT NULL,
	id_turno int NOT NULL,
	rendicion_fecha datetime NOT NULL,
	rendicion_importe numeric(18,2) NOT NULL,
	CONSTRAINT PK_RendicionID PRIMARY KEY CLUSTERED (id_rendicion),
	CONSTRAINT FK_RendicionChofer FOREIGN KEY (id_chofer) REFERENCES overhead.choferes (chofer_dni)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_RendicionTurno FOREIGN KEY (id_turno) REFERENCES overhead.turnos (id_turno)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE
)
go


  /*******************************************************/
 /*               MIGRACION DE DATOS                    */
/*******************************************************/

-------------------------------------------------------------------------------------
--INICIACION ROLES--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Roles','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Roles
GO
create procedure overhead.sp_Roles
as
	insert into overhead.roles (rol_nombre, rol_estado)
	values('Administradores', 'Habilitado');

	insert into overhead.roles (rol_nombre, rol_estado)
	values('Clientes', 'Habilitado');

	insert into overhead.roles (rol_nombre, rol_estado)
	values('Choferes', 'Habilitado');
go

-------------------------------------------------------------------------------------
--INICIACION FUNCIONALIDADES--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Funcionalidades','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Funcionalidades
GO
create procedure overhead.sp_Funcionalidades
as
	insert into overhead.funcionalidades (funcionalidad_nombre)
	values ('Administrar Roles')

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
--INICIACION FUNCIONALIDADES ASIGNADAS--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_FuncionalidadesAsignadas','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_FuncionalidadesAsignadas
GO
create procedure overhead.sp_FuncionalidadesAsignadas
as
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

	INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 2)
	INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 3)
	INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 4)
	INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 7)
	INSERT INTO overhead.funcionalidades_asignadas VALUES(2, 9)

	INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 2)
	INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 3)
	INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 5)
	INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 6)
	INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 7)
	INSERT INTO overhead.funcionalidades_asignadas VALUES(3, 8)
go


-------------------------------------------------------------------------------------
--INICIACION CLIENTES--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Clientes','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Clientes
GO
create procedure overhead.sp_Clientes
as
	insert into overhead.clientes (cliente_nombre, cliente_apellido, cliente_dni, cliente_mail, cliente_telefono, cliente_domicilio, cliente_fecha_nacimiento, cliente_estado)
	select Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Mail, Cliente_Telefono, Cliente_Direccion, Cliente_Fecha_Nac, 'Activo'
	from gd_esquema.Maestra
	group by Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Mail, Cliente_Telefono, Cliente_Direccion, Cliente_Fecha_Nac
go



-------------------------------------------------------------------------------------
--INICIACION CHOFERES--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Choferes','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Choferes
GO
create procedure overhead.sp_Choferes
as
	insert into overhead.choferes (chofer_nombre, chofer_apellido, chofer_dni, chofer_domicilio, chofer_telefono, chofer_mail, chofer_fecha_nacimiento, chofer_estado)
	select Chofer_Nombre, Chofer_Apellido, Chofer_Dni, Chofer_Direccion, Chofer_Telefono, Chofer_Mail, Chofer_Fecha_Nac, 'Habilitado'
	from gd_esquema.Maestra
	group by Chofer_Dni, Chofer_Nombre, Chofer_Apellido, Chofer_Mail, Chofer_Telefono, Chofer_Direccion, Chofer_Fecha_Nac
go


-------------------------------------------------------------------------------------
--INICIACION USUARIOS--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Usuarios','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Usuarios
GO
create procedure overhead.sp_Usuarios
as
	insert into overhead.usuarios (username, usu_password, usu_estado)
	values('admin', HASHBYTES('SHA2_256', 'w23e'), 'Habilitado');

	insert into overhead.usuarios (username, usu_password, usu_dni, usu_estado)
	select 
		SUBSTRING(cliente_nombre,1,1)+SUBSTRING(cliente_apellido,1,1)+substring(convert(varchar,cliente_dni),4,5),
		HASHBYTES('SHA2_256', SUBSTRING(cliente_nombre,1,1)+SUBSTRING(cliente_apellido,1,1)+substring(convert(varchar,cliente_dni),4,5)),
		cliente_dni,'Habilitado'
	from overhead.clientes
	union
	select 
		SUBSTRING(chofer_nombre,1,1)+SUBSTRING(chofer_apellido,1,1)+substring(convert(varchar,chofer_dni),4,5),
		HASHBYTES('SHA2_256', SUBSTRING(chofer_nombre,1,1)+SUBSTRING(chofer_apellido,1,1)+substring(convert(varchar,chofer_dni),4,5)),
		chofer_dni,'Habilitado'
	from overhead.choferes
go


-------------------------------------------------------------------------------------
--INICIACION ROLES ASIGNADOS--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_RolesAsignados','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_RolesAsignados
GO
create procedure overhead.sp_RolesAsignados
as
	INSERT INTO overhead.roles_asignados 
	select 'admin', id_rol
	from overhead.roles
	where rol_nombre = 'Administradores'

	INSERT INTO overhead.roles_asignados
	select 'admin', id_rol
	from overhead.roles
	where rol_nombre = 'Clientes'

	INSERT INTO overhead.roles_asignados
	select 'admin', id_rol
	from overhead.roles
	where rol_nombre = 'Choferes'

	INSERT INTO overhead.roles_asignados
	select u.username, r.id_rol
	from overhead.usuarios u
	join overhead.clientes c on c.cliente_dni = u.usu_dni
	join overhead.roles r on r.rol_nombre = 'Clientes'

	INSERT INTO overhead.roles_asignados
	select u.username, r.id_rol
	from overhead.usuarios u
	join overhead.choferes c on c.chofer_dni = u.usu_dni
	join overhead.roles r on r.rol_nombre = 'Choferes'

go


-------------------------------------------------------------------------------------
--INICIACION MARCAS--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Marcas','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Marcas
GO
create procedure overhead.sp_Marcas
as
	insert into overhead.marcas (marca_nombre)
	select Auto_Marca
	from gd_esquema.Maestra
	group by Auto_Marca
go


-------------------------------------------------------------------------------------
--INICIACION TURNOS--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Turnos','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Turnos
GO
create procedure overhead.sp_Turnos
as
	insert into overhead.turnos (turno_descripcion, turno_estado,turno_hora_inicio, turno_hora_fin, turno_valor_km, turno_precio_base)
	select Turno_Descripcion, 'Habilitado',Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Valor_Kilometro, Turno_Precio_Base
	from gd_esquema.Maestra
	group by Turno_Descripcion, Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Valor_Kilometro, Turno_Precio_Base
go


-------------------------------------------------------------------------------------
--INICIACION AUTOS--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Autos','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Autos
GO
create procedure overhead.sp_Autos
as
	insert into overhead.automoviles
	select Auto_Patente, mc.id_marca, m.Auto_Modelo, Auto_Licencia, Auto_Rodado, Chofer_Dni, 'Habilitado'
	from gd_esquema.Maestra m
	left join overhead.marcas mc on (m.Auto_Marca = mc.marca_nombre)
	group by Auto_Patente, mc.id_marca,  m.Auto_Modelo, Chofer_Dni, Auto_Licencia, Auto_Rodado
go


-------------------------------------------------------------------------------------
--INICIACION AUTOS POR TURNOS--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_AutosPorTurnos','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_AutosPorTurnos
GO
create procedure overhead.sp_AutosPorTurnos
as
	insert into overhead.autos_por_turnos
	select a.auto_patente, t.id_turno
	from gd_esquema.Maestra m
	left join overhead.marcas mc on (mc.marca_nombre = m.Auto_Marca)
	left join overhead.automoviles a on (a.auto_patente = m.Auto_Patente
		and a.id_marca = mc.id_marca)
	left join overhead.turnos t on (t.turno_descripcion = m.Turno_Descripcion)
	group by a.auto_patente, t.id_turno
go


-------------------------------------------------------------------------------------
--INICIACION FACTURACIONES--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Facturaciones','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Facturaciones
GO
create procedure overhead.sp_Facturaciones
as
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
		and convert(varchar,v.viaje_fecha_fin,102) between convert(varchar,m.Factura_Fecha_Inicio,102) and convert(varchar,m.Factura_Fecha_Fin,102)
	where m.Factura_Nro is not null
	group by Factura_Nro, Factura_Fecha, Cliente_Dni, Factura_Fecha_Inicio, Factura_Fecha_Fin
go

CREATE TRIGGER overhead.tr_facturas ON overhead.facturaciones
AFTER UPDATE
as
begin
	if update(id_factura)
		update overhead.facturaciones
		set factura_importe_total = (select sum(t.turno_precio_base + v.viaje_cant_km*t.turno_valor_km)
			from overhead.viajes v
			left join overhead.turnos t on (v.id_turno = t.id_turno)
			where v.id_factura = overhead.facturaciones.id_factura
			)
end
go

-------------------------------------------------------------------------------------
--INICIACION FACTURACIONES--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Viajes','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Viajes
GO
create procedure overhead.sp_Viajes
as
	declare
		@id_chofer numeric(18,0),
		@id_automovil varchar(10),
		@id_turno int,
		@viaje_cant_km numeric(18,0),
		@viaje_fecha datetime,
		@id_factura numeric(18,0),
		@id_cliente numeric(18,0)

	declare cr_Viajes cursor for
		select Chofer_Dni, Auto_Patente, t.id_turno, Viaje_Cant_Kilometros, Viaje_Fecha, Factura_Nro, Cliente_Dni
		from gd_esquema.Maestra m
		left join overhead.turnos t on (m.Turno_Descripcion = t.turno_descripcion)
		group by Chofer_Dni, Auto_Patente, t.id_turno, Viaje_Cant_Kilometros, Viaje_Fecha, Factura_Nro, Cliente_Dni

	OPEN cr_Viajes
	FETCH NEXT FROM cr_Viajes
	 INTO @id_chofer,  @id_automovil, @id_turno, @viaje_cant_km, @viaje_fecha, @id_factura, @id_cliente
	WHILE (@@FETCH_STATUS=0)
	begin
		if exists(select * from overhead.viajes v where v.id_cliente = @id_cliente and v.viaje_fecha_fin = @viaje_fecha)
			begin
				insert into overhead.viajes_duplicados (id_chofer,  id_automovil, id_turno, viaje_cant_km, viaje_fecha, id_factura, id_cliente)
				values (@id_chofer,  @id_automovil, @id_turno, @viaje_cant_km, @viaje_fecha, @id_factura, @id_cliente)
			end
		else 
			begin
				insert into overhead.viajes (id_chofer,  id_automovil, id_turno, viaje_cant_km, viaje_fecha_inicio,viaje_fecha_fin, id_cliente)
				values (@id_chofer,  @id_automovil, @id_turno, @viaje_cant_km, @viaje_fecha, @viaje_fecha, @id_cliente)
			end
		FETCH NEXT FROM cr_Viajes
		INTO @id_chofer,  @id_automovil, @id_turno, @viaje_cant_km, @viaje_fecha, @id_factura, @id_cliente
	end
	CLOSE cr_Viajes
	DEALLOCATE cr_Viajes

	update v
	set id_factura = m.Factura_Nro
	from overhead.viajes v
	join gd_esquema.Maestra m on m.Cliente_Dni = v.id_cliente
		and m.Viaje_Fecha = v.viaje_fecha_fin
		and m.Chofer_Dni = v.id_chofer
		and m.Auto_Patente = v.id_automovil
		and m.Factura_Nro is not null;
go


-------------------------------------------------------------------------------------
--INICIACION RENDICIONES--
-------------------------------------------------------------------------------------
IF OBJECT_ID('overhead.sp_Rendiciones','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Rendiciones
GO

create procedure overhead.sp_Rendiciones
as
	insert into overhead.rendiciones
	select Rendicion_Nro, Chofer_Dni, t.id_turno, Rendicion_Fecha, sum(Rendicion_Importe) as total
	from gd_esquema.Maestra m
	left join overhead. turnos t on (t.turno_descripcion = m.Turno_Descripcion)
	where Rendicion_Nro is not null
	group by Rendicion_Nro, Chofer_Dni, t.id_turno, Rendicion_Fecha
go

---------------------------------------------------------------------------------------------------------
--Ejecución de stores procedures
---------------------------------------------------------------------------------------------------------
execute overhead.sp_Roles;
execute overhead.sp_Funcionalidades;
execute overhead.sp_FuncionalidadesAsignadas;
execute overhead.sp_Clientes;
execute overhead.sp_Choferes;
execute overhead.sp_Usuarios;
execute overhead.sp_RolesAsignados;
execute overhead.sp_Marcas;
execute overhead.sp_Turnos;
execute overhead.sp_Autos;
execute overhead.sp_AutosPorTurnos;
execute overhead.sp_Facturaciones;
execute overhead.sp_Viajes;
execute overhead.sp_Rendiciones