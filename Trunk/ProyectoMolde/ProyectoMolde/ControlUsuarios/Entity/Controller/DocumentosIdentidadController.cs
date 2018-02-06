using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class DocumentosIdentidadController
    {
        public static List<DocumentosIdentidadViewModel> getListaDocumentosIdentidad()
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from documentosidentidad in entity.DocumentosIdentidad
                        select new DocumentosIdentidadViewModel { id = documentosidentidad.id, usuarioId = documentosidentidad.usuarioId, sigla = documentosidentidad.sigla, descripcion = documentosidentidad.descripcion };
                return l.ToList();
            }
        }

        public static DocumentosIdentidadViewModel getDocumentosIdentidad(int id)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from documentosidentidad in entity.DocumentosIdentidad
                        where documentosidentidad.id == id
                        select new DocumentosIdentidadViewModel { id = documentosidentidad.id, usuarioId = documentosidentidad.usuarioId, sigla = documentosidentidad.sigla, descripcion = documentosidentidad.descripcion };
                return l.SingleOrDefault();
            }
        }

        public static Result guardarDocumentosIdentidad(DocumentosIdentidad registro)
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
                    result = ValidateSession.validarOperacionesForm("DocumentosIdentidad", "Editar", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    int documentosidentidadId = registro.id;
                    DocumentosIdentidad registroEditar = entity.DocumentosIdentidad.Where(x => x.id == documentosidentidadId).SingleOrDefault();
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
                    result = ValidateSession.validarOperacionesForm("DocumentosIdentidad", "Nuevo", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    entity.DocumentosIdentidad.Add(registro);
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

        private static Result validarAtributos(DocumentosIdentidad registro)
        {
            if (registro.sigla == "")
            {
                return new Result { error = "Digite la sigla.", tipoAlerta = "warning" };
            }

            if (registro.descripcion == "")
            {
                return new Result { error = "Digite la descripción.", tipoAlerta = "warning" };
            }
            return new Result() { error = "" };
        }
        public static bool existeRegistro(int documentosidentidadId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.DocumentosIdentidad.Where(x => x.id == documentosidentidadId).Count() > 0)
                    return true;
                return false;
            }
        }
        public static Result eliminarDocumentosIdentidad(int documentosidentidadId, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(documentosidentidadId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("DocumentosIdentidad", "Eliminar", usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    DocumentosIdentidad registroEliminar = entity.DocumentosIdentidad.Where(x => x.id == documentosidentidadId).SingleOrDefault();
                    entity.DocumentosIdentidad.Remove(registroEliminar);
                    MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "DocumentosIdentidad", "Eliminado", usuarioId, "AplicacionMolde");
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = documentosidentidadId };
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
