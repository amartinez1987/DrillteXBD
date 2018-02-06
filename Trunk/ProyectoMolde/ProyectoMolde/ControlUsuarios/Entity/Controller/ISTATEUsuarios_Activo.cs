using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;
using ServiciosMetodos;
using System.Text.RegularExpressions;

namespace ControlUsuarios.Entity.Controller
{
    public class ISTATEUsuarios_Activo : ISTATEUsuarios
    {
        private const string nombreEstado = "Activo";
        public Result NuevoSinDatosPersona(ref Usuarios registro)
        {
            Result resul = new Result();
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }

        public Result NuevoConDatosPersona(ref Usuarios registro)
        {
            Result resul = new Result();
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }

        public Result Editar(ref Usuarios registro, string tipoModificacionPerfil)
        {
            Result resul = new Result();

            resul = ValidateSession.validarOperacionesForm("Usuarios", "Editar", registro.usuarioId.Value);

            if (resul.error != null && resul.error != "")
            {
                return resul;
            }

            resul = validarAtributosUsuarioPersona(registro);
            if (resul.error != null && resul.error != "")
            {
                return resul;
            }

            using (MoldeEntities entity = new MoldeEntities())
            {
                int usuariosId = registro.id;

                Usuarios registroEditar = entity.Usuarios.Where(x => x.id == usuariosId).SingleOrDefault();
                UsuariosOperacionesFormularioController uofc = new UsuariosOperacionesFormularioController();

                int perfilId = registroEditar.perfilId;
                int perfilIdN = registro.perfilId;
                int usuarioId = registro.usuarioId.Value;

                List<OperacionesFormulario> lstOf = entity.PerfilesOperacionesFormulario.Where(x => x.perfilId == perfilId).Select(x => x.OperacionesFormulario).ToList();
                List<OperacionesFormulario> lstOfN = entity.PerfilesOperacionesFormulario.Where(x => x.perfilId == perfilIdN).Select(x => x.OperacionesFormulario).ToList();
                List<UsuariosOperacionesFormulario> lstUopf = new List<UsuariosOperacionesFormulario>();

                entity.Entry(registroEditar).CurrentValues.SetValues(registro);

                switch (tipoModificacionPerfil)
                {
                    case "addPerfil":

                        foreach (var item in lstOf)
                        {
                            lstUopf.Add(new UsuariosOperacionesFormulario() { id = 0, usuarioId = registro.id, operacionFormularioId = item.id, usuarioIdApl = registro.usuarioId.Value });
                        }

                        foreach (var item in lstOfN)
                        {
                            lstUopf.Add(new UsuariosOperacionesFormulario() { id = 0, usuarioId = registro.id, operacionFormularioId = item.id, usuarioIdApl = registro.usuarioId.Value });
                        }

                        uofc.guardarUsuariosOperacionesFormulario(lstUopf.ToArray(), usuarioId);

                        break;
                    case "replacePerfil":

                        foreach (var item in lstOfN)
                        {
                            lstUopf.Add(new UsuariosOperacionesFormulario() { id = 0, usuarioId = registro.id, operacionFormularioId = item.id, usuarioIdApl = registro.usuarioId.Value });
                        }

                        uofc.guardarUsuariosOperacionesFormulario(lstUopf.ToArray(), usuarioId);
                        break;
                    default:
                        registro.perfilId = perfilId;
                        break;
                }
                PersonasController pc = new PersonasController();
                if (pc.existeRegistro(registro.idPersona.Value))
                {
                    entity.Entry(registroEditar.Personas).CurrentValues.SetValues(registro.Personas);
                }
                else { registroEditar.Personas = registro.Personas; }

                try
                {
                    entity.SaveChanges();
                    return new Result { error = "", id = registro.id, tipoAlerta = "success" };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }
            }
        }

        public Result Inactivar(ref Usuarios registro)
        {
            Result resul = new Result();
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }

