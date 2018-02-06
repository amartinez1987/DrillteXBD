using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;
using System.IO;

namespace ControlUsuarios.Entity.Controller
{
    public class UsuariosController
    {
        MoldeEntities entity = new MoldeEntities();

        public MoldeEntities getEntity()
        {
            return entity;
        }

        public List<UsuariosViewModel> getListaUsuarios(string valorBuscado)
        {
            switch (valorBuscado)
            {
                case "":
                    var l = from usuarios in entity.Usuarios
                            select new UsuariosViewModel
                            {
                                id = usuarios.id,
                                idPersona = usuarios.idPersona,
                                usuarioId = usuarios.usuarioId,
                                perfilId = usuarios.perfilId,
                                nombreUsuario = usuarios.nombreUsuario,
                                clave = usuarios.clave,
                                estado = usuarios.estado,
                                siglaDocumentoIdentidad = usuarios.Personas.DocumentosIdentidad.sigla,
                                numeroDocumento = usuarios.Personas.numeroDocumento,
                                barrioId = usuarios.Personas.barrioId,
                                correo = usuarios.Personas.correo,
                                direcccion = usuarios.Personas.direcccion,
                                documentoIdentidadId = usuarios.Personas.documentoIdentidadId,
                                estadoCivilId = usuarios.Personas.estadoCivilId,
                                estatura = usuarios.Personas.estatura,
                                grupoSanguineoId = usuarios.Personas.grupoSanguineoId,
                                municipioExpedicionId = usuarios.Personas.municipioExpedicionId,
                                municipioId = usuarios.Personas.municipioId,
                                peso = usuarios.Personas.peso,
                                primerApellido = usuarios.Personas.primerApellido,
                                primerNombre = usuarios.Personas.primerNombre,
                                segundoApellido = usuarios.Personas.segundoApellido,
                                segundoNombre = usuarios.Personas.segundoNombre,
                                sexoId = usuarios.Personas.sexoId,
                                telefonoCelular = usuarios.Personas.telefonoCelular,
                                telefonoFijo = usuarios.Personas.telefonoFijo,
                                codigoDaneDepartamento = usuarios.Personas.Municipios.Departamentos.codigoDane,
                                codigoDaneMunicipio = usuarios.Personas.Municipios.codigoDane,
                                nombreDepartamento = usuarios.Personas.Municipios.Departamentos.nombre,
                                nombreMunicipio = usuarios.Personas.Municipios.nombre,
                                siglaGrupoSanguineo = usuarios.Personas.GruposSanguineo.sigla,
                                siglaSexo = usuarios.Personas.Sexos.sigla,
                                codigoDaneDepartamentoExpedicion = usuarios.Personas.Municipios1.Departamentos.codigoDane,
                                codigoDaneMunicipioExpedicion = usuarios.Personas.Municipios1.codigoDane,
                                nombreDepartamentoExpedicion = usuarios.Personas.Municipios1.Departamentos.nombre,
                                nombreMunicipioExpedicion = usuarios.Personas.Municipios1.nombre,
                                nombreDepartamentoBarrio = usuarios.Personas.Barrios.Municipios.Departamentos.nombre,
                                nombreMunicipioBarrio = usuarios.Personas.Barrios.Municipios.nombre,
                                nombreoBarrio = usuarios.Personas.Barrios.nombre,
                                nombreEstadoCivil = usuarios.Personas.EstadosCivil.sigla,
                                nombrePerfil = usuarios.Perfiles.nombrePerfil,
                                descripcionDocumentoIdentidad = usuarios.Personas.DocumentosIdentidad.descripcion,
                                descripcionGrupoSanguineo = usuarios.Personas.GruposSanguineo.descripcion,
                                descripcionSexo = usuarios.Personas.Sexos.descripcion,
                                fechaNacimiento = usuarios.Personas.fechaNacimiento,
                                fechaExpedicionCedula = usuarios.Personas.fechaExpedicionCedula

                            };
                    return l.ToList();
                    
                default: var lu = from usuarios in entity.Usuarios
                                  where usuarios.nombreUsuario.Contains(valorBuscado) || usuarios.Personas.primerNombre.Contains(valorBuscado) || usuarios.Personas.segundoNombre.Contains(valorBuscado) || usuarios.Personas.primerApellido.Contains(valorBuscado) || usuarios.Personas.segundoApellido.Contains(valorBuscado) || usuarios.Personas.numeroDocumento.Contains(valorBuscado)
                                  select new UsuariosViewModel
                                  {
                                      id = usuarios.id,
                                      idPersona = usuarios.idPersona,
                                      usuarioId = usuarios.usuarioId,
                                      perfilId = usuarios.perfilId,
                                      nombreUsuario = usuarios.nombreUsuario,
                                      clave = usuarios.clave,
                                      estado = usuarios.estado,
                                      siglaDocumentoIdentidad = usuarios.Personas.DocumentosIdentidad.sigla,
                                      numeroDocumento = usuarios.Personas.numeroDocumento,
                                      barrioId = usuarios.Personas.barrioId,
                                      correo = usuarios.Personas.correo,
                                      direcccion = usuarios.Personas.direcccion,
                                      documentoIdentidadId = usuarios.Personas.documentoIdentidadId,
                                      estadoCivilId = usuarios.Personas.estadoCivilId,
                                      estatura = usuarios.Personas.estatura,
                                      grupoSanguineoId = usuarios.Personas.grupoSanguineoId,
                                      municipioExpedicionId = usuarios.Personas.municipioExpedicionId,
                                      municipioId = usuarios.Personas.municipioId,
                                      peso = usuarios.Personas.peso,
                                      primerApellido = usuarios.Personas.primerApellido,
                                      primerNombre = usuarios.Personas.primerNombre,
                                      segundoApellido = usuarios.Personas.segundoApellido,
                                      segundoNombre = usuarios.Personas.segundoNombre,
                                      sexoId = usuarios.Personas.sexoId,
                                      telefonoCelular = usuarios.Personas.telefonoCelular,
                                      telefonoFijo = usuarios.Personas.telefonoFijo,
                                      codigoDaneDepartamento = usuarios.Personas.Municipios.Departamentos.codigoDane,
                                      codigoDaneMunicipio = usuarios.Personas.Municipios.codigoDane,
                                      nombreDepartamento = usuarios.Personas.Municipios.Departamentos.nombre,
                                      nombreMunicipio = usuarios.Personas.Municipios.nombre,
                                      siglaGrupoSanguineo = usuarios.Personas.GruposSanguineo.sigla,
                                      siglaSexo = usuarios.Personas.Sexos.sigla,
                                      codigoDaneDepartamentoExpedicion = usuarios.Personas.Municipios1.Departamentos.codigoDane,
                                      codigoDaneMunicipioExpedicion = usuarios.Personas.Municipios1.codigoDane,
                                      nombreDepartamentoExpedicion = usuarios.Personas.Municipios1.Departamentos.nombre,
                                      nombreMunicipioExpedicion = usuarios.Personas.Municipios1.nombre,
                                      nombreDepartamentoBarrio = usuarios.Personas.Barrios.Municipios.Departamentos.nombre,
                                      nombreMunicipioBarrio = usuarios.Personas.Barrios.Municipios.nombre,
                                      nombreoBarrio = usuarios.Personas.Barrios.nombre,
                                      nombreEstadoCivil = usuarios.Personas.EstadosCivil.sigla,
                                      nombrePerfil = usuarios.Perfiles.nombrePerfil,
                                      descripcionDocumentoIdentidad = usuarios.Personas.DocumentosIdentidad.descripcion,
                                      descripcionGrupoSanguineo = usuarios.Personas.GruposSanguineo.descripcion,
                                      descripcionSexo = usuarios.Personas.Sexos.descripcion,
                                      fechaNacimiento = usuarios.Personas.fechaNacimiento,
                                      fechaExpedicionCedula = usuarios.Personas.fechaExpedicionCedula

                                  };
                    return lu.ToList();
                    
            }

        }

