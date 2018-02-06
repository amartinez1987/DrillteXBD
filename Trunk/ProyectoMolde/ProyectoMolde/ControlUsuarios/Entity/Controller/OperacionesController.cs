using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class OperacionesController
    {
        public static List<OperacionesViewModel> getListaOperaciones()
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from operaciones in entity.Operaciones
                        select new OperacionesViewModel { id = operaciones.id, usuarioId = operaciones.usuarioId, nombreOperacion = operaciones.nombreOperacion, visualizaFormularioMenu = operaciones.visualizaFormularioMenu };
                return l.ToList();
            }
        }

      

        public static OperacionesViewModel getOperaciones(int id)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from operaciones in entity.Operaciones
                        where operaciones.id == id
                        select new OperacionesViewModel { id = operaciones.id, usuarioId = operaciones.usuarioId, nombreOperacion = operaciones.nombreOperacion, visualizaFormularioMenu = operaciones.visualizaFormularioMenu };
                return l.SingleOrDefault();
            }
        }

        public static Result guardarOperaciones(Operaciones registro)
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
                    result = ValidateSession.validarOperacionesForm("Operaciones", "Editar", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    int operacionesId = registro.id;
                    Operaciones registroEditar = entity.Operaciones.Where(x => x.id == operacionesId).SingleOrDefault();
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
                    result = ValidateSession.validarOperacionesForm("Operaciones", "Nuevo", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    entity.Operaciones.Add(registro);
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

        internal static OperacionesViewModel getViewModel(Operaciones o)
        {
            OperacionesViewModel op = new OperacionesViewModel();
            op.id = o.id;
            op.nombreOperacion = o.nombreOperacion;
            op.usuarioId = o.usuarioId;
            return op;
        }

        private static Result validarAtributos(Operaciones registro)
        {           
            if (registro.nombreOperacion == "")
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }
            return new Result() { error = "" };
        }
        public static bool existeRegistro(int operacionesId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.Operaciones.Where(x => x.id == operacionesId).Count() > 0)
                    return true;
                return false;
            }
        }
        public static Result eliminarOperaciones(int operacionesId, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(operacionesId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("Operaciones", "Eliminar", usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    Operaciones registroEliminar = entity.Operaciones.Where(x => x.id == operacionesId).SingleOrDefault();
                    entity.Operaciones.Remove(registroEliminar);
                    MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "Operaciones", "Eliminado", usuarioId, "AplicacionMolde");
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = operacionesId };
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
