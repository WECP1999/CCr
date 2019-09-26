/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases V10.0.2                    */
/* Target DBMS:           MS SQL Server 2012                              */
/* Project file:          BDDPOO.dez                                      */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Database creation script                        */
/* Created on:            2019-09-23 17:53                                */
/* ---------------------------------------------------------------------- */


/* ---------------------------------------------------------------------- */
/* Add tables                                                             */
/* ---------------------------------------------------------------------- */
USE MASTER 
GO
CREATE DATABASE BDDCRr
GO

USE BDDCRr
/* ---------------------------------------------------------------------- */
/* Add table "Temas"                                                       */
/* ---------------------------------------------------------------------- */
GO


CREATE TABLE [Temas] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [descripcion] VARCHAR(100) NOT NULL,
    [precio] DECIMAL NOT NULL,
    CONSTRAINT [PK_Temas] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Participantes"                                               */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Participantes] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR(100) NOT NULL,
    [apellido] VARCHAR(100) NOT NULL,
    [dui] VARCHAR(10),
    [correo] VARCHAR(150),
    CONSTRAINT [PK_Participantes] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Tiposnotas"                                                  */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [TiposNotas] (
    [id] INTEGER NOT NULL,
    [porcentaje] DECIMAL NOT NULL,
    [descripcion] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Tipos_Notas] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "TiposUsuarios"                                               */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Tipos_Usuarios] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [descripcion] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_TiposUsuario] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "NumerosTelefonos"                                            */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [NumerosTelefonos] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [numero] VARCHAR(20) NOT NULL,
    [extension] VARCHAR(10) NOT NULL,
    CONSTRAINT [PK_NumerosTelefonos] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Empresa"                                                    */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Empresas] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre_empresa] VARCHAR(100) NOT NULL,
    [cantidad_empleado] VARCHAR(100) NOT NULL,
    [direccion] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Empresas] PRIMARY KEY ([id])
)
GO

/* ---------------------------------------------------------------------- */
/* Add table "Telefonos"                                                  */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Telefonos] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [numero] VARCHAR(10),
    [extension] VARCHAR(40),
    [id_participante] INTEGER NOT NULL,
    CONSTRAINT [PK_Telefonos] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Usuarios"                                                    */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Usuarios] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre_usuario] VARCHAR(100) NOT NULL,
    [password] VARCHAR(256) NOT NULL,
    [estado] BINARY NOT NULL,
    [id_tipo_usuario] INTEGER NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Contactos"                                                   */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Contactos] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [descripcion] VARCHAR(100),
    [id_numero_telefono] INTEGER NOT NULL,
    [id_empresa] INTEGER NOT NULL,
    CONSTRAINT [PK_Contactos] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Capacitadores"                                                */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Capacitadores] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR(100) NOT NULL,
    [apellido] VARCHAR(100) NOT NULL,
    [id_usuario] INTEGER NOT NULL,
    CONSTRAINT [PK_Capacitadores] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Capacitaciones"                                               */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Capacitaciones] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [fecha_inicio] DATETIME NOT NULL,
    [fecha_fin] DATETIME NOT NULL,
    [id_empresa] INTEGER NOT NULL,
    [id_capacitador] INTEGER NOT NULL,
    [id_tema] INTEGER NOT NULL,
	[id_tipo_capacitacion] INTEGER NOT NULL,
    CONSTRAINT [PK_Capacitaciones] PRIMARY KEY ([id])
)
GO

/* ---------------------------------------------------------------------- */
/* Add table "TiposCapacitaciones"                                               */
/* ---------------------------------------------------------------------- */

GO

