using ControlUsuarios.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUsuarios.Entity.Controller
{
    public class AnexoController
    {
        MoldeEntities entity = new MoldeEntities();

        public MoldeEntities getEntity()
        {
            return entity;
        }
        public List<AnexosViewModel> getListaAnexos()
        {
            var l = from anexos in entity.Anexos
                    select new AnexosViewModel { anexo = anexos.anexo, id = anexos.id, opcionMaestroAnexoId = anexos.opcionMaestroAnexoId, registroTablaId = anexos.registroTablaId, usuarioId = anexos.usuarioId  , consecutivosTemporal = anexos.consecutivoTemporal, nombreOpcionMaestroAnexo = anexos.OpcionesMaestroAnexos.nombreOpcion, nombreAnexo = anexos.nombreAnexo};
            return l.ToList();
        }
        public List<AnexosViewModel> getListaAnexosPorConsecutivoTemporal(string consecutivoTemporal)
        {
            var l = from anexos in entity.Anexos
                    where anexos.consecutivoTemporal == consecutivoTemporal
                    select new AnexosViewModel { anexo = anexos.anexo, id = anexos.id, opcionMaestroAnexoId = anexos.opcionMaestroAnexoId, registroTablaId = anexos.registroTablaId, usuarioId = anexos.usuarioId, consecutivosTemporal = anexos.consecutivoTemporal, nombreOpcionMaestroAnexo = anexos.OpcionesMaestroAnexos.nombreOpcion, nombreAnexo = anexos.nombreAnexo };
            return l.ToList();
        }

        public AnexosViewModel getAnexos(int id)
        {
            var l = from anexos in entity.Anexos
                    where anexos.id == id
                    select new AnexosViewModel { anexo = anexos.anexo, id = anexos.id, opcionMaestroAnexoId = anexos.opcionMaestroAnexoId, registroTablaId = anexos.registroTablaId, usuarioId = anexos.usuarioId, consecutivosTemporal = anexos.consecutivoTemporal, nombreOpcionMaestroAnexo = anexos.OpcionesMaestroAnexos.nombreOpcion, nombreAnexo = anexos.nombreAnexo };
            return l.FirstOrDefault();
        }

        public Result guardarAnexos(Anexos registro)
        {
            Result result = new Result() { error = "" };

            result = validarAtributos(registro);

            if (result.error != null && result.error != "")
            {
                return result;
            }


            if (existeRegistro(registro.id))
            {
                result = ValidateSession.validarOperacionesForm("Anexos", "Editar", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }

                int anexosId = registro.id;
                Anexos registroEditar = entity.Anexos.Where(x => x.id == anexosId).SingleOrDefault();
                entity.Entry(registroEditar).CurrentValues.SetValues(registro);
                try
                {
                    entity.SaveChanges();
                    return new Result { error = "" , id = registro.id};
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }
            }
            else
            {
                result = ValidateSession.validarOperacionesForm("Anexos", "Nuevo", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                entity.Anexos.Add(registro);
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

        private bool existeRegistro(int anexosId)
        {
            if (entity.Anexos.Where(x => x.id == anexosId).Count() > 0)
                return true;
            return false;
        }

        private Result validarAtributos(Anexos registro)
        {
            if (registro.opcionMaestroAnexoId == 0)
            {
                return new Result { error = "Seleccione tipo anexo.", tipoAlerta = "warning" };
            }
            
            return new Result() { error = "" };
        }
    }
}