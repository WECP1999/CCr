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
/* Add table "Tema"                                                       */
/* ---------------------------------------------------------------------- */
GO


CREATE TABLE [Tema] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [descripcion] VARCHAR(100) NOT NULL,
    [precio] DECIMAL NOT NULL,
    CONSTRAINT [PK_Tema] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Participante"                                               */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Participante] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR(100) NOT NULL,
    [apellido] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Participante] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Tipo_nota"                                                  */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Tipo_nota] (
    [id] INTEGER NOT NULL,
    [porcentaje] DECIMAL NOT NULL,
    [descripcion] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Tipo_nota] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Tipo_usuario"                                               */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Tipo_usuario] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [descripcion] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Tipo_usuario] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Numero_telefono"                                            */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Numero_telefono] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [numero] VARCHAR(20) NOT NULL,
    [extencion] VARCHAR(10) NOT NULL,
    CONSTRAINT [PK_Numero_telefono] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Empresa"                                                    */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Empresa] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre_empresa] VARCHAR(100) NOT NULL,
    [cantidad_empleado] VARCHAR(100) NOT NULL,
    [direccion] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Empresa] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Participante_individual"                                    */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Participante_individual] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR(100) NOT NULL,
    [apellido] VARCHAR(100) NOT NULL,
    [dui] VARCHAR(10),
    [correo] VARCHAR(150) NOT NULL,
    PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Telefeono"                                                  */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Telefeono] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [numero] VARCHAR(10),
    [extencion] VARCHAR(40),
    [id_participante_individual] INTEGER NOT NULL,
    CONSTRAINT [PK_Telefeono] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Usuario"                                                    */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Usuario] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre_usuario] VARCHAR(100) NOT NULL,
    [password] VARCHAR(256) NOT NULL,
    [estado] BINARY NOT NULL,
    [id_tipo_usuario] INTEGER NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Contacto"                                                   */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Contacto] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [descripcion] VARCHAR(100),
    [id_numero_telefono] INTEGER NOT NULL,
    [id_empresa] INTEGER NOT NULL,
    CONSTRAINT [PK_Contacto] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Capacitador"                                                */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Capacitador] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR(100) NOT NULL,
    [apellido] VARCHAR(100) NOT NULL,
    [id_usuario] INTEGER NOT NULL,
    CONSTRAINT [PK_Capacitador] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Capacitacion"                                               */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Capacitacion] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [fecha_inicio] DATETIME NOT NULL,
    [fecha_fin] DATETIME NOT NULL,
    [id_empresa] INTEGER NOT NULL,
    [id_capacitador] INTEGER NOT NULL,
    [id_tema] INTEGER NOT NULL,
    CONSTRAINT [PK_Capacitacion] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Pago"                                                       */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Pago] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [fecha_pago] DATETIME NOT NULL,
    [pago] MONEY NOT NULL,
    [id_capacitacion] INTEGER NOT NULL,
    CONSTRAINT [PK_Pago] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Correo"                                                     */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Correo] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [correo] VARCHAR(100) NOT NULL,
    [id_empresa] INTEGER,
    CONSTRAINT [PK_Correo] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Capacitacion_libre"                                         */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Capacitacion_libre] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [fecha_inicio] DATETIME NOT NULL,
    [fecha_fin] DATETIME NOT NULL,
    [id_tema] INTEGER NOT NULL,
    [id_capacitador] INTEGER NOT NULL,
    [id_participante_civil] INTEGER NOT NULL,
    CONSTRAINT [PK_Capacitacion_libre] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Detalle_Participante_Capacitacion"                          */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Detalle_Participante_Capacitacion] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [id_participante] INTEGER NOT NULL,
    [id_capacitacion] INTEGER NOT NULL,
    CONSTRAINT [PK_Detalle_Participante_Capacitacion] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Nota"                                                       */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Nota] (
    [id] INTEGER IDENTITY(1,1) NOT NULL,
    [nota] DECIMAL NOT NULL,
    [porcentaje] DECIMAL NOT NULL,
    [id_detalle_participante_capacitacion] INTEGER NOT NULL,
    [id_tipo_nota] INTEGER NOT NULL,
    CONSTRAINT [PK_Nota] PRIMARY KEY ([id])
)
GO