        public UsuariosViewModel getUsuariosId(int id)
        {

            var l = from usuarios in entity.Usuarios
                    where usuarios.id == id
                    select new UsuariosViewModel
                    {
                        id = usuarios.id,
                        idPersona = usuarios.idPersona,
                        usuarioId = usuarios.usuarioId,
                        perfilId = usuarios.perfilId,
                        nombreUsuario = usuarios.nombreUsuario,
                        clave = usuarios.clave,
                        estado = usuarios.estado,
                        siglaDocumentoIdentidad = usuarios.Personas.DocumentosIdentidad.sigla,
                        numeroDocumento = usuarios.Personas.numeroDocumento,
                        barrioId = usuarios.Personas.barrioId,
                        correo = usuarios.Personas.correo,
                        direcccion = usuarios.Personas.direcccion,
                        documentoIdentidadId = usuarios.Personas.documentoIdentidadId,
                        estadoCivilId = usuarios.Personas.estadoCivilId,
                        estatura = usuarios.Personas.estatura,
                        grupoSanguineoId = usuarios.Personas.grupoSanguineoId,
                        municipioExpedicionId = usuarios.Personas.municipioExpedicionId,
                        municipioId = usuarios.Personas.municipioId,
                        peso = usuarios.Personas.peso,
                        primerApellido = usuarios.Personas.primerApellido,
                        primerNombre = usuarios.Personas.primerNombre,
                        segundoApellido = usuarios.Personas.segundoApellido,
                        segundoNombre = usuarios.Personas.segundoNombre,
                        sexoId = usuarios.Personas.sexoId,
                        telefonoCelular = usuarios.Personas.telefonoCelular,
                        telefonoFijo = usuarios.Personas.telefonoFijo,
                        codigoDaneDepartamento = usuarios.Personas.Municipios.Departamentos.codigoDane,
                        codigoDaneMunicipio = usuarios.Personas.Municipios.codigoDane,
                        nombreDepartamento = usuarios.Personas.Municipios.Departamentos.nombre,
                        nombreMunicipio = usuarios.Personas.Municipios.nombre,
                        siglaGrupoSanguineo = usuarios.Personas.GruposSanguineo.sigla,
                        siglaSexo = usuarios.Personas.Sexos.sigla,
                        codigoDaneDepartamentoExpedicion = usuarios.Personas.Municipios1.Departamentos.codigoDane,
                        codigoDaneMunicipioExpedicion = usuarios.Personas.Municipios1.codigoDane,
                        nombreDepartamentoExpedicion = usuarios.Personas.Municipios1.Departamentos.nombre,
                        nombreMunicipioExpedicion = usuarios.Personas.Municipios1.nombre,
                        nombreDepartamentoBarrio = usuarios.Personas.Barrios.Municipios.Departamentos.nombre,
                        nombreMunicipioBarrio = usuarios.Personas.Barrios.Municipios.nombre,
                        nombreoBarrio = usuarios.Personas.Barrios.nombre,
                        nombreEstadoCivil = usuarios.Personas.EstadosCivil.sigla,
                        nombrePerfil = usuarios.Perfiles.nombrePerfil,
                        descripcionDocumentoIdentidad = usuarios.Personas.DocumentosIdentidad.descripcion,
                        descripcionGrupoSanguineo = usuarios.Personas.GruposSanguineo.descripcion,
                        descripcionSexo = usuarios.Personas.Sexos.descripcion,
                        fechaNacimiento = usuarios.Personas.fechaNacimiento,
                        fechaExpedicionCedula = usuarios.Personas.fechaExpedicionCedula

                    };
            return l.SingleOrDefault();

        }

