USE [GD2C2017]

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON 


--Se crea el schema si es necesario
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'EL_JAPONES_SANGRANDO')
BEGIN
 EXEC ('CREATE SCHEMA [EL_JAPONES_SANGRANDO] AUTHORIZATION [gd]')
END

--Se dropean las tablas en caso de existir
IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Usuario_Rol]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Usuario_Rol

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Usuario_Sucursal]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Usuario_Sucursal

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Usuarios]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Usuarios

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Rol_Funcionalidad]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Rol_Funcionalidad

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Pago_Factura]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Pago_Factura

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Item_Factura]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Item_Factura

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Pagos]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Pagos

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Formas_De_Pago]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Formas_De_Pago

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Devoluciones]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Devoluciones

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Facturas]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Facturas

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Rendiciones]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Rendiciones

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Roles]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Roles

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Funcionalidades]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Funcionalidades

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Sucursales]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Sucursales

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Empresas]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Empresas
IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Rubros]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Rubros

IF OBJECT_ID('[EL_JAPONES_SANGRANDO].[Clientes]','U') IS NOT NULL
DROP TABLE EL_JAPONES_SANGRANDO.Clientes


--Se crean todas las tablas
CREATE TABLE [EL_JAPONES_SANGRANDO].[Clientes](
	[cliente_DNI] [numeric](18,0) not null,
	[cliente_nombre] [nvarchar](255),
	[cliente_apellido] [nvarchar](255),
	[cliente_fecha_nacimiento] [datetime],
	[cliente_mail] [nvarchar] (255),
	[cliente_direccion] [nvarchar] (255),
	[cliente_telefono] [nvarchar] (25),
	[cliente_codigo_postal] [nvarchar] (255),
	[cliente_estado] [bit] default 1
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Facturas](
	[factura_numero] [numeric](18,0) not null,
	[factura_empresa] [nvarchar](50),
	[factura_cliente] [numeric](18,0),
	[factura_fecha] [datetime],
	[factura_fecha_vencimiento] [datetime],
	[factura_total] [numeric] (18,2),
	[factura_estado]  [tinyint] default 1,
	[factura_rendicion][numeric](18,0)


)
GO

CREATE TABLE [EL_JAPONES_SANGRANDO].[Item_Factura](
	[item_id] [numeric](18,0) not null identity,
	[item_monto] [numeric](18,2),
	[item_cantidad] [numeric](18,0),
	[item_factura] [numeric](18,0)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Empresas](
	[empresa_cuit] [nvarchar](50) not null,
	[empresa_nombre] [nvarchar](255),
	[empresa_direccion] [nvarchar](255),
	[empresa_rubro] [numeric](18,0),
	[empresa_estado] [bit] default 1
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Rubros](
	[rubro_id] [numeric](18,0) not null identity,
	[rubro_desc] [nvarchar](50)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Pagos](
	[pago_nro] [numeric](18,0) not null,
	[pago_sucursal] [numeric](18,0),
	[pago_importe] [numeric](18,2),
	[pago_formaDePago] [numeric] (18,0),
	[pago_fecha] [datetime],
	[pago_cliente] [numeric](18,0) not null
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Pago_Factura](
	[pago_Factura_factura] [numeric](18,0) not null,
	[pago_Factura_pago] [numeric](18,0) not null
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Formas_De_Pago](
	[formaDePago_id] [numeric](18,0) not null identity,
	[formaDePago_desc] [nvarchar](255)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Sucursales](
	[sucursal_codigo_postal] [numeric](18,0) not null,
	[sucursal_nombre] [nvarchar](50),
	[sucursal_direccion] [nvarchar](50),
	[sucursal_estado] [bit] default 1
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Rendiciones](
	[rendicion_nro] [numeric](18,0) not null,
	[rendicion_empresa] [nvarchar](50),
	[rendicion_importe] [numeric](18,0),
	[rendicion_porcentaje_comision] [numeric](18,0),
	[rendicion_cantfacturas] [numeric](18,0),
	[rendicion_fecha] [datetime],
	[rendicion_importeFinal] [numeric](18,2)
)

