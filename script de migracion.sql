USE [GD2C2017]

SET QUOTED_IDENTIFIER OFF
 SET ANSI_NULLS ON 
-- para limpiar y volver a crear todo. Borrar a la mierda para la entrega
DROP TABLE EL_JAPONES_SANGRANDO.SucursalUsuario
DROP TABLE EL_JAPONES_SANGRANDO.RolFuncionalidades
DROP TABLE EL_JAPONES_SANGRANDO.ItemRendicion
DROP TABLE EL_JAPONES_SANGRANDO.ItemFactura
DROP TABLE EL_JAPONES_SANGRANDO.PagoFactura
DROP TABLE EL_JAPONES_SANGRANDO.Funcionalidades
DROP TABLE EL_JAPONES_SANGRANDO.RolUsuario
DROP TABLE EL_JAPONES_SANGRANDO.Roles
DROP TABLE EL_JAPONES_SANGRANDO.Usuarios
DROP TABLE EL_JAPONES_SANGRANDO.Devoluciones
DROP TABLE EL_JAPONES_SANGRANDO.Rendiciones
DROP TABLE EL_JAPONES_SANGRANDO.Facturas
DROP TABLE EL_JAPONES_SANGRANDO.Pagos
DROP TABLE EL_JAPONES_SANGRANDO.MediosDePago
DROP TABLE EL_JAPONES_SANGRANDO.Empresas
DROP TABLE EL_JAPONES_SANGRANDO.Rubros
DROP TABLE EL_JAPONES_SANGRANDO.Sucursales
DROP TABLE EL_JAPONES_SANGRANDO.Clientes

IF OBJECT_ID('EL_JAPONES_SANGRANDO.cambiarItems', 'P') IS NOT NULL
DROP PROCEDURE EL_JAPONES_SANGRANDO.cambiarItems
GO
CREATE SCHEMA [EL_JAPONES_SANGRANDO] AUTHORIZATION [gd]
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Clientes](
	[cli_DNI] [numeric](18,0) not null,
	[cli_nombre] [nvarchar](255),
	[cli_apellido] [nvarchar](255),
	[cli_fechanac] [datetime],
	[cli_mail] [nvarchar] (255),
	[cli_direccion] [nvarchar] (255),
	[cli_CP] [nvarchar] (255),
	[cli_estado] [bit] default 1
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Facturas](
	[fact_num] [numeric](18,0) not null,
	[fact_empresa] [nvarchar](50),
	[fact_cliente] [numeric](18,0),
	[fact_fechaalta] [datetime],
	[fact_fechavenc] [datetime],
	[fact_total] [numeric] (18,2),
	[fact_estado]  [tinyint] default 1

)
GO

