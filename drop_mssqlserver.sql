/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases V10.0.2                    */
/* Target DBMS:           MS SQL Server 2012                              */
/* Project file:          BDDPOO.dez                                      */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Database drop script                            */
/* Created on:            2019-09-23 17:53                                */
/* ---------------------------------------------------------------------- */


/* ---------------------------------------------------------------------- */
/* Drop foreign key constraints                                           */
/* ---------------------------------------------------------------------- */

GO


ALTER TABLE [Usuario] DROP CONSTRAINT [Tipo_usuario_Usuario]
GO


ALTER TABLE [Nota] DROP CONSTRAINT [Tipo_nota_Nota]
GO


ALTER TABLE [Nota] DROP CONSTRAINT [Detalle_Participante_Capacitacion_Nota]
GO


ALTER TABLE [Contacto] DROP CONSTRAINT [Numero_telefono_Contacto]
GO


ALTER TABLE [Contacto] DROP CONSTRAINT [Empresa_Contacto]
GO


ALTER TABLE [Detalle_Participante_Capacitacion] DROP CONSTRAINT [Participante_Detalle_Participante_Capacitacion]
GO


ALTER TABLE [Detalle_Participante_Capacitacion] DROP CONSTRAINT [Capacitacion_Detalle_Participante_Capacitacion]
GO


ALTER TABLE [Capacitador] DROP CONSTRAINT [Usuario_Capacitador]
GO


ALTER TABLE [Capacitacion] DROP CONSTRAINT [Tema_Capacitacion]
GO


ALTER TABLE [Capacitacion] DROP CONSTRAINT [Capacitador_Capacitacion]
GO


ALTER TABLE [Capacitacion] DROP CONSTRAINT [Empresa_Capacitacion]
GO


ALTER TABLE [Pago] DROP CONSTRAINT [Capacitacion_Pago]
GO


ALTER TABLE [Correo] DROP CONSTRAINT [Empresa_Correo]
GO


ALTER TABLE [Capacitacion_libre] DROP CONSTRAINT [Capacitador_Capacitacion_libre]
GO


ALTER TABLE [Capacitacion_libre] DROP CONSTRAINT [Tema_Capacitacion_libre]
GO


ALTER TABLE [Capacitacion_libre] DROP CONSTRAINT [Participante_individual_Capacitacion_libre]
GO


ALTER TABLE [Telefeono] DROP CONSTRAINT [Participante_individual_Telefeono]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Nota"                                                      */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Nota] DROP CONSTRAINT [PK_Nota]
GO


DROP TABLE [Nota]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Detalle_Participante_Capacitacion"                         */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Detalle_Participante_Capacitacion] DROP CONSTRAINT [PK_Detalle_Participante_Capacitacion]
GO


DROP TABLE [Detalle_Participante_Capacitacion]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Capacitacion_libre"                                        */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Capacitacion_libre] DROP CONSTRAINT [PK_Capacitacion_libre]
GO


DROP TABLE [Capacitacion_libre]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Correo"                                                    */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Correo] DROP CONSTRAINT [PK_Correo]
GO


DROP TABLE [Correo]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Pago"                                                      */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Pago] DROP CONSTRAINT [PK_Pago]
GO


DROP TABLE [Pago]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Capacitacion"                                              */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Capacitacion] DROP CONSTRAINT [PK_Capacitacion]
GO


DROP TABLE [Capacitacion]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Capacitador"                                               */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Capacitador] DROP CONSTRAINT [PK_Capacitador]
GO


DROP TABLE [Capacitador]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Contacto"                                                  */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Contacto] DROP CONSTRAINT [PK_Contacto]
GO


DROP TABLE [Contacto]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Usuario"                                                   */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Usuario] DROP CONSTRAINT [PK_Usuario]
GO


DROP TABLE [Usuario]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Telefeono"                                                 */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Telefeono] DROP CONSTRAINT [PK_Telefeono]
GO


DROP TABLE [Telefeono]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Participante_individual"                                   */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

DROP TABLE [Participante_individual]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Empresa"                                                   */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Empresa] DROP CONSTRAINT [PK_Empresa]
GO


DROP TABLE [Empresa]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Numero_telefono"                                           */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Numero_telefono] DROP CONSTRAINT [PK_Numero_telefono]
GO


DROP TABLE [Numero_telefono]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Tipo_usuario"                                              */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Tipo_usuario] DROP CONSTRAINT [PK_Tipo_usuario]
GO


DROP TABLE [Tipo_usuario]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Tipo_nota"                                                 */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Tipo_nota] DROP CONSTRAINT [PK_Tipo_nota]
GO


DROP TABLE [Tipo_nota]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Participante"                                              */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Participante] DROP CONSTRAINT [PK_Participante]
GO


DROP TABLE [Participante]
GO


/* ---------------------------------------------------------------------- */
/* Drop table "Tema"                                                      */
/* ---------------------------------------------------------------------- */

GO


/* Drop constraints */

ALTER TABLE [Tema] DROP CONSTRAINT [PK_Tema]
GO


DROP TABLE [Tema]
GO

