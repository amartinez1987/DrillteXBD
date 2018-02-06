
GO
USE MOLDE
GO
INSERT INTO AplicacionesWeb (
   nombre
  ,descripcion
  ,usuarioId
) VALUES (
   'Molde'  -- nombre - varchar(1000)
  ,'m'  -- descripcion - varchar(800)
  ,1   -- usuarioId - int
)
GO
INSERT INTO Menus (
   nombreMenu
  ,aplicacionWebId
  ,usuarioId
  ,estado
  ,icon
  ,indexVisibilidad
) VALUES (
   'Herramientas'  -- nombreMenu - varchar(100)
  ,1 -- aplicacionWebId - int
  ,1   -- usuarioId - int
  ,'Activo'  -- estado - varchar(50)
  ,'fa fa-bar-chart-o fa-fw'  -- icon - varchar(100)
  ,1   -- indexVisibilidad - int
)

INSERT INTO Menus (
   nombreMenu
  ,aplicacionWebId
  ,usuarioId
  ,estado
  ,icon
  ,indexVisibilidad
) VALUES (
   'Proyectos'  -- nombreMenu - varchar(100)
  ,1 -- aplicacionWebId - int
  ,1   -- usuarioId - int
  ,'Activo'  -- estado - varchar(50)
  ,'fa fa-bar-chart-o fa-fw'  -- icon - varchar(100)
  ,2   -- indexVisibilidad - int
)


INSERT INTO Menus (
   nombreMenu
  ,aplicacionWebId
  ,usuarioId
  ,estado
  ,icon
  ,indexVisibilidad
) VALUES (
   'Prototipos'  -- nombreMenu - varchar(100)
  ,1 -- aplicacionWebId - int
  ,1   -- usuarioId - int
  ,'Activo'  -- estado - varchar(50)
  ,'fa fa-bar-chart-o fa-fw'  -- icon - varchar(100)
  ,3   -- indexVisibilidad - int
)
GO
select * from menus
insert into Formularios (
   nombreFormulario
  ,urlFormulario
  ,nombreMostrar
  ,menuId
  ,esVisible
  ,usuarioId
  ,estados
  ,iconOpcion
  ,indexVisibilidad
) VALUES (
   'Herramienta 1'  -- nombreFormulario - varchar(100)
  ,'index.aspx'  -- urlFormulario - varchar(500)
  ,'Herramienta 1'  -- nombreMostrar - varchar(800)
  ,1   -- menuId - int
  ,1  -- esVisible - bit
  ,0   -- usuarioId - int
  ,'Activo'  -- estados - varchar(50)
  ,''  -- iconOpcion - varchar(100)
  ,1   -- indexVisibilidad - int
)

insert into Formularios (
   nombreFormulario
  ,urlFormulario
  ,nombreMostrar
  ,menuId
  ,esVisible
  ,usuarioId
  ,estados
  ,iconOpcion
  ,indexVisibilidad
) VALUES (
   'Herramienta 2'  -- nombreFormulario - varchar(100)
  ,'index.aspx'  -- urlFormulario - varchar(500)
  ,'Herramienta 2'  -- nombreMostrar - varchar(800)
  ,1   -- menuId - int
  ,1  -- esVisible - bit
  ,0   -- usuarioId - int
  ,'Activo'  -- estados - varchar(50)
  ,''  -- iconOpcion - varchar(100)
  ,2   -- indexVisibilidad - int
)

insert into Formularios (
   nombreFormulario
  ,urlFormulario
  ,nombreMostrar
  ,menuId
  ,esVisible
  ,usuarioId
  ,estados
  ,iconOpcion
  ,indexVisibilidad
) VALUES (
   'Herramienta 3'  -- nombreFormulario - varchar(100)
  ,'index.aspx'  -- urlFormulario - varchar(500)
  ,'Herramienta 3'  -- nombreMostrar - varchar(800)
  ,1   -- menuId - int
  ,0  -- esVisible - bit
  ,0   -- usuarioId - int
  ,'Activo'  -- estados - varchar(50)
  ,''  -- iconOpcion - varchar(100)
  ,3   -- indexVisibilidad - int
)

insert into Formularios (
   nombreFormulario
  ,urlFormulario
  ,nombreMostrar
  ,menuId
  ,esVisible
  ,usuarioId
  ,estados
  ,iconOpcion
  ,indexVisibilidad
) VALUES (
   'Herramienta 4'  -- nombreFormulario - varchar(100)
  ,'index.aspx'  -- urlFormulario - varchar(500)
  ,'Herramienta 4'  -- nombreMostrar - varchar(800)
  ,1   -- menuId - int
  ,1  -- esVisible - bit
  ,0   -- usuarioId - int
  ,'Activo'  -- estados - varchar(50)
  ,''  -- iconOpcion - varchar(100)
  ,4   -- indexVisibilidad - int
)

