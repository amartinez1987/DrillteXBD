USE [master]
GO
/****** Object:  Database [MoldeTrasabilidad]    Script Date: 23/01/2018 21:40:13 ******/
CREATE DATABASE [DrilltexTrasabilidad]
GO
USE [DrilltexTrasabilidad]
GO
/****** Object:  Table [dbo].[AplicacionesWeb]    Script Date: 23/01/2018 21:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AplicacionesWeb](
	[id] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[nombre] [varchar](1000) NOT NULL,
	[descripcion] [varchar](800) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Barrios]    Script Date: 23/01/2018 21:40:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barrios](
	[id] [int] NOT NULL,
	[municipioId] [int] NULL,
	[usuarioId] [int] NOT NULL,
	[nombre] [varchar](100) NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[id] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[codigoDane] [varchar](2) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentosIdentidad]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentosIdentidad](
	[id] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[sigla] [varchar](10) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadosCivil]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadosCivil](
	[id] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[sigla] [varchar](50) NULL,
	[descripcion] [varchar](100) NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formularios]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formularios](
	[id] [int] NOT NULL,
	[menuId] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[indexVisibilidad] [int] NOT NULL,
	[esVisible] [bit] NOT NULL,
	[nombreFormulario] [varchar](100) NOT NULL,
	[urlFormulario] [varchar](500) NOT NULL,
	[nombreMostrar] [varchar](800) NOT NULL,
	[estados] [varchar](50) NOT NULL,
	[iconOpcion] [varchar](100) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GruposSanguineo]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GruposSanguineo](
	[id] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[sigla] [varchar](50) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaestroAnexos]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaestroAnexos](
	[id] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[tabla] [varchar](1000) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[id] [int] NOT NULL,
	[aplicacionWebId] [int] NULL,
	[usuarioId] [int] NOT NULL,
	[indexVisibilidad] [int] NOT NULL,
	[nombreMenu] [varchar](100) NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[icon] [varchar](100) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Municipios]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipios](
	[id] [int] NOT NULL,
	[departamentoId] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[codigoDane] [varchar](3) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OpcionesMaestroAnexos]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpcionesMaestroAnexos](
	[id] [int] NOT NULL,
	[maestroAnexosId] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[nombreOpcion] [varchar](1000) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operaciones]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operaciones](
	[id] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[nombreOperacion] [varchar](1000) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperacionesFormulario]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperacionesFormulario](
	[id] [int] NOT NULL,
	[formularioId] [int] NULL,
	[operacionId] [int] NULL,
	[usuarioId] [int] NOT NULL,
	[descripcion] [varchar](8000) NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[id] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[nombrePerfil] [varchar](200) NOT NULL,
	[descripcion] [varchar](8000) NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilesOperacionesFormulario]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilesOperacionesFormulario](
	[id] [int] NOT NULL,
	[operacionFormularioId] [int] NULL,
	[perfilId] [int] NULL,
	[usuarioId] [int] NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[id] [int] NOT NULL,
	[documentoIdentidadId] [int] NOT NULL,
	[municipioId] [int] NOT NULL,
	[grupoSanguineoId] [int] NOT NULL,
	[sexoId] [int] NOT NULL,
	[municipioExpedicionId] [int] NOT NULL,
	[barrioId] [int] NULL,
	[estadoCivilId] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[estatura] [numeric](18, 2) NOT NULL,
	[peso] [numeric](18, 2) NOT NULL,
	[telefonoFijo] [bigint] NOT NULL,
	[telefonoCelular] [bigint] NOT NULL,
	[numeroDocumento] [varchar](100) NULL,
	[primerNombre] [varchar](50) NOT NULL,
	[segundoNombre] [varchar](50) NOT NULL,
	[primerApellido] [varchar](50) NOT NULL,
	[segundoApellido] [varchar](50) NOT NULL,
	[direcccion] [varchar](500) NOT NULL,
	[correo] [varchar](100) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[fechaExpedicionCedula] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexos]    Script Date: 23/01/2018 21:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexos](
	[id] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[sigla] [varchar](50) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 23/01/2018 21:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] NOT NULL,
	[idPersona] [int] NULL,
	[usuarioId] [int] NULL,
	[perfilId] [int] NOT NULL,
	[nombreUsuario] [varchar](100) NOT NULL,
	[clave] [varchar](100) NOT NULL,
	[estado] [varchar](50) NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosOperacionesFormulario]    Script Date: 23/01/2018 21:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosOperacionesFormulario](
	[id] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[operacionFormularioId] [int] NOT NULL,
	[usuarioIdApl] [int] NOT NULL,
	[idTrasabilidad] [int] IDENTITY(1,1) NOT NULL,
	[userNameBd] [varchar](100) NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[operacion] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AplicacionesWeb] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[AplicacionesWeb] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[Barrios] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[Barrios] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[Departamentos] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[Departamentos] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[DocumentosIdentidad] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[DocumentosIdentidad] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[EstadosCivil] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[EstadosCivil] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[Formularios] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[Formularios] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[GruposSanguineo] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[GruposSanguineo] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[MaestroAnexos] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[MaestroAnexos] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[Menus] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[Menus] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[Municipios] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[Municipios] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[OpcionesMaestroAnexos] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[OpcionesMaestroAnexos] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[Operaciones] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[Operaciones] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[OperacionesFormulario] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[OperacionesFormulario] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[Perfiles] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[Perfiles] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[PerfilesOperacionesFormulario] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[PerfilesOperacionesFormulario] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[Personas] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[Personas] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[Sexos] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[Sexos] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ('') FOR [operacion]
GO
ALTER TABLE [dbo].[UsuariosOperacionesFormulario] ADD  DEFAULT (getdate()) FOR [fechaHora]
GO
ALTER TABLE [dbo].[UsuariosOperacionesFormulario] ADD  DEFAULT ('') FOR [operacion]
GO
USE [master]
GO
ALTER DATABASE [MoldeTrasabilidad] SET  READ_WRITE 
GO
