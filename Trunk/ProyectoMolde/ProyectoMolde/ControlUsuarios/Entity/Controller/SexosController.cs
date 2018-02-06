using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class SexosController
    {
        public static List<SexosViewModel> getListaSexos()
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from sexos in entity.Sexos
                        select new SexosViewModel { id = sexos.id, usuarioId = sexos.usuarioId, sigla = sexos.sigla, descripcion = sexos.descripcion };
                return l.ToList();
            }
        }

        public static SexosViewModel getSexos(int id)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from sexos in entity.Sexos
                        where sexos.id == id
                        select new SexosViewModel { id = sexos.id, usuarioId = sexos.usuarioId, sigla = sexos.sigla, descripcion = sexos.descripcion };
                return l.SingleOrDefault();
            }
        }

        public static Result guardarSexos(Sexos registro)
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
                    result = ValidateSession.validarOperacionesForm("Sexos", "Editar", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    int sexosId = registro.id;
                    Sexos registroEditar = entity.Sexos.Where(x => x.id == sexosId).SingleOrDefault();
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
                    result = ValidateSession.validarOperacionesForm("Sexos", "Nuevo", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    entity.Sexos.Add(registro);
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

        private static Result validarAtributos(Sexos registro)
        {
           
            if (registro.sigla == "")
            {
                return new Result { error = "Digite la sigla.", tipoAlerta = "warning" };
            }
            if (registro.descripcion == "")
            {
                return new Result { error = "Digite la descrición.", tipoAlerta = "warning" };
            }
            return new Result() { error = "" };
        }
        public static bool existeRegistro(int sexosId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.Sexos.Where(x => x.id == sexosId).Count() > 0)
                    return true;
                return false;
            }
        }
        public static Result eliminarSexos(int sexosId, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(sexosId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("Sexos", "Eliminar", usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    Sexos registroEliminar = entity.Sexos.Where(x => x.id == sexosId).SingleOrDefault();
                    entity.Sexos.Remove(registroEliminar);
                    MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "Sexos", "Eliminado", usuarioId, "AplicacionMolde");
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = sexosId };
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