CREATE TABLE [EL_JAPONES_SANGRANDO].[Devoluciones](
	[devolucion_id] [numeric](18,0) not null identity,
	[devolucion_descripcion] [nvarchar](100),
	[devolucion_factura] [numeric](18,0)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Usuarios](
	[usuario_nombre] [nvarchar](50) not null,
	[usuario_contrasena] [varbinary](100),
	[usuario_cantidadDeIntentos] [int] default 0,
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Usuario_Sucursal](
	[usuario_Sucursal_sucursal] [numeric](18,0) not null,
	[usuario_Sucursal_usuario] [nvarchar](50) not null
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Roles](
	[rol_nombre] [nvarchar](50) not null,
	[rol_estado] [bit] default 1
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Usuario_Rol](
	[usuario_Rol_usuario] [nvarchar](50) not null,
	[usuario_Rol_rol] [nvarchar](50) not null
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Funcionalidades](
	[funcionalidad_id] [numeric](18,0) not null identity,
	[funcionalidad_descripcion] [nvarchar](100)
)
GO
CREATE TABLE [EL_JAPONES_SANGRANDO].[Rol_Funcionalidad](
	[rol_Funcionalidad_rol] [nvarchar](50) not null,
	[rol_Funcionalidad_funcionalidad] [numeric](18,0) not null
)
GO

--Se agregan todas las constraints

ALTER TABLE [EL_JAPONES_SANGRANDO].[Formas_De_Pago] 
	ADD CONSTRAINT [PK_Formas_De_Pago] PRIMARY KEY ([formaDePago_id])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Sucursales] 
	ADD CONSTRAINT [PK_Sucursal] PRIMARY KEY ([sucursal_codigo_postal])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Clientes] ADD CONSTRAINT [PK_Cliente] PRIMARY KEY ([cliente_DNI])
GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Rubros] 
	ADD CONSTRAINT [PK_Rubro] PRIMARY KEY ([rubro_id])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Empresas]
	ADD CONSTRAINT [PK_Empresa] PRIMARY KEY ([empresa_cuit]),
	CONSTRAINT [FK_empresa_Rubro] FOREIGN KEY ([empresa_rubro])
    REFERENCES [EL_JAPONES_SANGRANDO].[Rubros] ([rubro_id])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Facturas] 
	ADD CONSTRAINT [PK_Factura] PRIMARY KEY ([factura_numero]),
	CONSTRAINT [FK_factura_Cliente] FOREIGN KEY ([factura_cliente])
    REFERENCES [EL_JAPONES_SANGRANDO].[Clientes] ([cliente_DNI]),
    CONSTRAINT [FK_factura_Emp] FOREIGN KEY ([factura_empresa])
    REFERENCES [EL_JAPONES_SANGRANDO].[Empresas] ([empresa_cuit])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Item_Factura]
	ADD CONSTRAINT [PK_Item_Factura] PRIMARY KEY ([item_id]),
	CONSTRAINT [FK_Item_Fact] FOREIGN KEY (item_factura)
    REFERENCES [EL_JAPONES_SANGRANDO].[Facturas] ([factura_numero])
GO

ALTER TABLE [EL_JAPONES_SANGRANDO].[Pagos] 
	ADD CONSTRAINT [PK_Pago] PRIMARY KEY ([pago_nro]),
	CONSTRAINT [FK_pago_sucursal] FOREIGN KEY ([pago_sucursal])
    REFERENCES [EL_JAPONES_SANGRANDO].[Sucursales] ([sucursal_codigo_postal]),
    CONSTRAINT [FK_pago_formaDePago] FOREIGN KEY ([pago_formaDePago])
    REFERENCES [EL_JAPONES_SANGRANDO].[Formas_De_Pago] ([formaDePago_id]),
	CONSTRAINT [FK_Pago_Cliente] FOREIGN KEY ([pago_cliente])
    REFERENCES [EL_JAPONES_SANGRANDO].[Clientes] ([cliente_DNI])
	


GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Pago_Factura] 
	ADD CONSTRAINT [PK_Pago_Factura] PRIMARY KEY ([pago_Factura_pago], [pago_Factura_factura]),
	CONSTRAINT [FK_Pago_Factura_Fact] FOREIGN KEY ([pago_Factura_factura])
    REFERENCES [EL_JAPONES_SANGRANDO].[Facturas] ([factura_numero]),
    CONSTRAINT [FK_Pago_Factura_Pago] FOREIGN KEY ([pago_Factura_pago])
    REFERENCES [EL_JAPONES_SANGRANDO].[Pagos] ([pago_nro])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Rendiciones] 
	ADD CONSTRAINT [PK_Rendicion] PRIMARY KEY ([rendicion_nro]),
	CONSTRAINT [FK_rendicion_Emp] FOREIGN KEY ([rendicion_empresa])
    REFERENCES [EL_JAPONES_SANGRANDO].[Empresas] ([empresa_cuit])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Devoluciones] 
	ADD CONSTRAINT [PK_Devolucion] PRIMARY KEY ([devolucion_id]),
	CONSTRAINT [FK_devolucion_factura] FOREIGN KEY ([devolucion_factura])
    REFERENCES [EL_JAPONES_SANGRANDO].[Facturas] ([factura_numero])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Usuarios] 
	ADD CONSTRAINT [PK_Usuario] PRIMARY KEY ([usuario_nombre])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Usuario_Sucursal] 
	ADD CONSTRAINT [PK_Usuario_Sucursal] PRIMARY KEY ([usuario_Sucursal_usuario], [usuario_Sucursal_sucursal]),
	CONSTRAINT [FK_usuario_Sucursal_usuario] FOREIGN KEY ([usuario_Sucursal_usuario])
    REFERENCES [EL_JAPONES_SANGRANDO].[Usuarios] ([usuario_nombre]),
    CONSTRAINT [FK_usuario_Sucursal_sucursal] FOREIGN KEY ([usuario_Sucursal_sucursal])
    REFERENCES [EL_JAPONES_SANGRANDO].[Sucursales] ([sucursal_codigo_postal])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Roles] 
	ADD CONSTRAINT [PK_Rol] PRIMARY KEY ([rol_nombre])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Usuario_Rol] 
	ADD CONSTRAINT [PK_Usuario_Rol] PRIMARY KEY ([usuario_Rol_rol], [usuario_Rol_usuario]),
	CONSTRAINT [FK_usuario_Rol_Rol] FOREIGN KEY ([usuario_Rol_rol])
    REFERENCES [EL_JAPONES_SANGRANDO].[Roles] ([rol_nombre]),
    CONSTRAINT [FK_usuario_Rol_usuario] FOREIGN KEY ([usuario_Rol_usuario])
    REFERENCES [EL_JAPONES_SANGRANDO].[Usuarios] ([usuario_nombre])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Funcionalidades] 
	ADD CONSTRAINT [PK_Funcionalidad] PRIMARY KEY ([funcionalidad_id])

GO
ALTER TABLE [EL_JAPONES_SANGRANDO].[Rol_Funcionalidad]
	ADD CONSTRAINT [PK_RolFuncionalidad] PRIMARY KEY ([rol_Funcionalidad_funcionalidad], rol_Funcionalidad_rol),
	CONSTRAINT [FK_Rolfuncionalidad_Rol] FOREIGN KEY ([rol_Funcionalidad_rol])
    REFERENCES [EL_JAPONES_SANGRANDO].[Roles] ([rol_nombre]),
    CONSTRAINT [FK_Rolfuncionalidad_Func] FOREIGN KEY ([rol_Funcionalidad_funcionalidad])
    REFERENCES [EL_JAPONES_SANGRANDO].[Funcionalidades] ([funcionalidad_id])

GO

--Comienza la migracion