CREATE TABLE [EL_JAPONES_SANGRANDO].[ItemFactura](
	[itemfact_id] [numeric](18,0) not null identity,
	[itemfact_monto] [numeric](18,2),
	[itemfact_cantidad] [numeric](18,0),
	[itemfact_factura] [numeric](18,0)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Empresas](
	[emp_CUIT] [nvarchar](50) not null,
	[emp_nombre] [nvarchar](255),
	[emp_direccion] [nvarchar](255),
	[emp_rubro] [numeric](18,0),
	[emp_estado] [bit] default 1
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Rubros](
	[rubro_id] [numeric](18,0) not null identity,
	[rubro_desc] [nvarchar](50)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Pagos](
	[pago_nro] [numeric](18,0) not null,
	[pago_suc] [numeric](18,0),
	[pago_importe] [numeric](18,2),
	[pago_medio] [numeric] (18,0),
	[pago_fecha] [datetime]
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[PagoFactura](
	[pagfact_factura] [numeric](18,0) not null,
	[pagfact_pago] [numeric](18,0) not null
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[MediosDePago](
	[medio_id] [numeric](18,0) not null identity,
	[medio_desc] [nvarchar](255)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Sucursales](
	[suc_CP] [numeric](18,0) not null,
	[suc_nombre] [nvarchar](50),
	[suc_dir] [nvarchar](50),
	[suc_estado] [bit] default 1
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Rendiciones](
	[rend_nro] [numeric](18,0) not null,
	[rend_empresa] [nvarchar](50),
	[rend_importe] [numeric](18,0),
	[rend_porcomision] [numeric](18,0),
	[rend_cantfacturas] [numeric](18,0),
	[rend_fecha] [datetime]
)
CREATE TABLE [EL_JAPONES_SANGRANDO].[ItemRendicion](
	[itemrend_rend] [numeric](18,0) not null,
	[itemrend_factura] [numeric](18,0) not null,
	[itemrend_importe] [numeric](18,2)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Devoluciones](
	[dev_id] [numeric](18,0) not null identity,
	[dev_desc] [nvarchar](100),
	[dev_fact] [numeric](18,0)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Usuarios](
	[usr_name] [nvarchar](50) not null,
	[usr_pass] [varbinary](100),
	[usr_cantidadDeIntentos] [int] default 0,
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[SucursalUsuario](
	[sucusr_suc] [numeric](18,0) not null,
	[sucusr_usr] [nvarchar](50) not null
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Roles](
	[rol_nombre] [nvarchar](50) not null,
	[rol_desc] [nvarchar](100),
	[rol_estado] [bit] default 1
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[RolUsuario](
	[rolusr_usr] [nvarchar](50) not null,
	[rolusr_rol] [nvarchar](50) not null
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Funcionalidades](
	[func_id] [numeric](18,0) not null identity,
	[func_desc] [nvarchar](100)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[RolFuncionalidades](
	[rolf_rol] [nvarchar](50) not null,
	[rolf_func] [numeric](18,0) not null
)
GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[MediosDePago] 
	ADD CONSTRAINT [PK_MediosDePago] PRIMARY KEY ([medio_id])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Sucursales] 
	ADD CONSTRAINT [PK_Sucursal] PRIMARY KEY ([suc_CP])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Clientes] ADD CONSTRAINT [PK_Cliente] PRIMARY KEY ([cli_DNI])
GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Rubros] 
	ADD CONSTRAINT [PK_Rubro] PRIMARY KEY ([rubro_id])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Empresas]
	ADD CONSTRAINT [PK_Empresa] PRIMARY KEY ([emp_CUIT]),
	CONSTRAINT [FK_Emp_Rubro] FOREIGN KEY ([emp_rubro])
    REFERENCES [EL_JAPONES_SANGRANDO].[Rubros] ([rubro_id])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Facturas] 
	ADD CONSTRAINT [PK_Factura] PRIMARY KEY ([fact_num]),
	CONSTRAINT [FK_Fact_Cli] FOREIGN KEY ([fact_cliente])
    REFERENCES [EL_JAPONES_SANGRANDO].[Clientes] ([cli_DNI]),
    CONSTRAINT [FK_Fact_Emp] FOREIGN KEY ([fact_empresa])
    REFERENCES [EL_JAPONES_SANGRANDO].[Empresas] ([emp_CUIT])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[ItemFactura]
	ADD CONSTRAINT [PK_ItemFactura] PRIMARY KEY ([itemfact_id]),
	CONSTRAINT [FK_Item_Fact] FOREIGN KEY (itemfact_factura)
    REFERENCES [EL_JAPONES_SANGRANDO].[Facturas] ([fact_num])
GO

ALTER TABLE [EL_JAPONES_SANGRANDO].[Pagos] 
	ADD CONSTRAINT [PK_Pago] PRIMARY KEY ([pago_nro]),
	CONSTRAINT [FK_Pago_Suc] FOREIGN KEY ([pago_suc])
    REFERENCES [EL_JAPONES_SANGRANDO].[Sucursales] ([suc_CP]),
    CONSTRAINT [FK_Pago_Medio] FOREIGN KEY ([pago_medio])
    REFERENCES [EL_JAPONES_SANGRANDO].[MediosDePago] ([medio_id])


GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[PagoFactura] 
	ADD CONSTRAINT [PK_PagoFactura] PRIMARY KEY ([pagfact_pago], [pagfact_factura]),
	CONSTRAINT [FK_PagoFact_Fact] FOREIGN KEY ([pagfact_factura])
    REFERENCES [EL_JAPONES_SANGRANDO].[Facturas] ([fact_num]),
    CONSTRAINT [FK_PagoFact_Pago] FOREIGN KEY ([pagfact_pago])
    REFERENCES [EL_JAPONES_SANGRANDO].[Pagos] ([pago_nro])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Rendiciones] 
	ADD CONSTRAINT [PK_Rendicion] PRIMARY KEY ([rend_nro]),
	CONSTRAINT [FK_Rend_Emp] FOREIGN KEY ([rend_empresa])
    REFERENCES [EL_JAPONES_SANGRANDO].[Empresas] ([emp_CUIT])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[ItemRendicion] 
	ADD CONSTRAINT [PK_ItemRendicion] PRIMARY KEY ([itemrend_rend],[itemrend_factura]),
	CONSTRAINT [FK_ItemRend_Rend] FOREIGN KEY ([itemrend_rend])
    REFERENCES [EL_JAPONES_SANGRANDO].[Rendiciones] ([rend_nro]),
    CONSTRAINT [FK_ItemRend_Fact] FOREIGN KEY ([itemrend_factura])
    REFERENCES [EL_JAPONES_SANGRANDO].[Facturas] ([fact_num])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Devoluciones] 
	ADD CONSTRAINT [PK_Devolucion] PRIMARY KEY ([dev_id]),
	CONSTRAINT [FK_Dev_Fact] FOREIGN KEY ([dev_fact])
    REFERENCES [EL_JAPONES_SANGRANDO].[Facturas] ([fact_num])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Usuarios] 
	ADD CONSTRAINT [PK_Usuario] PRIMARY KEY ([usr_name])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[SucursalUsuario] 
	ADD CONSTRAINT [PK_SucursalUsuario] PRIMARY KEY ([sucusr_usr], [sucusr_suc]),
	CONSTRAINT [FK_SucUsr_Usr] FOREIGN KEY ([sucusr_usr])
    REFERENCES [EL_JAPONES_SANGRANDO].[Usuarios] ([usr_name]),
    CONSTRAINT [FK_SucUsr_Suc] FOREIGN KEY ([sucusr_suc])
    REFERENCES [EL_JAPONES_SANGRANDO].[Sucursales] ([suc_CP])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Roles] 
	ADD CONSTRAINT [PK_Rol] PRIMARY KEY ([rol_nombre])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[RolUsuario] 
	ADD CONSTRAINT [PK_RolUsuario] PRIMARY KEY ([rolusr_rol], [rolusr_usr]),
	CONSTRAINT [FK_RolUsr_Rol] FOREIGN KEY ([rolusr_rol])
    REFERENCES [EL_JAPONES_SANGRANDO].[Roles] ([rol_nombre]),
    CONSTRAINT [FK_RolUsr_Usr] FOREIGN KEY ([rolusr_usr])
    REFERENCES [EL_JAPONES_SANGRANDO].[Usuarios] ([usr_name])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Funcionalidades] 
	ADD CONSTRAINT [PK_Funcionalidad] PRIMARY KEY ([func_id])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[RolFuncionalidades]
	ADD CONSTRAINT [PK_RolFuncionalidad] PRIMARY KEY ([rolf_func], rolf_rol),
	CONSTRAINT [FK_RolFunc_Rol] FOREIGN KEY ([rolf_rol])
    REFERENCES [EL_JAPONES_SANGRANDO].[Roles] ([rol_nombre]),
    CONSTRAINT [FK_RolFunc_Func] FOREIGN KEY ([rolf_func])
    REFERENCES [EL_JAPONES_SANGRANDO].[Funcionalidades] ([func_id])
GO

CREATE PROCEDURE EL_JAPONES_SANGRANDO.ejecutarProcedure
(@query varchar(8000))
AS
BEGIN
	EXECUTE( @query);