        public Result Inactivar(int usuarioId, int usuarioIdApli)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {

                if (existeRegistro(usuarioId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("Usuarios", "Inactivar", usuarioIdApli);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }

                    Usuarios registroInactivar = entity.Usuarios.Where(x => x.id == usuarioId).SingleOrDefault();
                    registroInactivar.estado = "Inactivo";
                    registroInactivar.usuarioId = usuarioId;
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = usuarioId };
                    }
                    catch (Exception e)
                    {
                        return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                    }
                }
            }
            return new Result { error = "" };
        }


        public Result ValidarUsuario(ref Usuarios registro)
        {
            Result resul = validarAtributos(registro);
            if (resul.error != null && resul.error != "")
            {
                return resul;
            }

            using (MoldeEntities entity = new MoldeEntities())
            {
                int usuariosId = registro.id;
                Usuarios registroEditar = entity.Usuarios.Where(x => x.id == usuariosId).SingleOrDefault();
                string clave = Encriptado.EncriptarCadena(registro.clave);
                if (clave != registroEditar.clave)
                {
                    return new Result { error = "Clave Incorrecta", id = 0, tipoAlerta = "warning" };
                }

                return new Result { error = "", id = registro.id, tipoAlerta = "success" };

            }
        }

        public Result RegistrarUsuarioCorreoClave(ref Usuarios registro)
        {
            Result resul = new Result();
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }

        public Result Activar(ref Usuarios registro)
        {

            Result resul = new Result();
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }

        public Result Activar(int usuarioId, int usuarioIdApli)
        {

            Result resul = new Result();
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }

        private static Result validarAtributos(Usuarios registro)
        {
            if (registro.nombreUsuario == "")
            {
                return new Result() { error = "Digite un correo valido.", tipoAlerta = "warning" };
            }
          

            if (registro.clave == "")
            {
                return new Result() { error = "Digite una Clave valida.", tipoAlerta = "warning" };
            }

            return new Result();
        }

        private static Result validarAtributosUsuarioPersona(Usuarios registro)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (registro.nombreUsuario == "")
                {
                    return new Result() { error = "Digite un nomnbre Usuario valido.", tipoAlerta = "warning" };
                }

                if (registro.clave == "")
                {
                    return new Result() { error = "Digite una Clave valida.", tipoAlerta = "warning" };
                }

                if (registro.Personas.fechaNacimiento <= new DateTime(1800, 01, 01))
                {
                    return new Result { error = "La fecha de nacimiento es menor a 1800/01/01.", tipoAlerta = "warning" };
                }

                if (registro.Personas.fechaExpedicionCedula <= new DateTime(1800, 01, 01))
                {
                    return new Result { error = "La fecha de expedición cedula es menor a 1800/01/01.", tipoAlerta = "warning" };
                }

                if (registro.Personas.fechaExpedicionCedula <= registro.Personas.fechaNacimiento)
                {
                    return new Result { error = "La fecha expedición no puede ser menor a la de nacimiento.", tipoAlerta = "warning" };
                }

                if (registro.Personas.documentoIdentidadId == 0)
                {
                    return new Result { error = "Seleccione un tipo de identificación.", tipoAlerta = "warning" };
                }

                if (registro.Personas.municipioId == 0)
                {
                    return new Result { error = "Seleccione un municipio.", tipoAlerta = "warning" };
                }

                if (registro.Personas.grupoSanguineoId == 0)
                {
                    return new Result { error = "Seleccione un grupo sanguineo.", tipoAlerta = "warning" };
                }

                if (registro.Personas.sexoId == 0)
                {
                    return new Result { error = "Seleccione el sexo.", tipoAlerta = "warning" };
                }

                if (registro.Personas.municipioExpedicionId == 0)
                {
                    return new Result { error = "seleccione el municipio de expedición cedula.", tipoAlerta = "warning" };
                }

                if (registro.Personas.barrioId == 0)
                {
                    return new Result { error = "Seleccione el Barrio.", tipoAlerta = "warning" };
                }

                if (entity.Barrios.Where(x => x.id == registro.Personas.barrioId && x.municipioId == registro.Personas.municipioId).Count() == 0)
                {
                    return new Result { error = "El barrio no existe en el municipio seleccionado.", tipoAlerta = "warning" };
                }

                if (registro.Personas.estatura == 0)
                {
                    return new Result { error = "Ingrese la estatura.", tipoAlerta = "warning" };
                }

                if (registro.Personas.peso == 0)
                {
                    return new Result { error = "Ingrese el peso.", tipoAlerta = "warning" };
                }

                if (registro.Personas.estadoCivilId == 0)
                {
                    return new Result { error = "Seleccione estado civil.", tipoAlerta = "warning" };
                }

                if (registro.Personas.telefonoFijo.ToString().Length < 6)
                {
                    return new Result { error = "Ingrese un telefono de 6 caracteres.", tipoAlerta = "warning" };
                }

                if (registro.Personas.telefonoCelular.ToString().Length < 10)
                {
                    return new Result { error = "Ingrese numero celular mayor a 10 caracteres.", tipoAlerta = "warning" };
                }

                if (registro.Personas.numeroDocumento == "")
                {
                    return new Result { error = "Ingrese numero documento.", tipoAlerta = "warning" };
                }

                if (!MetodosGenerales.validaSoloNumeros(registro.Personas.numeroDocumento))
                {
                    return new Result { error = "El numero documento tiene un caracter no valido, letra o espacio.", tipoAlerta = "warning" };
                }

                if (registro.Personas.primerNombre == "")
                {
                    return new Result { error = "Digite el primer nombre.", tipoAlerta = "warning" };
                }

                if (MetodosGenerales.validaSoloLetras(registro.Personas.primerNombre))
                {
                    return new Result { error = "Primer nombre tiene un caracter no valido.", tipoAlerta = "warning" };
                }

                if (MetodosGenerales.validaSoloLetras(registro.Personas.segundoNombre))
                {
                    return new Result { error = "Segundo nombre tiene un caracter no valido.", tipoAlerta = "warning" };
                }

                if (registro.Personas.primerApellido == "")
                {
                    return new Result { error = "Digite el primer apellido.", tipoAlerta = "warning" };
                }

                if (MetodosGenerales.validaSoloLetras(registro.Personas.primerApellido))
                {
                    return new Result { error = "Primer apellido tiene un caracter no valido.", tipoAlerta = "warning" };
                }

                if (MetodosGenerales.validaSoloLetras(registro.Personas.segundoApellido))
                {
                    return new Result { error = "Segundo apellido tiene un caracter no valido.", tipoAlerta = "warning" };
                }

                if (registro.Personas.direcccion == "")
                {
                    return new Result { error = "Digite la direccion.", tipoAlerta = "warning" };
                }

                if (registro.Personas.correo == "")
                {
                    return new Result { error = "Digite el correo.", tipoAlerta = "warning" };
                }

                if (!new ServiciosMetodos.Mail().IsValidEmail(registro.Personas.correo))
                {
                    return new Result { error = "El correo no es valido.", tipoAlerta = "warning" };
                }

                if (registro.Personas.correo == "")
                {
                    return new Result { error = "Digite el correo.", tipoAlerta = "warning" };
                }
            }
            return new Result() { error = "" };

        }

        public static bool existeRegistro(string nombreUsuario)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.Usuarios.Where(x => x.nombreUsuario == nombreUsuario).Count() > 0)
                    return true;
                return false;
            }
        }

        private bool existeRegistro(int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.Usuarios.Where(x => x.id == usuarioId).Count() > 0)
                    return true;
                return false;
            }
        }

        public Result actualizarClave(UsuariosViewModel registro, int usuarioId)
        {
            Result resul = new Result();

            resul = ValidateSession.validarOperacionesForm("Usuarios", "CambiarClave", usuarioId);

            if (resul.error != null && resul.error != "")
            {
                return resul;
            }

            using (MoldeEntities entity = new MoldeEntities())
            {
                Usuarios registroEditar = entity.Usuarios.Where(x => x.id == registro.id).SingleOrDefault();
                registro.clave = Encriptado.EncriptarCadena(registro.clave);
                entity.Entry(registroEditar).CurrentValues.SetValues(registro);

                try
                {
                    entity.SaveChanges();
                    return new Result { error = "", id = registro.id, tipoAlerta = "success" };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }
            }
        }
    }
}