        public static UsuariosViewModel getUsuarioViewModelPorNombre(string nombreUsuario)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from usuarios in entity.Usuarios
                        where usuarios.nombreUsuario.ToLower() == nombreUsuario.ToLower()
                        select new UsuariosViewModel { id = usuarios.id, idPersona = usuarios.idPersona, usuarioId = usuarios.usuarioId, perfilId = usuarios.perfilId, nombreUsuario = usuarios.nombreUsuario, clave = usuarios.clave, estado = usuarios.estado };
                return l.SingleOrDefault();
            }
        }

        public static Usuarios getUsuarioPorNombre(string nombreUsuario)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from usuarios in entity.Usuarios
                        where usuarios.nombreUsuario.ToLower() == nombreUsuario.ToLower()
                        select usuarios;
                return l.SingleOrDefault();
            }
        }

        public Result getMenuUsuarioPorId(int usuarioId, string aplicacion)
        {
            string listaMenu = "";
            try
            {
                Usuarios u = entity.Usuarios.FirstOrDefault(x => x.id == usuarioId);
                if (u.UsuariosOperacionesFormulario.Count != 0)
                {
                    List<Menus> lM = (from luofe in u.UsuariosOperacionesFormulario
                                      where luofe.OperacionesFormulario.Formularios.Menus.AplicacionesWeb.nombre == aplicacion &&
                                            luofe.OperacionesFormulario.Formularios.esVisible == true &&
                                            luofe.OperacionesFormulario.Formularios.Menus.estado == "Activo" &&
                                            luofe.OperacionesFormulario.Operaciones.visualizaFormularioMenu == true

                                      orderby luofe.OperacionesFormulario.Formularios.Menus.indexVisibilidad
                                      group luofe by new { luofe.OperacionesFormulario.Formularios.Menus } into gF
                                      select gF.Key.Menus).ToList();


                    foreach (Menus m in lM)
                    {
                        listaMenu += "<li>";
                        listaMenu += string.Format("<a href=\"#\"><i class=\"{0}\"></i>{1}<span class=\"glyphicon arrow\"></span></a>", m.icon, m.nombreMenu);
                        listaMenu += "<ul class=\"nav nav-second-level\">";
                        foreach (Formularios f in m.Formularios)
                        {
                            if (u.UsuariosOperacionesFormulario.Where(x => x.OperacionesFormulario.formularioId == f.id && x.OperacionesFormulario.Formularios.estados == "Activo" && x.OperacionesFormulario.Formularios.esVisible == true).Count() != 0)
                            {
                                listaMenu += "<li>";
                                listaMenu += string.Format("<a href=\"{0}\"><i class=\"{2}\"></i>{1}</a>", f.urlFormulario, f.nombreMostrar, f.iconOpcion);
                                listaMenu += "</li>";
                            }
                        }
                        listaMenu += "</ul>";
                        listaMenu += "</li>";
                    }
                }
            }
            catch (Exception ex)
            {

                return new Result() { error = ex.Message, tipoAlerta = "danger" };
            }

            return new Result() { id = usuarioId, getCadena = listaMenu, error = "" };
        }


        public Usuarios getModel(UsuariosViewModel usuario)
        {
            DateTime f = new DateTime(1800, 01, 01);
            if (usuario.fechaExpedicionCedula == null) { usuario.fechaExpedicionCedula = f; }
            if (usuario.fechaNacimiento == null) { usuario.fechaNacimiento = f; }
            if (usuario.peso == null) { usuario.peso = 0; }
            if (usuario.barrioId == null) { usuario.barrioId = 0; }
            if (usuario.documentoIdentidadId == null) { usuario.documentoIdentidadId = 0; }
            if (usuario.estadoCivilId == null) { usuario.estadoCivilId = 0; }
            if (usuario.estatura == null) { usuario.estatura = 0; }
            if (usuario.grupoSanguineoId == null) { usuario.grupoSanguineoId = 0; }
            if (usuario.municipioExpedicionId == null) { usuario.municipioExpedicionId = 0; }
            if (usuario.municipioId == null) { usuario.municipioId = 0; }
            if (usuario.sexoId == null) { usuario.sexoId = 0; }
            if (usuario.telefonoCelular == null) { usuario.telefonoCelular = 0; }
            if (usuario.telefonoFijo == null) { usuario.telefonoFijo = 0; }
            if (usuario.idPersona == null) { usuario.idPersona = 0; }

            Personas p = new Personas()
            {
                barrioId = usuario.barrioId,
                correo = usuario.correo,
                direcccion = usuario.correo,
                documentoIdentidadId = usuario.documentoIdentidadId.Value,
                estadoCivilId = usuario.estadoCivilId.Value,
                estatura = usuario.estatura.Value,
                fechaExpedicionCedula = usuario.fechaExpedicionCedula.Value,
                fechaNacimiento = usuario.fechaNacimiento.Value,
                grupoSanguineoId = usuario.grupoSanguineoId.Value,
                id = usuario.idPersona.Value,
                municipioExpedicionId = usuario.municipioExpedicionId.Value,
                municipioId = usuario.municipioId.Value,
                numeroDocumento = usuario.numeroDocumento,
                peso = usuario.peso.Value,
                primerApellido = usuario.primerApellido.TrimStart(' ').TrimEnd(' '),
                primerNombre = usuario.primerNombre.TrimStart(' ').TrimEnd(' '),
                segundoApellido = usuario.segundoApellido.TrimStart(' ').TrimEnd(' '),
                segundoNombre = usuario.segundoNombre.TrimStart(' ').TrimEnd(' '),
                sexoId = usuario.sexoId.Value,
                telefonoCelular = usuario.telefonoCelular.Value,
                telefonoFijo = usuario.telefonoFijo.Value, 
                usuarioId = usuario.usuarioId.Value
            };

            Usuarios u = new Usuarios() { clave = usuario.clave, estado = usuario.estado, id = usuario.id, idPersona = usuario.idPersona, nombreUsuario = usuario.nombreUsuario, perfilId = usuario.perfilId, usuarioId = usuario.usuarioId, Personas = p };
            return u;
            
        }
    }
}