insert into Formularios (
   nombreFormulario
  ,urlFormulario
  ,nombreMostrar
  ,menuId
  ,esVisible
  ,usuarioId
  ,estados
  ,iconOpcion
  ,indexVisibilidad
) VALUES (
   'Proyecto 1'  -- nombreFormulario - varchar(100)
  ,'index.aspx'  -- urlFormulario - varchar(500)
  ,'Proyecto 1'  -- nombreMostrar - varchar(800)
  ,2   -- menuId - int
  ,1  -- esVisible - bit
  ,0   -- usuarioId - int
  ,'Activo'  -- estados - varchar(50)
  ,''  -- iconOpcion - varchar(100)
  ,1   -- indexVisibilidad - int
)
insert into Formularios (
   nombreFormulario
  ,urlFormulario
  ,nombreMostrar
  ,menuId
  ,esVisible
  ,usuarioId
  ,estados
  ,iconOpcion
  ,indexVisibilidad
) VALUES (
   'Proyecto 2'  -- nombreFormulario - varchar(100)
  ,'index.aspx'  -- urlFormulario - varchar(500)
  ,'Proyecto 2'  -- nombreMostrar - varchar(800)
  ,2   -- menuId - int
  ,1  -- esVisible - bit
  ,0   -- usuarioId - int
  ,'Activo'  -- estados - varchar(50)
  ,''  -- iconOpcion - varchar(100)
  ,2   -- indexVisibilidad - int
)
GO
select * from Formularios
insert into Operaciones (
   nombreOperacion
  ,usuarioId
) VALUES (
   'Nuevo'  -- nombreOperacion - varchar(1000)
  ,1   -- usuarioId - int
)
insert into Operaciones (
   nombreOperacion
  ,usuarioId
) VALUES (
   'Editar'  -- nombreOperacion - varchar(1000)
  ,1   -- usuarioId - int
)
insert into Operaciones (
   nombreOperacion
  ,usuarioId
) VALUES (
   'Activar'  -- nombreOperacion - varchar(1000)
  ,1   -- usuarioId - int
)
insert into Operaciones (
   nombreOperacion
  ,usuarioId
) VALUES (
   'Inactivar'  -- nombreOperacion - varchar(1000)
  ,1   -- usuarioId - int
)
GO
INSERT INTO OperacionesFormulario (
   formularioId
  ,operacionId
  ,descripcion
  ,usuarioId
) VALUES (
   1 -- formularioId - int
  ,1 -- operacionId - int
  ,'A' -- descripcion - varchar(8000)
  ,1   -- usuarioId - int
)
INSERT INTO OperacionesFormulario (
   formularioId
  ,operacionId
  ,descripcion
  ,usuarioId
) VALUES (
   1 -- formularioId - int
  ,2 -- operacionId - int
  ,'A' -- descripcion - varchar(8000)
  ,1   -- usuarioId - int
)

INSERT INTO OperacionesFormulario (
   formularioId
  ,operacionId
  ,descripcion
  ,usuarioId
) VALUES (
   1 -- formularioId - int
  ,3 -- operacionId - int
  ,'A' -- descripcion - varchar(8000)
  ,1   -- usuarioId - int
)

INSERT INTO OperacionesFormulario (
   formularioId
  ,operacionId
  ,descripcion
  ,usuarioId
) VALUES (
   1 -- formularioId - int
  ,4 -- operacionId - int
  ,'A' -- descripcion - varchar(8000)
  ,1   -- usuarioId - int
)
INSERT INTO OperacionesFormulario (
   formularioId
  ,operacionId
  ,descripcion
  ,usuarioId
) VALUES (
   2 -- formularioId - int
  ,1 -- operacionId - int
  ,'A' -- descripcion - varchar(8000)
  ,1   -- usuarioId - int
)
INSERT INTO OperacionesFormulario (
   formularioId
  ,operacionId
  ,descripcion
  ,usuarioId
) VALUES (
   2 -- formularioId - int
  ,2 -- operacionId - int
  ,'A' -- descripcion - varchar(8000)
  ,1   -- usuarioId - int
)

INSERT INTO OperacionesFormulario (
   formularioId
  ,operacionId
  ,descripcion
  ,usuarioId
) VALUES (
   3 -- formularioId - int
  ,3 -- operacionId - int
  ,'A' -- descripcion - varchar(8000)
  ,1   -- usuarioId - int
)


INSERT INTO OperacionesFormulario (
   formularioId
  ,operacionId
  ,descripcion
  ,usuarioId
) VALUES (
   4 -- formularioId - int
  ,4 -- operacionId - int
  ,'A' -- descripcion - varchar(8000)
  ,1   -- usuarioId - int
)
INSERT INTO OperacionesFormulario (
   formularioId
  ,operacionId
  ,descripcion
  ,usuarioId
) VALUES (
   4 -- formularioId - int
  ,1 -- operacionId - int
  ,'A' -- descripcion - varchar(8000)
  ,1   -- usuarioId - int
)

INSERT INTO OperacionesFormulario (
   formularioId
  ,operacionId
  ,descripcion
  ,usuarioId
) VALUES (
   5 -- formularioId - int
  ,1 -- operacionId - int
  ,'A' -- descripcion - varchar(8000)
  ,1   -- usuarioId - int
)
GO
INSERT INTO Perfiles (
   nombrePerfil
  ,descripcion
  ,estado
  ,usuarioId
) VALUES (
   'Molde'  -- nombrePerfil - varchar(200)
  ,'M'  -- descripcion - varchar(8000)
  ,'Activo'  -- estado - varchar(50)
  ,1   -- usuarioId - int
)
GO
INSERT INTO UsuariosOperacionesFormulario (
   usuarioId
  ,operacionFormularioId
  ,usuarioIdApl
) VALUES (
   1   -- usuarioId - int
  ,1   -- operacionFormularioId - int
  ,1   -- usuarioIdApl - int
)
go
select * from  UsuariosOperacionesFormulario
insert into UsuariosOperacionesFormulario (
   usuarioId
  ,operacionFormularioId
  ,usuarioIdApl
) VALUES (
   3   -- usuarioId - int
  ,1   -- operacionFormularioId - int
  ,1   -- usuarioIdApl - int
)