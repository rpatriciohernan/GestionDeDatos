USE [GD1C2017]
GO

-------------------------------------------------------------------------------------
--BORRADO DE ESQUEMA--
-------------------------------------------------------------------------------------
IF EXISTS (SELECT name FROM sys.schemas WHERE name = N'overhead')
   BEGIN

  /*******************************************************/
 /*               BORRADO DE TABLAS                     */
/*******************************************************/

if object_id(N'overhead.rendiciones', N'U') is not null
	drop table overhead.rendiciones

if object_id(N'overhead.viajes', N'U') is not null
	drop table overhead.viajes

if object_id(N'overhead.facturaciones', N'U') is not null
	drop table overhead.facturaciones

if object_id(N'overhead.autos_por_turnos', N'U') is not null
	drop table overhead.autos_por_turnos

if object_id(N'overhead.automoviles', N'U') is not null
	drop table overhead.automoviles

if object_id(N'overhead.turnos', N'U') is not null
	drop table overhead.turnos

if object_id(N'overhead.marcas', N'U') is not null
	drop table overhead.marcas

if object_id(N'overhead.roles_asignados', N'U') is not null
	drop table overhead.roles_asignados

if object_id(N'overhead.usuarios', N'U') is not null
	drop table overhead.usuarios

if object_id(N'overhead.choferes', N'U') is not null
	drop table overhead.choferes

if object_id(N'overhead.clientes', N'U') is not null
	drop table overhead.clientes

if object_id(N'overhead.funcionalidades_asignadas', N'U') is not null
	drop table overhead.funcionalidades_asignadas

if object_id(N'overhead.funcionalidades', N'U') is not null
	drop table overhead.funcionalidades

if object_id(N'overhead.roles', N'U') is not null
	drop table overhead.roles


  /*******************************************************/
 /*               BORRADO DE STORES PROCEDURES          */
/*******************************************************/

