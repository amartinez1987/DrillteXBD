using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class GruposSanguineoController
    {
        public static List<GruposSanguineoViewModel> getListaGruposSanguineo()
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from grupossanguineo in entity.GruposSanguineo
                        select new GruposSanguineoViewModel { id = grupossanguineo.id, usuarioId = grupossanguineo.usuarioId, sigla = grupossanguineo.sigla, descripcion = grupossanguineo.descripcion };
                return l.ToList();
            }
        }

        public static GruposSanguineoViewModel getGruposSanguineo(int id)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from grupossanguineo in entity.GruposSanguineo
                        where grupossanguineo.id == id
                        select new GruposSanguineoViewModel { id = grupossanguineo.id, usuarioId = grupossanguineo.usuarioId, sigla = grupossanguineo.sigla, descripcion = grupossanguineo.descripcion };
                return l.SingleOrDefault();
            }
        }

        public static Result guardarGruposSanguineo(GruposSanguineo registro)
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
                    result = ValidateSession.validarOperacionesForm("GruposSanguineo", "Editar", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    int grupossanguineoId = registro.id;
                    GruposSanguineo registroEditar = entity.GruposSanguineo.Where(x => x.id == grupossanguineoId).SingleOrDefault();
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
                    result = ValidateSession.validarOperacionesForm("GruposSanguineo", "Nuevo", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    entity.GruposSanguineo.Add(registro);
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

        private static Result validarAtributos(GruposSanguineo registro)
        {          
            if (registro.sigla == "")
            {
                return new Result { error = "Digite la sigla", tipoAlerta = "warning" };
            }

            if (registro.descripcion == "")
            {
                return new Result { error = "Digite Descripciòn.", tipoAlerta = "warning" };
            }
            return new Result() { error = "" };
        }
        public static bool existeRegistro(int grupossanguineoId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.GruposSanguineo.Where(x => x.id == grupossanguineoId).Count() > 0)
                    return true;
                return false;
            }
        }
        public static Result eliminarGruposSanguineo(int grupossanguineoId, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(grupossanguineoId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("GruposSanguineo", "Eliminar", usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    GruposSanguineo registroEliminar = entity.GruposSanguineo.Where(x => x.id == grupossanguineoId).SingleOrDefault();
                    entity.GruposSanguineo.Remove(registroEliminar);
                    MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "GruposSanguineo", "Eliminado", usuarioId, "AplicacionMolde");
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = grupossanguineoId };
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