/* ---------------------------------------------------------------------- */
/* Add foreign key constraints                                            */
/* ---------------------------------------------------------------------- */

GO


ALTER TABLE [Usuario] ADD CONSTRAINT [Tipo_usuario_Usuario] 
    FOREIGN KEY ([id_tipo_usuario]) REFERENCES [Tipo_usuario] ([id])
GO


ALTER TABLE [Nota] ADD CONSTRAINT [Tipo_nota_Nota] 
    FOREIGN KEY ([id_tipo_nota]) REFERENCES [Tipo_nota] ([id])
GO


ALTER TABLE [Nota] ADD CONSTRAINT [Detalle_Participante_Capacitacion_Nota] 
    FOREIGN KEY ([id_detalle_participante_capacitacion]) REFERENCES [Detalle_Participante_Capacitacion] ([id])
GO


ALTER TABLE [Contacto] ADD CONSTRAINT [Numero_telefono_Contacto] 
    FOREIGN KEY ([id_numero_telefono]) REFERENCES [Numero_telefono] ([id])
GO


ALTER TABLE [Contacto] ADD CONSTRAINT [Empresa_Contacto] 
    FOREIGN KEY ([id_empresa]) REFERENCES [Empresa] ([id])
GO


ALTER TABLE [Detalle_Participante_Capacitacion] ADD CONSTRAINT [Participante_Detalle_Participante_Capacitacion] 
    FOREIGN KEY ([id_participante]) REFERENCES [Participante] ([id])
GO


ALTER TABLE [Detalle_Participante_Capacitacion] ADD CONSTRAINT [Capacitacion_Detalle_Participante_Capacitacion] 
    FOREIGN KEY ([id_capacitacion]) REFERENCES [Capacitacion] ([id])
GO


ALTER TABLE [Capacitador] ADD CONSTRAINT [Usuario_Capacitador] 
    FOREIGN KEY ([id_usuario]) REFERENCES [Usuario] ([id])
GO


ALTER TABLE [Capacitacion] ADD CONSTRAINT [Tema_Capacitacion] 
    FOREIGN KEY ([id_tema]) REFERENCES [Tema] ([id])
GO


ALTER TABLE [Capacitacion] ADD CONSTRAINT [Capacitador_Capacitacion] 
    FOREIGN KEY ([id_capacitador]) REFERENCES [Capacitador] ([id])
GO


ALTER TABLE [Capacitacion] ADD CONSTRAINT [Empresa_Capacitacion] 
    FOREIGN KEY ([id_empresa]) REFERENCES [Empresa] ([id])
GO


ALTER TABLE [Pago] ADD CONSTRAINT [Capacitacion_Pago] 
    FOREIGN KEY ([id_capacitacion]) REFERENCES [Capacitacion] ([id])
GO


ALTER TABLE [Correo] ADD CONSTRAINT [Empresa_Correo] 
    FOREIGN KEY ([id_empresa]) REFERENCES [Empresa] ([id])
GO


ALTER TABLE [Capacitacion_libre] ADD CONSTRAINT [Capacitador_Capacitacion_libre] 
    FOREIGN KEY ([id_capacitador]) REFERENCES [Capacitador] ([id])
GO


ALTER TABLE [Capacitacion_libre] ADD CONSTRAINT [Tema_Capacitacion_libre] 
    FOREIGN KEY ([id_tema]) REFERENCES [Tema] ([id])
GO


ALTER TABLE [Capacitacion_libre] ADD CONSTRAINT [Participante_individual_Capacitacion_libre] 
    FOREIGN KEY ([id_participante_civil]) REFERENCES [Participante_individual] ([id])
GO


ALTER TABLE [Telefeono] ADD CONSTRAINT [Participante_individual_Telefeono] 
    FOREIGN KEY ([id_participante_individual]) REFERENCES [Participante_individual] ([id])
GO