IF OBJECT_ID('overhead.sp_Roles','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Roles

IF OBJECT_ID('overhead.sp_Funcionalidades','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Funcionalidades

IF OBJECT_ID('overhead.sp_FuncionalidadesAsignadas','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_FuncionalidadesAsignadas

IF OBJECT_ID('overhead.sp_Clientes','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Clientes

IF OBJECT_ID('overhead.sp_Choferes','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Choferes

IF OBJECT_ID('overhead.sp_Usuarios','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Usuarios

IF OBJECT_ID('overhead.sp_RolesAsignados','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_RolesAsignados

IF OBJECT_ID('overhead.sp_Marcas','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Marcas

IF OBJECT_ID('overhead.sp_Turnos','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Turnos

IF OBJECT_ID('overhead.sp_Autos','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Autos

IF OBJECT_ID('overhead.sp_AutosPorTurnos','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_AutosPorTurnos

IF OBJECT_ID('overhead.sp_Facturaciones','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Facturaciones

IF OBJECT_ID('overhead.sp_Viajes','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Viajes

IF OBJECT_ID('overhead.sp_Rendiciones','P') IS NOT NULL
	DROP PROCEDURE overhead.sp_Rendiciones


  /*******************************************************/
 /*               BORRADO DE TRIGGERS                   */
/*******************************************************/
IF OBJECT_ID('overhead.ActualizarRolesInactivos','T') IS NOT NULL
	DROP PROCEDURE overhead.ActualizarRolesInactivos

IF OBJECT_ID('overhead.ActualizarFuncionalidadesEliminadas','T') IS NOT NULL
	DROP PROCEDURE overhead.ActualizarFuncionalidadesEliminadas

	
  /*******************************************************/
 /*               BORRADO DE VISTAS                     */
/*******************************************************/

IF OBJECT_ID(N'overhead.choferes_con_mayor_recaudacion', N'V') IS NOT NULL
    DROP VIEW overhead.choferes_con_mayor_recaudacion

IF OBJECT_ID(N'overhead.choferes_con_viaje_mas_largo', N'V') IS NOT NULL
    DROP VIEW overhead.choferes_con_viaje_mas_largo

IF OBJECT_ID(N'overhead.clientes_con_mayor_uso_de_un_mismo_automovil', N'V') IS NOT NULL
    DROP VIEW overhead.clientes_con_mayor_uso_de_un_mismo_automovil

IF OBJECT_ID(N'overhead.clientes_con_mayor_consumo', N'V') IS NOT NULL
    DROP VIEW overhead.clientes_con_mayor_consumo


-----------------------------------------------------------------------------------------
--BORRAR ESQUEMA
-----------------------------------------------------------------------------------------
PRINT 'Dropping the Overhead schema'
DROP SCHEMA [overhead]
END


  /*******************************************************/
 /*               CREACIÓN DE ESQUEMA                   */
/*******************************************************/

GO
CREATE SCHEMA [overhead] AUTHORIZATION [gd]
GO


  /*******************************************************/
 /*               CREACIÓN DE TABLAS                    */
/*******************************************************/

-------------------------------------------------------------------------------------
--TABLA ROLES--
-------------------------------------------------------------------------------------
create table overhead.roles(
	id_rol int identity,
	rol_nombre varchar(15) NOT NULL,
	rol_estado varchar(10),
	CONSTRAINT PK_RolesID PRIMARY KEY CLUSTERED (id_rol)
)
go

--GENERACIÓN DE INDICES
CREATE INDEX search_rol_nombre ON overhead.roles (rol_nombre);
CREATE INDEX search_rol_estado ON overhead.roles (rol_estado);


-------------------------------------------------------------------------------------
--TABLA FUNCIONALIDADES--
-------------------------------------------------------------------------------------
create table overhead.funcionalidades(
	id_funcionalidad int identity,
	funcionalidad_nombre varchar(100) NOT NULL,
	CONSTRAINT PK_FuncionalidadesID PRIMARY KEY CLUSTERED (id_funcionalidad)
)
go

--GENERACIÓN DE INDICES
CREATE INDEX search_funcionalidades_nombre ON overhead.funcionalidades (funcionalidad_nombre);


-------------------------------------------------------------------------------------
--TABLA FUNCIONALIDADES ASIGNADAS--
-------------------------------------------------------------------------------------
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

--GENERACIÓN DE INDICES
CREATE INDEX search_cliente_nombre ON overhead.clientes (cliente_nombre);
CREATE INDEX search_cliente_apellido ON overhead.clientes (cliente_apellido);


-------------------------------------------------------------------------------------
--TABLA CHOFERES--
-------------------------------------------------------------------------------------
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

--GENERACIÓN DE INDICES
CREATE INDEX search_chofer_nombre ON overhead.choferes (chofer_nombre);
CREATE INDEX search_chofer_apellido ON overhead.choferes (chofer_apellido);


-------------------------------------------------------------------------------------
--TABLA USUARIOS--
-------------------------------------------------------------------------------------
create table overhead.usuarios(
	username varchar(20),
	usu_password varbinary(50),
	usu_login_fallidos int,
	usu_dni numeric(18,0),
	usu_estado varchar(10),
	CONSTRAINT PK_Username PRIMARY KEY CLUSTERED (username)
)
go


-------------------------------------------------------------------------------------
--TABLA ROLES ASIGNADOS--
-------------------------------------------------------------------------------------
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
create table overhead.marcas(
	id_marca int identity,
	marca_nombre varchar(255),
	CONSTRAINT PK_MarcaID PRIMARY KEY CLUSTERED (id_marca)
)
go

--GENERACIÓN DE INDICES
CREATE INDEX search_marca_nombre ON overhead.marcas (marca_nombre);


-------------------------------------------------------------------------------------
--TABLA TURNOS--
-------------------------------------------------------------------------------------
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

--GENERACIÓN DE INDICES
CREATE INDEX search_turno_descripcion ON overhead.turnos (turno_descripcion);


-------------------------------------------------------------------------------------
--TABLA AUTOMOVILES--
-------------------------------------------------------------------------------------
create table overhead.automoviles(
	auto_patente varchar(10) NOT NULL,
	id_marca int NOT NULL,
	auto_modelo varchar(255) NOT NULL,
	id_turno int NOT NULL,		
	id_chofer numeric(18,0) NOT NULL,
	auto_estado varchar(10),
	auto_licencia varchar(26),
	auto_rodado varchar(26),
	CONSTRAINT PK_Patente PRIMARY KEY CLUSTERED (auto_patente),
	CONSTRAINT FK_AutosMarcas FOREIGN KEY (id_marca) REFERENCES overhead.marcas (id_marca)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_AutosChoferes FOREIGN KEY (id_chofer) REFERENCES overhead.choferes (chofer_dni)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_AutosTurno FOREIGN KEY (id_turno) REFERENCES overhead.turnos (id_turno)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE
)
go

--GENERACIÓN DE INDICES
create index search_autos_modelo on overhead.automoviles (auto_modelo);
create index search_autos_marca on overhead.automoviles (id_marca);
create index search_autos_chofer on overhead.automoviles (id_chofer);

-------------------------------------------------------------------------------------
--TABLA AUTOMOVILES POR TURNO--
-------------------------------------------------------------------------------------
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

--GENERACIÓN DE INDICES
CREATE INDEX search_turno ON overhead.autos_por_turnos (id_turno);
CREATE INDEX search_auto_patente ON overhead.automoviles (auto_patente);

-------------------------------------------------------------------------------------
--TABLA FACTURACIONES--
-------------------------------------------------------------------------------------
create table overhead.facturaciones(
	id_factura numeric(18,0) identity,
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
	CONSTRAINT PK_ViajeID_AutoID_ClienteID PRIMARY KEY CLUSTERED (id_viaje),
	CONSTRAINT FK_ViajeChofer FOREIGN KEY (id_chofer) REFERENCES overhead.choferes (chofer_dni)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE,
	CONSTRAINT FK_ViajeTurno FOREIGN KEY (id_turno) REFERENCES overhead.turnos (id_turno)     
		ON DELETE CASCADE    
		ON UPDATE CASCADE
)
go


-------------------------------------------------------------------------------------
--TABLA RENDICIONES--
-------------------------------------------------------------------------------------
create table overhead.rendiciones(
	id_rendicion numeric(18,0) identity,
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
create procedure overhead.sp_Roles
as
	insert into overhead.roles (rol_nombre, rol_estado)
	values('Administradores', 'Activo');

	insert into overhead.roles (rol_nombre, rol_estado)
	values('Clientes', 'Activo');

	insert into overhead.roles (rol_nombre, rol_estado)
	values('Choferes', 'Activo');
go

-------------------------------------------------------------------------------------
--INICIACION FUNCIONALIDADES--
-------------------------------------------------------------------------------------
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
create procedure overhead.sp_Choferes
as
	insert into overhead.choferes (chofer_nombre, chofer_apellido, chofer_dni, chofer_domicilio, chofer_telefono, chofer_mail, chofer_fecha_nacimiento, chofer_estado)
	select Chofer_Nombre, Chofer_Apellido, Chofer_Dni, Chofer_Direccion, Chofer_Telefono, Chofer_Mail, Chofer_Fecha_Nac, 'Activo'
	from gd_esquema.Maestra
	group by Chofer_Dni, Chofer_Nombre, Chofer_Apellido, Chofer_Mail, Chofer_Telefono, Chofer_Direccion, Chofer_Fecha_Nac
go


-------------------------------------------------------------------------------------
--INICIACION USUARIOS--
-------------------------------------------------------------------------------------
create procedure overhead.sp_Usuarios
as
	insert into overhead.usuarios (username, usu_password, usu_estado, usu_login_fallidos, usu_dni)
	values('admin', HASHBYTES('SHA2_256', 'w23e'), 'Activo', 0, 0);

	insert into overhead.usuarios (username, usu_password, usu_dni, usu_estado, usu_login_fallidos)
	select 
		replace(SUBSTRING(cliente_nombre,1,1)+SUBSTRING(cliente_apellido,1,1)+substring(convert(varchar,cliente_dni),4,5), 'Á', 'A'),
		HASHBYTES('SHA2_256', replace(SUBSTRING(cliente_nombre,1,1)+SUBSTRING(cliente_apellido,1,1)+substring(convert(varchar,cliente_dni),4,5), 'Á', 'A')),
		cliente_dni,'Activo', 0
	from overhead.clientes
	union
	select 
		replace(SUBSTRING(chofer_nombre,1,1)+SUBSTRING(chofer_apellido,1,1)+substring(convert(varchar,chofer_dni),4,5), 'Á', 'A'),
		HASHBYTES('SHA2_256', replace(SUBSTRING(chofer_nombre,1,1)+SUBSTRING(chofer_apellido,1,1)+substring(convert(varchar,chofer_dni),4,5), 'Á', 'A')),
		chofer_dni,'Activo', 0
	from overhead.choferes
go


-------------------------------------------------------------------------------------
--INICIACION ROLES ASIGNADOS--
-------------------------------------------------------------------------------------
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
create procedure overhead.sp_Turnos
as
	insert into overhead.turnos (turno_descripcion, turno_estado,turno_hora_inicio, turno_hora_fin, turno_valor_km, turno_precio_base)
	select Turno_Descripcion, 'Activo',Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Valor_Kilometro, Turno_Precio_Base
	from gd_esquema.Maestra
	group by Turno_Descripcion, Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Valor_Kilometro, Turno_Precio_Base
go


-------------------------------------------------------------------------------------
--INICIACION AUTOS--
-------------------------------------------------------------------------------------
create procedure overhead.sp_Autos
as
	insert into overhead.automoviles
	select Auto_Patente, mc.id_marca, m.Auto_Modelo, Chofer_Dni, 'Activo', Auto_Licencia, Auto_Rodado
	from gd_esquema.Maestra m
	join overhead.marcas mc on (m.Auto_Marca = mc.marca_nombre)
	group by Auto_Patente, mc.id_marca, m.Auto_Modelo, Chofer_Dni, Auto_Licencia, Auto_Rodado
go


-------------------------------------------------------------------------------------
--INICIACION AUTOS POR TURNOS--
-------------------------------------------------------------------------------------
create procedure overhead.sp_AutosPorTurnos
as
	insert into overhead.autos_por_turnos
	select m.auto_patente, t.id_turno
	from gd_esquema.Maestra m
	join overhead.turnos t on (t.turno_descripcion = m.Turno_Descripcion)
	group by m.auto_patente, t.id_turno
go


-------------------------------------------------------------------------------------
--INICIACION FACTURACIONES--
-------------------------------------------------------------------------------------
create procedure overhead.sp_Facturaciones
as
	SET IDENTITY_INSERT overhead.facturaciones ON

		insert into overhead.facturaciones (id_factura, factura_fecha, id_cliente, factura_fecha_inicio, factura_fecha_fin, factura_importe_total)
		select Factura_Nro, Factura_Fecha, Cliente_Dni, Factura_Fecha_Inicio, Factura_Fecha_Fin, 
		sum(turno_precio_base + Viaje_Cant_Kilometros*Turno_Valor_Kilometro)
		from gd_esquema.Maestra m
		where m.Factura_Nro is not null
		and convert(varchar,viaje_fecha,102) between convert(varchar,m.Factura_Fecha_Inicio,102) and convert(varchar,m.Factura_Fecha_Fin,102)
		group by Factura_Nro, Factura_Fecha, Cliente_Dni, Factura_Fecha_Inicio, Factura_Fecha_Fin

	SET IDENTITY_INSERT overhead.facturaciones OFF
go


-------------------------------------------------------------------------------------
--INICIACION VIAJES--
-------------------------------------------------------------------------------------
create procedure overhead.sp_Viajes
as
	insert into overhead.viajes(id_chofer,  id_automovil, id_turno, viaje_cant_km, viaje_fecha_inicio, viaje_fecha_fin, id_cliente, id_factura)
	select Chofer_Dni, Auto_Patente, t.id_turno, Viaje_Cant_Kilometros, Viaje_Fecha, Viaje_Fecha, Cliente_Dni, Factura_Nro 
	from gd_esquema.Maestra m
	join overhead.turnos t on (m.Turno_Descripcion = t.turno_descripcion)
	group by Chofer_Dni, Auto_Patente, t.id_turno, Viaje_Cant_Kilometros, Viaje_Fecha, Factura_Nro, Cliente_Dni

go


-------------------------------------------------------------------------------------
--INICIACION RENDICIONES--
-------------------------------------------------------------------------------------
create procedure overhead.sp_Rendiciones
as
	SET IDENTITY_INSERT overhead.rendiciones ON
		insert into overhead.rendiciones(id_rendicion, id_chofer, id_turno, rendicion_fecha, rendicion_importe)
		select Rendicion_Nro, Chofer_Dni, t.id_turno, Rendicion_Fecha, sum(Rendicion_Importe) as total
		from gd_esquema.Maestra m
		join overhead. turnos t on (t.turno_descripcion = m.Turno_Descripcion)
		where Rendicion_Nro is not null
		group by Rendicion_Nro, Chofer_Dni, t.id_turno, Rendicion_Fecha
	SET IDENTITY_INSERT overhead.rendiciones OFF
go

  /**********************************************************/
 /* EJECUCIÓN DE STORES PROCEDURES PARA MIGRACIÓN DE DATOS */
/**********************************************************/
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
execute overhead.sp_Rendiciones;


  /*******************************************************/
 /*     CREACION DE VISTAS PARA LAS ESTADISTICAS        */
/*******************************************************/
-- choferes con mayor recaudacion
go
create view overhead.choferes_con_mayor_recaudacion as
	select top 5 chofer_nombre, chofer_apellido, chofer_dni, SUM(t.turno_precio_base + t.turno_valor_km * v.viaje_cant_km) recaudacion,
	DATEPART(quarter, v.viaje_fecha_inicio) trimestre, DATEPART(YEAR, v.viaje_fecha_inicio) anio 
	from overhead.choferes c
	join overhead.viajes v on v.id_chofer = c.chofer_dni
	join overhead.turnos t on t.id_turno = v.id_turno
	where c.chofer_estado = 'Activo'
	group by chofer_nombre, chofer_apellido, chofer_dni, DATEPART(quarter, v.viaje_fecha_inicio), DATEPART(YEAR, v.viaje_fecha_inicio)
	order by recaudacion desc;
go

-- choferes con mayor viaje realizado
go
create view overhead.choferes_con_viaje_mas_largo as
	select top 5 chofer_nombre, chofer_apellido, chofer_dni, v.viaje_cant_km, DATEPART(quarter, v.viaje_fecha_inicio) trimestre, DATEPART(YEAR, v.viaje_fecha_inicio ) anio 
	from overhead.choferes c
	join overhead.viajes v on v.id_chofer = c.chofer_dni
	where c.chofer_estado = 'Activo'
	group by chofer_nombre, chofer_apellido, chofer_dni, v.viaje_cant_km, DATEPART(quarter, v.viaje_fecha_inicio), DATEPART(YEAR, v.viaje_fecha_inicio)
	order by v.viaje_cant_km desc;
go


-- cliente que uso mas veces un mismo automovil
go
create view overhead.clientes_con_mayor_uso_de_un_mismo_automovil as
	select top 5 c.cliente_nombre, c.cliente_apellido, c.cliente_dni, v.id_automovil, count(*) cantidad_de_viajes_con_mismo_auto,
	DATEPART(quarter, v.viaje_fecha_inicio) trimestre, DATEPART(YEAR, v.viaje_fecha_inicio) anio 
	from overhead.clientes c
	join overhead.viajes v on v.id_cliente = c.cliente_dni
	where c.cliente_estado = 'Activo'
	group by c.cliente_nombre, c.cliente_apellido, c.cliente_dni, v.id_automovil, DATEPART(quarter, v.viaje_fecha_inicio), DATEPART(YEAR, v.viaje_fecha_inicio)
	order by cantidad_de_viajes_con_mismo_auto desc;
go


-- clientes con mayor consumo
go
create view overhead.clientes_con_mayor_consumo as
	select top 5 c.cliente_nombre, c.cliente_apellido, c.cliente_dni, SUM(t.turno_precio_base + t.turno_valor_km * v.viaje_cant_km) consumo,
	DATEPART(quarter, v.viaje_fecha_inicio) trimestre, DATEPART(YEAR, v.viaje_fecha_inicio) anio 
	from overhead.clientes c
	join overhead.viajes v on c.cliente_dni = v.id_cliente
	join overhead.turnos t on t.id_turno = v.id_turno
	where c.cliente_estado = 'Activo'
	group by c.cliente_nombre, c.cliente_apellido, c.cliente_dni, DATEPART(quarter, v.viaje_fecha_inicio), DATEPART(YEAR, v.viaje_fecha_inicio)
	order by consumo desc;
go


  /*******************************************************/
 /*                 CREACION DE TRIGGERS                */
/*******************************************************/

---------------------------------------------------------------------------------------------------------
--Trigger para actualizar Roles Inactivos
---------------------------------------------------------------------------------------------------------
go
CREATE TRIGGER overhead.ActualizarRolesInactivos
ON overhead.roles 
AFTER UPDATE, DELETE
AS
BEGIN
	DECLARE @IDROL int
	DECLARE @NUEVOESTADO varchar(10)
	
	IF EXISTS (SELECT 1 FROM inserted) 	
			SELECT @IDROL = id_rol, @NUEVOESTADO = rol_estado FROM inserted
	ELSE
			BEGIN
				SELECT @IDROL = id_rol FROM deleted
				SET @NUEVOESTADO = 'Inactivo'
				DELETE FROM overhead.funcionalidades_asignadas WHERE id_rol = @IDROL
			END
	
	IF (@NUEVOESTADO IS NOT NULL) AND (@NUEVOESTADO = 'Inactivo')
	DELETE FROM overhead.roles_asignados WHERE id_rol = @IDROL

	
END
go

---------------------------------------------------------------------------------------------------------
--Trigger para actualizar Funcionalidades Eliminadas
---------------------------------------------------------------------------------------------------------
go
CREATE TRIGGER overhead.ActualizarFuncionalidadesEliminadas
ON overhead.funcionalidades
AFTER DELETE
AS
BEGIN
	DECLARE @IDFUNCIONALIDAD int
	
	IF EXISTS (SELECT 1 FROM deleted) 	
		BEGIN
				SELECT @IDFUNCIONALIDAD = id_funcionalidad FROM deleted
				DELETE FROM overhead.funcionalidades_asignadas WHERE id_funcionalidad = @IDFUNCIONALIDAD
		END
	
END
go