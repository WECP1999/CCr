/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases V10.0.2                    */
/* Target DBMS:           MS SQL Server 2012                              */
/* Project file:          BDDPOO.dez                                      */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Database creation script                        */
/* Created on:            2019-09-23 17:53                                */
/* ---------------------------------------------------------------------- */


/* ------------------------------------a---------------------------------- */
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
    [precio] DECIMAL(18,2) NOT NULL,
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
    [porcentaje] DECIMAL(4,2) NOT NULL,
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
    [estado] BIT NOT NULL,
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
    CONSTRAINT [PK_Capacitaciones] PRIMARY KEY ([id])
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
    [nota] DECIMAL(4,2) NOT NULL,
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


/*------------------------------------*/
/*--		   CONSTRAINTS			--*/
/*------------------------------------*/

--Numeros Telefonos
ALTER TABLE NumerosTelefonos
ADD CONSTRAINT CK_numero_empresa
CHECK (numero NOT LIKE '%[A-Z]%' AND numero NOT LIKE '%[a-z]%')


--Empresas
ALTER TABLE Empresas
ADD CONSTRAINT CK_CantidadEmpleado
CHECK (cantidad_empleado NOT LIKE '%[a-z]%' AND cantidad_empleado NOT LIKE '%[A-Z]%')

ALTER TABLE Empresas
ADD CONSTRAINT U_direccion
UNIQUE (direccion)

--Tipos_Usuarios
ALTER TABLE Tipos_Usuarios
ADD CONSTRAINT CK_descripcion
CHECK (descripcion LIKE 'Capacitador' OR descripcion LIKE 'Asesor' OR descripcion LIKE 'Administrador')

--Usuarios 
ALTER TABLE Usuarios
ADD CONSTRAINT CK_estado
CHECK (estado LIKE 1 OR estado LIKE 0) --1 es activo y 0 es inactivo

--Capacitaciones
ALTER TABLE Capacitaciones
ADD CONSTRAINT CK_fecha_inicio
CHECK(fecha_inicio < fecha_fin)

--Temas
ALTER TABLE Temas
ADD CONSTRAINT CK_precio
CHECK (Precio > 0)

--Telefonos
ALTER TABLE Telefonos
ADD CONSTRAINT CK_numero_participante
CHECK (numero NOT LIKE '%[A-Z]%' AND numero NOT LIKE '%[a-z]%')

--Participantes
ALTER TABLE Participantes
ADD CONSTRAINT CK_dui
CHECK (dui LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]')

ALTER TABLE Participantes
ADD CONSTRAINT U_dui
UNIQUE (dui)

--Pagos
ALTER TABLE Pagos
ADD CONSTRAINT CK_pago
CHECK (pago >= 0)

ALTER TABLE Pagos
ADD CONSTRAINT CK_fecha_pago
CHECK (fecha_pago >= getdate())

--Detalle Participantes Capacitaciones - NO se toca porque todas son FK

--Tipos Notas
ALTER TABLE TiposNotas
ADD CONSTRAINT CK_porcentaje
CHECK (porcentaje > 0)

ALTER TABLE TiposNotas --Porcentaje en base a 100%
ADD CONSTRAINT CK_porcentaje_unicos
CHECK (porcentaje = 10 OR porcentaje = 20 OR porcentaje = 40 OR porcentaje = 30) --La empresa solo trabaja con 4 porcentajes

ALTER TABLE TiposNotas
ADD CONSTRAINT CK_descripcion_unicos
CHECK (descripcion LIKE 'Asistencia' OR descripcion LIKE 'Participacion' OR descripcion LIKE 'Actividad' OR descripcion LIKE 'Examen') --La empresa solo tiene 4 actividades con los mismos porcentajes

--Notas
ALTER TABLE Notas
ADD CONSTRAINT CK_nota
CHECK (nota >= 0)


/*------------------------------------*/
/*--			  INSERTS			--*/
/*------------------------------------*/

INSERT INTO Empresas VALUES ('Libre', 0, '------')
go

--Solo tres tipos de usuarios trabajaran con el programa 
INSERT INTO Tipos_Usuarios VALUES ('Administrador')
INSERT INTO Tipos_Usuarios VALUES ('Asesor')
INSERT INTO Tipos_Usuarios VALUES ('Capacitador')