CREATE TABLE [TipoCapacitaciones] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [tipo_capacitacion] VARCHAR NOT NULL,
    CONSTRAINT [PK_Tipo_Capacitaciones] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Pagos"                                                       */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Pagos] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [fecha_pago] DATETIME NOT NULL,
    [pago] MONEY NOT NULL,
    [id_capacitacion] INTEGER NOT NULL,
    CONSTRAINT [PK_Pagos] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Correo"                                                     */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Correos] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [correo] VARCHAR(100) NOT NULL,
    [id_empresa] INTEGER,
    CONSTRAINT [PK_Correos] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Detalle_Participante_Capacitacion"                          */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [DetallesParticipantesCapacitaciones] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [id_participante] INTEGER NOT NULL,
    [id_capacitacion] INTEGER NOT NULL,
    CONSTRAINT [PK_DetallesParticipantesCapacitaciones] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Nota"                                                       */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Notas] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nota] DECIMAL NOT NULL,
    [id_detalle_participante_capacitacion] INTEGER NOT NULL,
    [id_tipo_nota] INTEGER NOT NULL,
    CONSTRAINT [PK_Notas] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add foreign key constraints                                            */
/* ---------------------------------------------------------------------- */

GO


ALTER TABLE [Usuarios] ADD CONSTRAINT [tipos_usuario_Usuarios] 
    FOREIGN KEY ([id_tipo_usuario]) REFERENCES [Tipos_Usuarios] ([id])
GO


ALTER TABLE [Notas] ADD CONSTRAINT [tipos_nota_Notas] 
    FOREIGN KEY ([id_tipo_nota]) REFERENCES [TiposNotas] ([id])
GO


ALTER TABLE [Notas] ADD CONSTRAINT [Detalles_Participantes_Capacitaciones_Notas] 
    FOREIGN KEY ([id_detalle_participante_capacitacion]) REFERENCES [DetallesParticipantesCapacitaciones] ([id])
GO


ALTER TABLE [Contactos] ADD CONSTRAINT [Numeros_Telefonos_Contactos] 
    FOREIGN KEY ([id_numero_telefono]) REFERENCES [NumerosTelefonos] ([id])
GO


ALTER TABLE [Contactos] ADD CONSTRAINT [Empresas_Contactos] 
    FOREIGN KEY ([id_empresa]) REFERENCES [Empresas] ([id])
GO


ALTER TABLE [DetallesParticipantesCapacitaciones] ADD CONSTRAINT [ParticipantesDetallesParticipantesCapacitaciones] 
    FOREIGN KEY ([id_participante]) REFERENCES [Participantes] ([id])
GO


ALTER TABLE [DetallesParticipantesCapacitaciones] ADD CONSTRAINT [CapacitacionesDetallesParticipantesCapacitaciones] 
    FOREIGN KEY ([id_capacitacion]) REFERENCES [Capacitaciones] ([id])
GO


ALTER TABLE [Capacitadores] ADD CONSTRAINT [Usuarios_Capacitadores] 
    FOREIGN KEY ([id_usuario]) REFERENCES [Usuarios] ([id])
GO


ALTER TABLE [Capacitaciones] ADD CONSTRAINT [Temas_Capacitaciones] 
    FOREIGN KEY ([id_tema]) REFERENCES [Temas] ([id])
GO


ALTER TABLE [Capacitaciones] ADD CONSTRAINT [Capacitadores_Capacitaciones] 
    FOREIGN KEY ([id_capacitador]) REFERENCES [Capacitadores] ([id])
GO


ALTER TABLE [Capacitaciones] ADD CONSTRAINT [Empresas_Capacitaciones] 
    FOREIGN KEY ([id_empresa]) REFERENCES [Empresas] ([id])
GO


ALTER TABLE [Pagos] ADD CONSTRAINT [Capacitaciones_Pagos] 
    FOREIGN KEY ([id_capacitacion]) REFERENCES [Capacitaciones] ([id])
GO


ALTER TABLE [Correos] ADD CONSTRAINT [Empresa_Correos] 
    FOREIGN KEY ([id_empresa]) REFERENCES [Empresas] ([id])
GO

ALTER TABLE [Telefonos] ADD CONSTRAINT [Participantes_Telefonos]
	FOREIGN KEY ([id_participante]) REFERENCES [Participantes] ([id])
GO

ALTER TABLE [Capacitaciones] ADD CONSTRAINT [Capacitaicones_TipoCapacitaciones]
	FOREIGN KEY ([id_tipo_capacitacion]) REFERENCES [TipoCapacitaciones] ([id])
GO