END
GO
-- CLIENTES
INSERT INTO EL_JAPONES_SANGRANDO.Clientes (cli_DNI, cli_apellido, cli_nombre, cli_fechanac, cli_mail, cli_direccion, cli_CP)
SELECT DISTINCT [Cliente-Dni], [Cliente-Apellido], [Cliente-Nombre], [Cliente-Fecha_Nac], Cliente_Mail, Cliente_Direccion, Cliente_Codigo_Postal from gd_esquema.Maestra
-- RUBROS
SET IDENTITY_INSERT EL_JAPONES_SANGRANDO.Rubros ON
INSERT INTO EL_JAPONES_SANGRANDO.Rubros (rubro_id, rubro_desc)
SELECT DISTINCT Empresa_Rubro, Rubro_Descripcion from gd_esquema.Maestra
SET IDENTITY_INSERT EL_JAPONES_SANGRANDO.Rubros OFF
-- EMPRESAS
INSERT INTO EL_JAPONES_SANGRANDO.Empresas(emp_CUIT, emp_nombre, emp_direccion, emp_rubro)
SELECT DISTINCT Empresa_Cuit, Empresa_Nombre, Empresa_Direccion, Empresa_Rubro from gd_esquema.Maestra ORDER BY Empresa_Cuit
-- FACTURAS
INSERT INTO EL_JAPONES_SANGRANDO.Facturas (fact_num, fact_empresa, fact_cliente, fact_fechaalta, fact_fechavenc, fact_total)
SELECT DISTINCT Nro_Factura, Empresa_Cuit, [Cliente-DNI], Factura_Fecha, Factura_Fecha_Vencimiento, Factura_Total from gd_esquema.Maestra M
join EL_JAPONES_SANGRANDO.Clientes C on C.cli_DNI = M.[Cliente-Dni] order by Nro_Factura
-- ITEMS FACTURAS
INSERT INTO EL_JAPONES_SANGRANDO.ItemFactura (itemfact_monto, itemfact_cantidad, itemfact_factura)
SELECT DISTINCT ItemFactura_Cantidad, ItemFactura_Monto, Nro_Factura FROM gd_esquema.Maestra ORDER BY Nro_Factura
-- MEDIOS DE PAGO
INSERT INTO EL_JAPONES_SANGRANDO.MediosDePago (medio_desc)
SELECT DISTINCT FormaPagoDescripcion FROM gd_esquema.Maestra WHERE FormaPagoDescripcion IS NOT NULL
-- SUCURSALES
INSERT INTO EL_JAPONES_SANGRANDO.Sucursales (suc_CP, suc_nombre, suc_dir)
SELECT DISTINCT Sucursal_Codigo_Postal, Sucursal_Nombre, Sucursal_Dirección FROM gd_esquema.Maestra
WHERE Sucursal_Codigo_Postal IS NOT NULL
-- PAGOS. SI BIEN LA RELACION CON FACTURAS ES MUCHOS A MUCHOS, EN LOS DATOS DE LA TABLA MAESTRA SOLO HAY PAGOS QUE PAGAN UNA UNICA FACTURA, POR LO QUE
-- EL IMPORTE DE ESE PAGO ES EL MISMO QUE EL DE LA FACTURA CON EL QUE SE RELACIONA, ENTONCES NO ES NECESARIO SUMAR TODOS LOS IMPORTES DE LAS FACTURAS
-- DEL PAGO DENTRO DE ESTE SCRIPT
INSERT INTO EL_JAPONES_SANGRANDO.Pagos (pago_nro, pago_suc, pago_importe, pago_medio, pago_fecha)
SELECT DISTINCT Pago_nro, Sucursal_Codigo_Postal, Factura_Total, (SELECT medio_id FROM EL_JAPONES_SANGRANDO.MediosDePago WHERE medio_desc = FormaPagoDescripcion), Pago_Fecha FROM gd_esquema.Maestra
WHERE Pago_nro IS NOT NULL
ORDER BY Pago_nro
-- PAGOSFACTURAS
INSERT INTO EL_JAPONES_SANGRANDO.PagoFactura (pagfact_factura, pagfact_pago)
SELECT DISTINCT Nro_Factura, M.Pago_nro FROM gd_esquema.Maestra M
WHERE M.Pago_nro IS NOT NULL
ORDER BY M.Pago_nro 

--Insertar roles
INSERT INTO EL_JAPONES_SANGRANDO.Roles (rol_nombre) values('administrador')
INSERT INTO EL_JAPONES_SANGRANDO.Roles (rol_nombre) values('cobrador')
-- CREACION USUARIO ADMIN
INSERT INTO EL_JAPONES_SANGRANDO.Usuarios (usr_name, usr_pass) values('admin',HASHBYTES('SHA2_256', 'w23e'))



--
INSERT INTO EL_JAPONES_SANGRANDO.Funcionalidades(func_desc)
values('ABM_ROL'),('ABM_CLIENTE'),('ABM_EMPRESA'),('ABM_SUCURSAL'),('ABM_FACTURA'),('REGISTRO_DE_PAGO_DE_FACTURAS'),('LISTADO_ESTADISTICO'),('RENDICION_DE_FACTURAS_COBRADAS'),('DEVOLUCION')

--Vinculo los roles con la funcionalidades que tienen
INSERT INTO EL_JAPONES_SANGRANDO.RolFuncionalidades(rolf_rol, rolf_func)
values('administrador',1),('administrador',2),('administrador',3),('administrador',4),('administrador',5),('administrador',6),('administrador',7),('administrador',8),('administrador',9)

--Le asigno el perfil de administrador al admin
INSERT INTO EL_JAPONES_SANGRANDO.RolUsuario(rolusr_usr, rolusr_rol) values ('admin', 'administrador')


