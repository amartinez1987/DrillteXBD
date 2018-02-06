using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;

namespace ControlUsuarios.Entity.Controller
{
    public class MaestroAnexosController
    {
        MoldeEntities entity = new MoldeEntities();
        public MoldeEntities getEntity()
        {
            return entity;
        }

        public List<MaestroAnexosViewModel> getListaMaestroAnexos()
        {
            var l = from maestroanexos in entity.MaestroAnexos
                    select new MaestroAnexosViewModel { id = maestroanexos.id, tabla = maestroanexos.tabla, usuarioId = maestroanexos.usuarioId, aplicacionId = maestroanexos.aplicacionId };
            return l.ToList();
        }

        public MaestroAnexosViewModel getMaestroAnexos(int id)
        {
            var l = from maestroanexos in entity.MaestroAnexos
                    where maestroanexos.id == id
                    select new MaestroAnexosViewModel { id = maestroanexos.id, tabla = maestroanexos.tabla, usuarioId = maestroanexos.usuarioId, aplicacionId = maestroanexos.aplicacionId };
            return l.SingleOrDefault();
        }

        public MaestroAnexosViewModel getMaestroAnexosTabla(string nombreTabla)
        {
            var l = from maestroanexos in entity.MaestroAnexos
                    where maestroanexos.tabla == nombreTabla
                    select new MaestroAnexosViewModel { id = maestroanexos.id, tabla = maestroanexos.tabla, usuarioId = maestroanexos.usuarioId, aplicacionId  = maestroanexos.aplicacionId };
            return l.SingleOrDefault();
        }

        public Result guardarMaestroAnexos(MaestroAnexos registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }


            if (existeRegistro(registro.id))
            {
                result = ValidateSession.validarOperacionesForm("MaestroAnexos", "Editar", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                int maestroanexosId = registro.id;
                MaestroAnexos registroEditar = entity.MaestroAnexos.Where(x => x.id == maestroanexosId).SingleOrDefault();
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
                result = ValidateSession.validarOperacionesForm("MaestroAnexos", "Nuevo", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }

                ConsecutivosTemporales newConsecutivosTemporales = new ConsecutivosTemporales() { consecutivo = 0, MaestroAnexos = registro, id = 0 };
                registro.ConsecutivosTemporales.Add(newConsecutivosTemporales);
                entity.MaestroAnexos.Add(registro);
                

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

        private Result validarAtributos(MaestroAnexos registro)
        {

            if (registro.tabla == "")
            {
                return new Result { error = "Ingrese el nombre de la tabla.", tipoAlerta = "warning" };
            }

            return new Result() { error = "" };
        }
        public bool existeRegistro(int maestroanexosId)
        {

            if (entity.MaestroAnexos.Where(x => x.id == maestroanexosId).Count() > 0)
                return true;
            return false;

        }
        public Result eliminarMaestroAnexos(int maestroanexosId, int usuarioId)
        {

            if (existeRegistro(maestroanexosId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("MaestroAnexos", "Eliminar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                MaestroAnexos registroEliminar = entity.MaestroAnexos.Where(x => x.id == maestroanexosId).SingleOrDefault();
                entity.MaestroAnexos.Remove(registroEliminar);
                MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "MaestroAnexos", "Eliminado", usuarioId, "AplicacionMolde");
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = maestroanexosId };
                }
                catch (DbUpdateException enEx)
                {
                    var sqlex = enEx.InnerException.InnerException as SqlException;

                    if (sqlex != null)
                    {
                        switch (sqlex.Number)
                        {
                            case 547:
                                return new Result { error = "No se puede eliminar el registro debido a que tiene elementos asociados.", id = 0, tipoAlerta = "warning" };                            

                            default: return new Result { error = enEx.Message, id = 0, tipoAlerta = "warning" };
                        }
                    }
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }
            }
            return new Result { error = "" };
        }
    }
}