INSERT INTO Usuarios(nombre_usuario,password,estado,id_tipo_usuario) VALUES ('admin', '0e80221a93e87a39e7a564048dd5c3b5e422d40ea266d8c006585b8b0d33ad60', 1, 1)
go

select * from Empresas
select * from Usuarios

INSERT INTO Temas (descripcion,precio) VALUES
('Curso Basico de Primeros Auxilios',56.75),
('Capacitacion elemental de evacuacion',76.54)

select * from Temas

INSERT INTO Usuarios(nombre_usuario,password,estado,id_tipo_usuario) VALUES
('Brenda Hidalgo', '123', '1','1'),
('Vanesa Cruz', '321', '1','2'),
('Mario Neta','000','1','3'),
('Leo Calvas', '111','0','2')

DELETE FROM Usuarios WHERE nombre_usuario = 'Leo Calvas'

select * from Usuarios

INSERT INTO Capacitadores(nombre,apellido,id_usuario) VALUES
('Mario','Neta','4'),
('Brenda','Hidalgo','2')

INSERT INTO Empresas (nombre_empresa,cantidad_empleado,direccion) VALUES
('Concentrix','180','Alameda Roosevelt, San Salvador'),
('Toei Animations','300','Casa de Goku')

UPDATE Empresas SET direccion = 'Kamehouse'
WHERE nombre_empresa = 'Toei Animations'

select * from Empresas
select * from Capacitadores

INSERT INTO Capacitaciones(fecha_inicio,fecha_fin,id_empresa,id_capacitador,id_tema) VALUES
('2019/09/30 13:30:40','2019/10/1 14:50:50',3,1,2),
('2017/08/25 09:30:00','2018/10/16 12:30:00',2,2,1)

INSERT INTO Participantes (nombre,apellido,dui,correo) VALUES
('Gerardo','Velasquez','12345678-9','gerardo.jose2011@yahoo.es'),
('Natasha','Romanoff','74568978-9','romanof15@gmail.com') 

INSERT INTO TiposNotas (id,porcentaje, descripcion) VALUES --Solo existen 4 actividades y siempre con los mismos porcentajes
(1,10,'Asistencia'),
(2,20, 'Participacion'),
(3,40, 'Actividad'),
(4,30, 'Examen')

INSERT INTO DetallesParticipantesCapacitaciones(id_participante,id_capacitacion) VALUES
(1,1),
(2,2)

select * from Capacitaciones
select* from DetallesParticipantesCapacitaciones

INSERT INTO Notas (nota,id_detalle_participante_capacitacion,id_tipo_nota) VALUES
(10,1,1), --Llenado de notas para participante 1
(8.00,1,2),
(9.00,1,3),
(6.94,1,4),
(5.00,2,1), --Llenado de notas para participante 2
(7.00,2,2),
(3.00,2,3),
(9.80,2,4)

select * from Notas

--Busqueda de todos los valores necesarios para mostrar resultados de la capacitacion
SELECT TEM.descripcion, EMP.nombre_empresa, EMP.direccion, CAPN.fecha_inicio, CAPN.fecha_fin, CAPR.nombre as [cap-nombre], CAPR.apellido as [cap-apellido],  PAR.nombre, PAR.apellido, N.nota,(NT.porcentaje/100) as [porcentaje total], (N.nota*(NT.porcentaje/100)) as [Resultado]
FROM Empresas EMP
RIGHT JOIN Capacitaciones CAPN
ON EMP.id = CAPN.id_empresa
RIGHT JOIN Capacitadores CAPR
ON CAPN.id_capacitador = CAPR.id
RIGHT JOIN Temas TEM
ON CAPN.id_tema = TEM.id
INNER JOIN DetallesParticipantesCapacitaciones DPC
ON DPC.id_capacitacion = CAPN.id
RIGHT JOIN Participantes PAR
ON DPC.id_participante = PAR.id
LEFT JOIN Notas N
ON N.id_detalle_participante_capacitacion = DPC.id 
RIGHT JOIN TiposNotas NT
ON N.id_tipo_nota = NT.id
ORDER BY PAR.nombre

SELECT * FROM Usuarios
select * from Empresas
select * from Capacitadores
select * from Temas
select * from Capacitaciones
select * from Participantes
select * from TiposNotas
select * from DetallesParticipantesCapacitaciones
select * , (porcentaje/100) as [%] from TiposNotas