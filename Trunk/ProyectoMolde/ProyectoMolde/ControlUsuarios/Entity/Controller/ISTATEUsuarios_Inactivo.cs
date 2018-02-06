using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlUsuarios.Entity.Model;

namespace ControlUsuarios.Entity.Controller
{
    public class ISTATEUsuarios_Inactivo : ISTATEUsuarios
    {
        private const string nombreEstado = "Inactivo";
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
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }
        public Result Inactivar(ref Usuarios registro)
        {
            Result resul = new Result();
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }
        public Result Inactivar(int usuarioId , int usuarioIdApli)
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
                    registroInactivar.estado = "Activo";
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
            Result resul = new Result();
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }

        public Result RegistrarUsuarioCorreoClave(ref Usuarios registro)
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

        private bool existeRegistro(int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.Usuarios.Where(x => x.id == usuarioId).Count() > 0)
                    return true;
                return false;
            }
        }

        public Result Activar(ref Usuarios registro)
        {

            Result resul = new Result();
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }

        public Result actualizarClave(UsuariosViewModel registro, int usuarioId)
        {
            Result resul = new Result();
            resul.error = "No se puede realizar esta operación en el estado actual del registro";
            resul.tipoAlerta = "Info";
            return resul;
        }

    }
}
