using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class OpcionesMaestroAnexosController
    {
        MoldeEntities entity = new MoldeEntities();
        private MoldeEntities GetEntity()
        {
            return entity;
        }

        public List<OpcionesMaestroAnexosViewModel> getListaOpcionesMaestroAnexosPorMaestroAnexoId(int maestroAnexoId)
        {

            var l = from opcionesmaestroanexos in entity.OpcionesMaestroAnexos
                    where opcionesmaestroanexos.maestroAnexosId == maestroAnexoId
                    select new OpcionesMaestroAnexosViewModel { id = opcionesmaestroanexos.id, maestroAnexosId = opcionesmaestroanexos.maestroAnexosId, usuarioId = opcionesmaestroanexos.usuarioId, nombreOpcion = opcionesmaestroanexos.nombreOpcion, nombreMaestroAnexo = opcionesmaestroanexos.MaestroAnexos.tabla };
            return l.ToList();

        }

        public List<OpcionesMaestroAnexosViewModel> getListaOpcionesMaestroAnexosPorMaestroNombreTabla(string tabla)
        {

            var l = from opcionesmaestroanexos in entity.OpcionesMaestroAnexos
                    where opcionesmaestroanexos.MaestroAnexos.tabla == tabla
                    select new OpcionesMaestroAnexosViewModel { id = opcionesmaestroanexos.id, maestroAnexosId = opcionesmaestroanexos.maestroAnexosId, usuarioId = opcionesmaestroanexos.usuarioId, nombreOpcion = opcionesmaestroanexos.nombreOpcion, nombreMaestroAnexo = opcionesmaestroanexos.MaestroAnexos.tabla };
            return l.ToList();

        }

        public List<OpcionesMaestroAnexosViewModel> getListaOpcionesMaestroAnexos()
        {

            var l = from opcionesmaestroanexos in entity.OpcionesMaestroAnexos
                    select new OpcionesMaestroAnexosViewModel { id = opcionesmaestroanexos.id, maestroAnexosId = opcionesmaestroanexos.maestroAnexosId, usuarioId = opcionesmaestroanexos.usuarioId, nombreOpcion = opcionesmaestroanexos.nombreOpcion, nombreMaestroAnexo = opcionesmaestroanexos.MaestroAnexos.tabla };
            return l.ToList();

        }

        public OpcionesMaestroAnexosViewModel getOpcionesMaestroAnexos(int id)
        {
            var l = from opcionesmaestroanexos in entity.OpcionesMaestroAnexos
                    where opcionesmaestroanexos.id == id
                    select new OpcionesMaestroAnexosViewModel { id = opcionesmaestroanexos.id, maestroAnexosId = opcionesmaestroanexos.maestroAnexosId, usuarioId = opcionesmaestroanexos.usuarioId, nombreOpcion = opcionesmaestroanexos.nombreOpcion, nombreMaestroAnexo = opcionesmaestroanexos.MaestroAnexos.tabla  };
            return l.SingleOrDefault();
        }

        public Result guardarOpcionesMaestroAnexos(OpcionesMaestroAnexos registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }


            if (existeRegistro(registro.id))
            {
                result = ValidateSession.validarOperacionesForm("OpcionesMaestroAnexos", "Editar", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                int opcionesmaestroanexosId = registro.id;
                OpcionesMaestroAnexos registroEditar = entity.OpcionesMaestroAnexos.Where(x => x.id == opcionesmaestroanexosId).SingleOrDefault();
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
                result = ValidateSession.validarOperacionesForm("OpcionesMaestroAnexos", "Nuevo", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                entity.OpcionesMaestroAnexos.Add(registro);
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

        private Result validarAtributos(OpcionesMaestroAnexos registro)
        {

            if (registro.maestroAnexosId == 0)
            {
                return new Result { error = "Seleccione el maestro anexo asociado.", tipoAlerta = "warning" };
            }

            if (registro.nombreOpcion == "")
            {
                return new Result { error = "Digite el nombre de la opción.", tipoAlerta = "warning" };
            }

            return new Result() { error = "" };
        }

        public bool existeRegistro(int opcionesmaestroanexosId)
        {

            if (entity.OpcionesMaestroAnexos.Where(x => x.id == opcionesmaestroanexosId).Count() > 0)
                return true;
            return false;

        }

        public Result eliminarOpcionesMaestroAnexos(int opcionesmaestroanexosId, int usuarioId)
        {
            if (existeRegistro(opcionesmaestroanexosId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("OpcionesMaestroAnexos", "Eliminar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                OpcionesMaestroAnexos registroEliminar = entity.OpcionesMaestroAnexos.Where(x => x.id == opcionesmaestroanexosId).SingleOrDefault();
                entity.OpcionesMaestroAnexos.Remove(registroEliminar);
                MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "OpcionesMaestroAnexos", "Eliminado", usuarioId, "AplicacionMolde");
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = opcionesmaestroanexosId };
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
