using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class DepartamentosController
    {
        public static List<DepartamentosViewModel> getListaDepartamentos()
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from departamentos in entity.Departamentos
                        select new DepartamentosViewModel { id = departamentos.id, usuarioId = departamentos.usuarioId, nombre = departamentos.nombre , codigoDane = departamentos.codigoDane };
                return l.ToList();
            }
        }

        public static DepartamentosViewModel getDepartamentos(int id)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from departamentos in entity.Departamentos
                        where departamentos.id == id
                        select new DepartamentosViewModel { id = departamentos.id, usuarioId = departamentos.usuarioId, nombre = departamentos.nombre, codigoDane = departamentos.codigoDane };
                return l.SingleOrDefault();
            }
        }

        public static Result guardarDepartamentos(Departamentos registro)
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
                    result = ValidateSession.validarOperacionesForm("Departamentos", "Editar", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    int departamentosId = registro.id;
                    Departamentos registroEditar = entity.Departamentos.Where(x => x.id == departamentosId).SingleOrDefault();
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
                    result = ValidateSession.validarOperacionesForm("Departamentos", "Nuevo", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    entity.Departamentos.Add(registro);
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

        private static Result validarAtributos(Departamentos registro)
        {          
            if (registro.nombre == "")
            {
                return new Result { error = "Digite el nombre del departamento.", tipoAlerta = "warning" };
            }

            if (registro.codigoDane == "")
            {
                return new Result { error = "Digite el còdigo DANE del departamento.", tipoAlerta = "warning" };
            }
            return new Result() { error = "" };
        }
        public static bool existeRegistro(int departamentosId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.Departamentos.Where(x => x.id == departamentosId).Count() > 0)
                    return true;
                return false;
            }
        }
        public static Result eliminarDepartamentos(int departamentosId, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(departamentosId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("Departamentos", "Eliminar", usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    Departamentos registroEliminar = entity.Departamentos.Where(x => x.id == departamentosId).SingleOrDefault();
                    entity.Departamentos.Remove(registroEliminar);
                    MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "Departamentos", "Eliminado", usuarioId, "AplicacionMolde");
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = departamentosId };
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
