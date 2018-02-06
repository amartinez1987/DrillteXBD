using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class AplicacionesWebController
    {
        
        public static List<AplicacionesWebViewModel> getListaAplicacionesWeb()
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from aplicacionesweb in entity.AplicacionesWeb
                        select new AplicacionesWebViewModel { id = aplicacionesweb.id, nombre = aplicacionesweb.nombre, descripcion = aplicacionesweb.descripcion };
                return l.ToList();
            }
        }

        public static AplicacionesWebViewModel getAplicacionesWeb(int id)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from aplicacionesweb in entity.AplicacionesWeb
                        where aplicacionesweb.id == id
                        select new AplicacionesWebViewModel { id = aplicacionesweb.id, nombre = aplicacionesweb.nombre, descripcion = aplicacionesweb.descripcion };
                return l.SingleOrDefault();
            }
        }

        public static Result guardarAplicacionesWeb(AplicacionesWeb registro)
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
                    result = ValidateSession.validarOperacionesForm("aplicacionesWeb", "Nuevo", registro.usuarioId);

                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }

                    int aplicacioneswebId = registro.id;
                    AplicacionesWeb registroEditar = entity.AplicacionesWeb.Where(x => x.id == aplicacioneswebId).SingleOrDefault();
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
                    result = ValidateSession.validarOperacionesForm("aplicacionesWeb", "Editar", registro.usuarioId);

                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }

                    entity.AplicacionesWeb.Add(registro);
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

        private static Result validarAtributos(AplicacionesWeb registro)
        {
            if (registro.nombre == "")
            {
                return new Result { error = "El nombre no debe ir vacío.", tipoAlerta = "warning" };
            }
            if (registro.descripcion == "")
            {
                return new Result { error = "La descripción no debe ir vacío.", tipoAlerta = "warning" };
            }

            return new Result() { error = "" };
        }

        public static Result eliminarAplicacionesWeb(int aplicacioneswebId, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(aplicacioneswebId))
                {
                    Result result = new Result() { error = "" };

                    result = ValidateSession.validarOperacionesForm("aplicacionesWeb", "Eliminar", usuarioId);

                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }

                    AplicacionesWeb registroEliminar = entity.AplicacionesWeb.Where(x => x.id == aplicacioneswebId).SingleOrDefault();
                    entity.AplicacionesWeb.Remove(registroEliminar);
                    MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "AplicacionesWeb", "Eliminado", usuarioId, "AplicacionMolde");
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
            }
            return new Result { error = "" };
        }


        public static bool existeRegistro(int aplicacioneswebId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.AplicacionesWeb.Where(x => x.id == aplicacioneswebId).Count() > 0)
                    return true;
                return false;
            }
        }
    }
}
