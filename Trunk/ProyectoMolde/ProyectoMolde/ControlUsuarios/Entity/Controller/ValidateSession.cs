using ControlUsuarios.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUsuarios.Entity.Controller
{
    public class ValidateSession
    {
        public static Result validarSession(int usuarioId, object usuarioIdSession)
        {
            int usuarioSessionid = (usuarioIdSession == null) ? 0 : usuarioIdSession.ToString() == "" ? 0 : int.Parse(usuarioIdSession.ToString());
            if (usuarioId != usuarioSessionid)
            {
                return new Result() { error = "El usuario no coincide con el que inicio sesión.",tipoAlerta="warning" };
            }

            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.Usuarios.Where(x => x.id == usuarioId).Count() == 0)
                {
                    return new Result() { error = "El usuario no es valido.", tipoAlerta = "warning" };
                }
            }
                

            return new Result() { error = "" };
        }

        public static Result validarOperacionesForm(string nombreformulario, string operacion, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                try
                {
                    var u = from usuarios in entity.Usuarios
                            where usuarios.id == usuarioId
                            select usuarios;

                    if (u.FirstOrDefault().UsuariosOperacionesFormulario.Where(x => x.OperacionesFormulario.Formularios.nombreFormulario == nombreformulario && x.OperacionesFormulario.Operaciones.nombreOperacion == operacion).Count() > 0)
                    {
                        return new Result() { error = "" };
                    }
                }
                catch (Exception)
                {
                    return new Result() { error = "Usted no tiene habilitada esta operación.", tipoAlerta = "warning" };
                }
                                
            }

            return new Result() { error = "Usted no tiene habilitada esta operación.", tipoAlerta = "warning" };
        }

    
    }
}