--MIGRACION DE CLIENTES
INSERT INTO EL_JAPONES_SANGRANDO.Clientes (cliente_DNI, cliente_apellido, cliente_nombre, cliente_fecha_nacimiento, cliente_mail, cliente_direccion, cliente_codigo_postal)
SELECT DISTINCT [Cliente-Dni], [Cliente-Apellido], [Cliente-Nombre], [Cliente-Fecha_Nac], Cliente_Mail, Cliente_Direccion, Cliente_Codigo_Postal from gd_esquema.Maestra
--MIGRACION DE RUBROS
SET IDENTITY_INSERT EL_JAPONES_SANGRANDO.Rubros ON
INSERT INTO EL_JAPONES_SANGRANDO.Rubros (rubro_id, rubro_desc)
SELECT DISTINCT Empresa_Rubro, Rubro_Descripcion from gd_esquema.Maestra
SET IDENTITY_INSERT EL_JAPONES_SANGRANDO.Rubros OFF
--MIGRACION DE EMPRESAS
INSERT INTO EL_JAPONES_SANGRANDO.Empresas(empresa_cuit, empresa_nombre, empresa_direccion, empresa_rubro)
SELECT DISTINCT empresa_cuit, Empresa_Nombre, Empresa_Direccion, Empresa_Rubro from gd_esquema.Maestra ORDER BY empresa_cuit
--MIGRACION DE FACTURAS
INSERT INTO EL_JAPONES_SANGRANDO.Facturas (factura_numero, factura_empresa, factura_cliente, factura_fecha, factura_fecha_vencimiento, factura_total)
SELECT DISTINCT Nro_Factura, empresa_cuit, [Cliente-DNI], Factura_Fecha, Factura_Fecha_Vencimiento, Factura_Total from gd_esquema.Maestra M
join EL_JAPONES_SANGRANDO.Clientes C on C.cliente_DNI = M.[Cliente-Dni] order by Nro_Factura
--MIGRACION DE ITEMS FACTURAS
INSERT INTO EL_JAPONES_SANGRANDO.Item_Factura (item_monto, item_cantidad, item_factura)
SELECT DISTINCT ItemFactura_Cantidad, ItemFactura_Monto, Nro_Factura FROM gd_esquema.Maestra ORDER BY Nro_Factura
--MIGRACION DE MEDIOS DE PAGO
INSERT INTO EL_JAPONES_SANGRANDO.Formas_De_Pago (formaDePago_desc)
SELECT DISTINCT FormaPagoDescripcion FROM gd_esquema.Maestra WHERE FormaPagoDescripcion IS NOT NULL
--MIGRACION DE SUCURSALES
INSERT INTO EL_JAPONES_SANGRANDO.Sucursales (sucursal_codigo_postal, sucursal_nombre, sucursal_direccion)
SELECT DISTINCT Sucursal_Codigo_Postal, Sucursal_Nombre, Sucursal_Direcci�n FROM gd_esquema.Maestra
WHERE Sucursal_Codigo_Postal IS NOT NULL


--MIGRACION DE PAGOS

INSERT INTO EL_JAPONES_SANGRANDO.Pagos (pago_nro, pago_sucursal, pago_importe, pago_formaDePago, pago_fecha,pago_cliente)
SELECT DISTINCT Pago_nro, Sucursal_Codigo_Postal, Factura_Total, (SELECT formaDePago_id FROM EL_JAPONES_SANGRANDO.Formas_De_Pago WHERE formaDePago_desc = FormaPagoDescripcion), Pago_Fecha,[Cliente-Dni] FROM gd_esquema.Maestra
WHERE Pago_nro IS NOT NULL
ORDER BY Pago_nro


--MIGRACION DE PAGOSFACTURAS
INSERT INTO EL_JAPONES_SANGRANDO.Pago_Factura (pago_Factura_factura, pago_Factura_pago)
SELECT DISTINCT Nro_Factura, M.Pago_nro FROM gd_esquema.Maestra M
WHERE M.Pago_nro IS NOT NULL
ORDER BY M.Pago_nro
UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = 2 WHERE factura_numero IN (SELECT pago_Factura_factura FROM EL_JAPONES_SANGRANDO.Pago_Factura)

--MIGRACION DE RENDICIONES
INSERT INTO EL_JAPONES_SANGRANDO.Rendiciones (rendicion_nro, rendicion_empresa, rendicion_porcentaje_comision, rendicion_fecha)
 SELECT DISTINCT Rendicion_Nro, (SELECT empresa_cuit FROM EL_JAPONES_SANGRANDO.Empresas WHERE empresa_nombre = Empresa_Nombre), ItemRendicion_Importe*100/Total, Rendicion_Fecha from gd_esquema.Maestra
 WHERE Rendicion_Nro IS NOT NULL order by Rendicion_Nro

 ALTER TABLE [EL_JAPONES_SANGRANDO].[Facturas] 
	ADD CONSTRAINT [FK_factura_rendicion] FOREIGN KEY ([factura_rendicion])
	REFERENCES [EL_JAPONES_SANGRANDO].[Rendiciones] ([rendicion_nro])
