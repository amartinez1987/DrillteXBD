using ControlUsuarios.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUsuarios.Entity.Controller
{
    public class helpController
    {
        MoldeEntities entity = new MoldeEntities();
        public MoldeEntities getMolde()
        {
            return entity;
        }

        public object getLista(string tabla, string[] prefiltros, string textoBusqueda)
        {

            switch (tabla)
            {
                case "Departamentos":
                    try
                    {
                        var l = from departamentos in entity.Departamentos
                                where departamentos.nombre.Contains(textoBusqueda == "" ? departamentos.nombre : textoBusqueda) ||
                                      departamentos.codigoDane.Contains(textoBusqueda == "" ? departamentos.codigoDane : textoBusqueda)
                                select new DepartamentosViewModel { id = departamentos.id, usuarioId = departamentos.usuarioId, nombre = departamentos.nombre, codigoDane = departamentos.codigoDane };
                        return l.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<DepartamentosViewModel>();
                    }
                    
                case "AplicacionesWeb":
                    try
                    {
                        var la = from aplicacionesweb in entity.AplicacionesWeb
                                 where aplicacionesweb.nombre.Contains(textoBusqueda == "" ? aplicacionesweb.nombre : textoBusqueda)
                                 select new AplicacionesWebViewModel { id = aplicacionesweb.id, nombre = aplicacionesweb.nombre, descripcion = aplicacionesweb.descripcion };
                        return la.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<AplicacionesWebViewModel>();
                    }
                    
                case "Formularios":
                    try
                    {
                        var l = from formularios in entity.Formularios
                                select new FormulariosViewModel { id = formularios.id, menuId = formularios.menuId, nombreMenu = formularios.Menus.nombreMenu, usuarioId = formularios.usuarioId, indexVisibilidad = formularios.indexVisibilidad, esVisible = formularios.esVisible, nombreFormulario = formularios.nombreFormulario, urlFormulario = formularios.urlFormulario, nombreMostrar = formularios.nombreMostrar, estados = formularios.estados, iconOpcion = formularios.iconOpcion };
                        return l.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<FormulariosViewModel>();
                    }
                    
                case "Menus":
                    try
                    {
                        var l = from menus in entity.Menus
                                select new MenusViewModel { id = menus.id, aplicacionWebId = menus.aplicacionWebId, nombreAplicacionWeb = menus.AplicacionesWeb.nombre, usuarioId = menus.usuarioId, indexVisibilidad = menus.indexVisibilidad, nombreMenu = menus.nombreMenu, estado = menus.estado, icon = menus.icon };
                        return l.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<MenusViewModel>();
                    }
                    
                case "Municipios":
                    try
                    {
                        var lf = from municipios in entity.Municipios
                                 where municipios.nombre.Contains(textoBusqueda) || municipios.codigoDane.Contains(textoBusqueda) || municipios.Departamentos.codigoDane.Contains(textoBusqueda) || municipios.Departamentos.nombre.Contains(textoBusqueda)
                                 select new MunicipiosViewModel { id = municipios.id, nombre = municipios.nombre, codigoDane = municipios.codigoDane, departamentoId = municipios.departamentoId, usuarioId = municipios.usuarioId, codigoDaneDepartamento = municipios.Departamentos.codigoDane, nombreDepartamento = municipios.Departamentos.nombre };
                        return lf.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<MunicipiosViewModel>();
                    }
                    
                case "Perfiles":
                    try
                    {
                        var l = from perfiles in entity.Perfiles
                                where perfiles.nombrePerfil.Contains(textoBusqueda == "" ? perfiles.nombrePerfil : textoBusqueda)
                                select new PerfilesViewModel { id = perfiles.id, usuarioId = perfiles.usuarioId, nombrePerfil = perfiles.nombrePerfil, descripcion = perfiles.descripcion, estado = perfiles.estado };
                        return l.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<PerfilesViewModel>();
                    }
                    
                case "DocumentosIdentidad":
                    try
                    {
                        var l = from documentosidentidad in entity.DocumentosIdentidad
                                where documentosidentidad.sigla.Contains(textoBusqueda == "" ? documentosidentidad.sigla : textoBusqueda)
                                select new DocumentosIdentidadViewModel { id = documentosidentidad.id, usuarioId = documentosidentidad.usuarioId, sigla = documentosidentidad.sigla, descripcion = documentosidentidad.descripcion };
                        return l.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<DocumentosIdentidadViewModel>();
                    }
                    
                case "Sexos":
                    try
                    {
                        var l = from sexos in entity.Sexos
                                where sexos.sigla.Contains(textoBusqueda == "" ? sexos.sigla : textoBusqueda)
                                select new SexosViewModel { id = sexos.id, usuarioId = sexos.usuarioId, sigla = sexos.sigla, descripcion = sexos.descripcion };
                        return l.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<SexosViewModel>();
                    }
                    
                case "GruposSanguineo":
                    try
                    {
                        var l = from grupossanguineo in entity.GruposSanguineo
                                where grupossanguineo.sigla.Contains(textoBusqueda == "" ? grupossanguineo.sigla : textoBusqueda)
                                select new GruposSanguineoViewModel { id = grupossanguineo.id, usuarioId = grupossanguineo.usuarioId, sigla = grupossanguineo.sigla, descripcion = grupossanguineo.descripcion };
                        return l.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<GruposSanguineoViewModel>();
                    }
                    
                case "Barrios":
                    try
                    {
                        int municipioId = int.Parse(prefiltros[0]);
                        var l = from barrios in entity.Barrios
                                where barrios.municipioId == municipioId && ((barrios.Municipios.Departamentos.nombre + " " + barrios.Municipios.nombre).Contains(textoBusqueda == "" ? (barrios.Municipios.Departamentos.nombre + " " + barrios.Municipios.nombre) : textoBusqueda) || (barrios.Municipios.Departamentos.codigoDane + barrios.Municipios.codigoDane).Contains(textoBusqueda == "" ? (barrios.Municipios.Departamentos.codigoDane + barrios.Municipios.codigoDane) : textoBusqueda) || barrios.nombre.Contains(textoBusqueda == "" ? barrios.nombre : textoBusqueda))
                                select new BarriosViewModel { id = barrios.id, municipioId = barrios.municipioId, usuarioId = barrios.usuarioId, nombre = barrios.nombre, codigoDaneDepartamento = barrios.Municipios.Departamentos.codigoDane, codigoDaneMunicipio = barrios.Municipios.codigoDane, nombreDepartamento = barrios.Municipios.Departamentos.nombre, nombreMunicipio = barrios.Municipios.nombre };
                        return l.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<BarriosViewModel>();
                    }
                    
                case "EstadosCivil":
                    try
                    {
                        var l = from estadoscivil in entity.EstadosCivil
                                where estadoscivil.sigla.Contains(textoBusqueda==""?estadoscivil.sigla:textoBusqueda)
                                select new EstadosCivilViewModel { id = estadoscivil.id, usuarioId = estadoscivil.usuarioId, sigla = estadoscivil.sigla, descripcion = estadoscivil.descripcion };
                        return l.ToList();
                    }
                    catch (Exception)
                    {
                        return new List<BarriosViewModel>();
                    }
                    

            }
            return new List<string>();
        }

        public object getObject(string tabla, string valorBuscado, string[] prefiltros)
        {
            int valBusId = 0;
            int.TryParse(valorBuscado, out valBusId);

            switch (tabla)
            {
                case "Departamentos":
                    try
                    {
                        var ld = from departamentos in entity.Departamentos
                                 where departamentos.nombre.Contains(valorBuscado) || departamentos.codigoDane.Contains(valorBuscado)
                                 select new DepartamentosViewModel { id = departamentos.id, usuarioId = departamentos.usuarioId, nombre = departamentos.nombre, codigoDane = departamentos.codigoDane };
                        return ld.FirstOrDefault();
                    }
                    catch (Exception)
                    {
                        return new DepartamentosViewModel();
                    }
                    
                case "AplicacionesWeb":
                    try
                    {
                        var la = from aplicacionesweb in entity.AplicacionesWeb
                                 where aplicacionesweb.id == valBusId
                                 select new AplicacionesWebViewModel { id = aplicacionesweb.id, nombre = aplicacionesweb.nombre, descripcion = aplicacionesweb.descripcion };
                        return la.FirstOrDefault();
                    }
                    catch (Exception)
                    {
                        return new AplicacionesWebViewModel();
                    }
                    
                case "Formularios":
                    try
                    {
                        var lf = from formularios in entity.Formularios
                                 where formularios.id == valBusId
                                 select new FormulariosViewModel { id = formularios.id, menuId = formularios.menuId, nombreMenu = formularios.Menus.nombreMenu, usuarioId = formularios.usuarioId, indexVisibilidad = formularios.indexVisibilidad, esVisible = formularios.esVisible, nombreFormulario = formularios.nombreFormulario, urlFormulario = formularios.urlFormulario, nombreMostrar = formularios.nombreMostrar, estados = formularios.estados, iconOpcion = formularios.iconOpcion };
                        return lf.SingleOrDefault();
                    }
                    catch (Exception)
                    {
                        return new FormulariosViewModel();
                    }
                   
                case "Menus":
                    try
                    {
                        var l = from menus in entity.Menus
                                where menus.id == valBusId
                                select new MenusViewModel { id = menus.id, aplicacionWebId = menus.aplicacionWebId, nombreAplicacionWeb = menus.AplicacionesWeb.nombre, usuarioId = menus.usuarioId, indexVisibilidad = menus.indexVisibilidad, nombreMenu = menus.nombreMenu, estado = menus.estado, icon = menus.icon };
                        return l.SingleOrDefault();
                    }
                    catch (Exception)
                    {
                        return new MenusViewModel();
                    }
                    
                case "Municipios":
                    try
                    {
                        var lf = from municipios in entity.Municipios
                                 where (municipios.Departamentos.codigoDane + municipios.codigoDane).Contains(valorBuscado) || (municipios.Departamentos.nombre + municipios.nombre).Contains(valorBuscado)
                                 select new MunicipiosViewModel { id = municipios.id, nombre = municipios.nombre, codigoDane = municipios.codigoDane, departamentoId = municipios.departamentoId, usuarioId = municipios.usuarioId, codigoDaneDepartamento = municipios.Departamentos.codigoDane, nombreDepartamento = municipios.Departamentos.nombre };
                        return lf.SingleOrDefault();
                    }
                    catch (Exception)
                    {
                        return new MunicipiosViewModel();
                    }
                    
                case "Perfiles":
                    try
                    {
                        var l = from perfiles in entity.Perfiles
                                where perfiles.id == valBusId
                                select new PerfilesViewModel { id = perfiles.id, usuarioId = perfiles.usuarioId, nombrePerfil = perfiles.nombrePerfil, descripcion = perfiles.descripcion, estado = perfiles.estado };
                        return l.SingleOrDefault();
                    }
                    catch (Exception)
                    {
                        return new PerfilesViewModel();
                    }
                    
                case "DocumentosIdentidad":
                    try
                    {
                        var l = from documentosidentidad in entity.DocumentosIdentidad
                                where documentosidentidad.sigla.Contains(valorBuscado == "" ? documentosidentidad.sigla : valorBuscado)
                                select new DocumentosIdentidadViewModel { id = documentosidentidad.id, usuarioId = documentosidentidad.usuarioId, sigla = documentosidentidad.sigla, descripcion = documentosidentidad.descripcion };
                        return l.SingleOrDefault();
                    }
                    catch (Exception)
                    {
                        return new DocumentosIdentidadViewModel();
                    }
                   
                case "Sexos":
                    try
                    {
                        var l = from sexos in entity.Sexos
                                where sexos.sigla.Contains(valorBuscado == "" ? sexos.sigla : valorBuscado)
                                select new SexosViewModel { id = sexos.id, usuarioId = sexos.usuarioId, sigla = sexos.sigla, descripcion = sexos.descripcion };
                        return l.SingleOrDefault();
                    }
                    catch (Exception)
                    {
                        return new SexosViewModel();
                    }
                    
                case "GruposSanguineo":
                    try
                    {
                        var l = from grupossanguineo in entity.GruposSanguineo
                                where grupossanguineo.sigla.Contains(valorBuscado == "" ? grupossanguineo.sigla : valorBuscado)
                                select new GruposSanguineoViewModel { id = grupossanguineo.id, usuarioId = grupossanguineo.usuarioId, sigla = grupossanguineo.sigla, descripcion = grupossanguineo.descripcion };
                        return l.SingleOrDefault();
                    }
                    catch (Exception)
                    {
                        return new GruposSanguineoViewModel();
                    }
                    
                case "Barrios":
                    try
                    {
                        int municipioId = int.Parse(prefiltros[0]);
                        var l = from barrios in entity.Barrios
                                where barrios.municipioId == municipioId && barrios.id == valBusId
                                select new BarriosViewModel { id = barrios.id, municipioId = barrios.municipioId, usuarioId = barrios.usuarioId, nombre = barrios.nombre, codigoDaneDepartamento = barrios.Municipios.Departamentos.codigoDane, codigoDaneMunicipio = barrios.Municipios.codigoDane, nombreDepartamento = barrios.Municipios.Departamentos.nombre, nombreMunicipio = barrios.Municipios.nombre };
                        return l.SingleOrDefault();
                    }
                    catch (Exception)
                    {
                        return new BarriosViewModel();
                    }
                    
                case "EstadosCivil":
                    try
                    {
                        var l = from estadoscivil in entity.EstadosCivil
                                where estadoscivil.sigla.Contains(valorBuscado == "" ? estadoscivil.sigla : valorBuscado)
                                select new EstadosCivilViewModel { id = estadoscivil.id, usuarioId = estadoscivil.usuarioId, sigla = estadoscivil.sigla, descripcion = estadoscivil.descripcion };
                        return l.SingleOrDefault();
                    }
                    catch (Exception)
                    {
                        return new BarriosViewModel();
                    }
                   

            }
            return new List<string>();
        }
    }
}