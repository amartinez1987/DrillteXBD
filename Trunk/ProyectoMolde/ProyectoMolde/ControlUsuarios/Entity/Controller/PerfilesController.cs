using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class PerfilesController
    {
        public static List<PerfilesViewModel> getListaPerfiles()
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from perfiles in entity.Perfiles
                        select new PerfilesViewModel { id = perfiles.id, usuarioId = perfiles.usuarioId, nombrePerfil = perfiles.nombrePerfil, descripcion = perfiles.descripcion, estado = perfiles.estado };
                return l.ToList();
            }
        }

        public static PerfilesViewModel getPerfiles(int id)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from perfiles in entity.Perfiles
                        where perfiles.id==id
                        select new PerfilesViewModel { id = perfiles.id, usuarioId = perfiles.usuarioId, nombrePerfil = perfiles.nombrePerfil, descripcion = perfiles.descripcion, estado = perfiles.estado };
                return l.SingleOrDefault();
            }
        }

        public static Result guardarPerfiles(Perfiles registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }

            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(registro.id))
                {
                    result = ValidateSession.validarOperacionesForm("Perfiles", "Editar", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    int perfilesId = registro.id;
                    Perfiles registroEditar = entity.Perfiles.Where(x => x.id == perfilesId).SingleOrDefault();
                    entity.Entry(registroEditar).CurrentValues.SetValues(registro);
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = "" };
                    }
                    catch (Exception e)
                    {
                        return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                    }
                }
                else
                {
                    result = ValidateSession.validarOperacionesForm("Perfiles", "Nuevo", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    registro.estado = "Activo";
                    entity.Perfiles.Add(registro);
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = registro.id };
                    }
                    catch (Exception e)
                    {
                        return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                    }
                }
            }
        }

        private static Result validarAtributos(Perfiles registro)
        {
           
            if (registro.nombrePerfil == "")
            {
                return new Result { error = "Digite el nombre del perfil.", tipoAlerta = "warning" };
            }
            if (registro.descripcion == "")
            {
                return new Result { error = "Descripción del Perfil", tipoAlerta = "warning" };
            }
          
            return new Result() { error = "" };
        }
        public static bool existeRegistro(int perfilesId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.Perfiles.Where(x => x.id == perfilesId).Count() > 0)
                    return true;
                return false;
            }
        }
        public static Result inactivarPerfiles(int perfilesId, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(perfilesId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("Perfiles", "Inactivar", usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    Perfiles registroInactivar= entity.Perfiles.Where(x => x.id == perfilesId).SingleOrDefault();
                    registroInactivar.estado = "Inactivo";
                    registroInactivar.usuarioId = usuarioId;
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = perfilesId };
                    }
                    catch (Exception e)
                    {
                        return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                    }
                }
            }
            return new Result { error = "" };
        }

        public static Result activarPerfiles(int perfilesId, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(perfilesId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("Perfiles", "Inactivar", usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    Perfiles registroInactivar = entity.Perfiles.Where(x => x.id == perfilesId).SingleOrDefault();
                    registroInactivar.estado = "Activo";
                    registroInactivar.usuarioId = usuarioId;
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = perfilesId };
                    }
                    catch (Exception e)
                    {
                        return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                    }
                }
            }
            return new Result { error = "" };
        }
    }
}