GO


--Setteo el numero de rendicion de las facturas
 UPDATE EL_JAPONES_SANGRANDO.Facturas 
SET factura_rendicion = (select distinct Rendicion_Nro 
				FROM gd_esquema.Maestra 
			WHERE Nro_Factura = factura_numero and Rendicion_Nro is not null)

--Setteo el estado de las facturas rendidas
UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = 3 WHERE factura_rendicion is not null

--Setteo el importe de las rendiciones
UPDATE  EL_JAPONES_SANGRANDO.Rendiciones 
SET rendicion_importe = (SELECT sum(factura_total) 
						FROM EL_JAPONES_SANGRANDO.Facturas
						WHERE  factura_rendicion= rendicion_nro)
--Setteo el importe final de las rendiciones
UPDATE EL_JAPONES_SANGRANDO.Rendiciones
SET rendicion_importeFinal = rendicion_importe - rendicion_importe * rendicion_porcentaje_comision /100 ;
GO

--Setteo la cantidad de facturas de las rendiciones
UPDATE EL_JAPONES_SANGRANDO.Rendiciones
SET rendicion_cantfacturas = (SELECT count(factura_numero)
						FROM EL_JAPONES_SANGRANDO.Facturas
						WHERE factura_rendicion = rendicion_nro)
GO


---INSERTS PARA EL FUNCIONAMIENTO DEL PROGRAMA

--Insertar roles
INSERT INTO EL_JAPONES_SANGRANDO.Roles (rol_nombre) values('administrador')
INSERT INTO EL_JAPONES_SANGRANDO.Roles (rol_nombre) values('cobrador')


-- CREACION USUARIO ADMIN
INSERT INTO EL_JAPONES_SANGRANDO.Usuarios (usuario_nombre, usuario_contrasena) values('admin',HASHBYTES('SHA2_256', 'w23e'))

INSERT INTO EL_JAPONES_SANGRANDO.Usuarios (usuario_nombre, usuario_contrasena) values('cobrador',HASHBYTES('SHA2_256', 'w23e'))

--
INSERT INTO EL_JAPONES_SANGRANDO.Funcionalidades(funcionalidad_descripcion)
values('ABM_ROL'),('ABM_CLIENTE'),('ABM_EMPRESA'),('ABM_SUCURSAL'),('ABM_FACTURA'),('REGISTRO_DE_PAGO_DE_FACTURAS'),('LISTADO_ESTADISTICO'),('RENDICION_DE_FACTURAS_COBRADAS'),('DEVOLUCION')

--Vinculo los roles con la funcionalidades que tienen
INSERT INTO EL_JAPONES_SANGRANDO.Rol_Funcionalidad(rol_Funcionalidad_rol, rol_Funcionalidad_funcionalidad)
values('administrador',1),('administrador',2),('administrador',3),('administrador',4),('administrador',5),('administrador',6),('administrador',7),('administrador',8),('administrador',9)

--Le asigno el perfil de administrador al admin
INSERT INTO EL_JAPONES_SANGRANDO.Usuario_Rol(usuario_Rol_usuario, usuario_Rol_rol) values ('admin', 'administrador')


INSERT INTO EL_JAPONES_SANGRANDO.Sucursales (sucursal_codigo_postal,sucursal_direccion,sucursal_nombre)
values (1447,'Medrano 1700','SUCURSAL N 3000')

INSERT INTO EL_JAPONES_SANGRANDO.Sucursales (sucursal_codigo_postal,sucursal_direccion,sucursal_nombre)
values (1437,'Medrano 18550','SUCURSAL N 5000')

INSERT INTO EL_JAPONES_SANGRANDO.Usuario_Sucursal (usuario_Sucursal_sucursal,usuario_Sucursal_usuario)
values (1447,'cobrador')
INSERT INTO EL_JAPONES_SANGRANDO.Usuario_Sucursal (usuario_Sucursal_sucursal,usuario_Sucursal_usuario)
values (1437,'cobrador')

INSERT INTO EL_JAPONES_SANGRANDO.Usuario_Rol(usuario_Rol_usuario, usuario_Rol_rol) values ('cobrador', 'cobrador')