using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class EstadosCivilController
    {
        public static List<EstadosCivilViewModel> getListaEstadosCivil()
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from estadoscivil in entity.EstadosCivil
                        select new EstadosCivilViewModel { id = estadoscivil.id, usuarioId = estadoscivil.usuarioId, sigla = estadoscivil.sigla, descripcion = estadoscivil.descripcion };
                return l.ToList();
            }
        }

        public static EstadosCivilViewModel getEstadosCivil(int id)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {

                var l = from estadoscivil in entity.EstadosCivil
                        where estadoscivil.id == id
                        select new EstadosCivilViewModel { id = estadoscivil.id, usuarioId = estadoscivil.usuarioId, sigla = estadoscivil.sigla, descripcion = estadoscivil.descripcion };
                return l.SingleOrDefault();
            }
        }

        public static Result guardarEstadosCivil(EstadosCivil registro)
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
                    result = ValidateSession.validarOperacionesForm("EstadosCivil", "Editar", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    int estadoscivilId = registro.id;
                    EstadosCivil registroEditar = entity.EstadosCivil.Where(x => x.id == estadoscivilId).SingleOrDefault();
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
                    result = ValidateSession.validarOperacionesForm("EstadosCivil", "Nuevo", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    entity.EstadosCivil.Add(registro);
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

        private static Result validarAtributos(EstadosCivil registro)
        {


            if (registro.sigla == "")
            {
                return new Result { error = "Digite la sigla", tipoAlerta = "warning" };
            }
            if (registro.descripcion == "")
            {
                return new Result { error = "Digite la descripción", tipoAlerta = "warning" };
            }
            return new Result() { error = "" };
        }
        public static bool existeRegistro(int estadoscivilId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.EstadosCivil.Where(x => x.id == estadoscivilId).Count() > 0)
                    return true;
                return false;
            }
        }
        public static Result eliminarEstadosCivil(int estadoscivilId, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(estadoscivilId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("EstadosCivil", "Eliminar", usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    EstadosCivil registroEliminar = entity.EstadosCivil.Where(x => x.id == estadoscivilId).SingleOrDefault();
                    entity.EstadosCivil.Remove(registroEliminar);
                    MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "EstadosCivil", "Eliminado", usuarioId, "AplicacionMolde");
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = estadoscivilId };
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
