using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class OperacionesFormularioController
    {
        MoldeEntities entity = new MoldeEntities();
        public MoldeEntities getEntity()
        {
            return entity;
        }
        public List<OperacionesFormularioViewModel> getListaOperacionesFormulario()
        {

            var l = from operacionesformulario in entity.OperacionesFormulario
                    select new OperacionesFormularioViewModel
                    {
                        id = operacionesformulario.id,
                        formularioId = operacionesformulario.formularioId,
                        operacionId = operacionesformulario.operacionId,
                        usuarioId = operacionesformulario.usuarioId,
                        descripcion = operacionesformulario.descripcion,
                        nombreOperacion = operacionesformulario.Operaciones.nombreOperacion,
                        nombreFormulario = operacionesformulario.Formularios.nombreFormulario

                    };
            return l.ToList();
        }

        public List<OperacionesFormularioViewModel> getListaOperacionesFormulario(int formularioId)
        {

            var l = from operacionesformulario in entity.OperacionesFormulario
                    where operacionesformulario.formularioId == formularioId
                    select new OperacionesFormularioViewModel
                    {
                        id = operacionesformulario.id,
                        formularioId = operacionesformulario.formularioId,
                        operacionId = operacionesformulario.operacionId,
                        nombreOperacion = operacionesformulario.Operaciones.nombreOperacion,
                        usuarioId = operacionesformulario.usuarioId,
                        descripcion = operacionesformulario.descripcion,
                        nombreFormulario = operacionesformulario.Formularios.nombreFormulario
                    };
            return l.ToList();
        }

        public List<OperacionesViewModel> getListaNoOperacionesFormulario(int formularioId)
        {

            var o = from operaciones in entity.Operaciones
                    select operaciones;

            var of = from operacionesFormulario in entity.OperacionesFormulario
                     where operacionesFormulario.formularioId == formularioId
                     select operacionesFormulario;

            List<Operaciones> lstO = o.ToList();
            List<Operaciones> lstOR = of.Select(x => x.Operaciones).ToList();

            foreach (Operaciones opR in lstOR)
            {
                lstO.Remove(opR);
            }

            List<OperacionesViewModel> lstOpViewModel = new List<OperacionesViewModel>();

            foreach (Operaciones op in lstO)
            {
                lstOpViewModel.Add(OperacionesController.getViewModel(op));
            }

            return lstOpViewModel;
        }

        public OperacionesFormularioViewModel getOperacionesFormulario(int id)
        {

            var l = from operacionesformulario in entity.OperacionesFormulario
                    where operacionesformulario.id == id
                    select new OperacionesFormularioViewModel
                    {
                        id = operacionesformulario.id,
                        formularioId = operacionesformulario.formularioId,
                        operacionId = operacionesformulario.operacionId,
                        usuarioId = operacionesformulario.usuarioId,
                        descripcion = operacionesformulario.descripcion,
                        nombreOperacion = operacionesformulario.Operaciones.nombreOperacion,
                        nombreFormulario = operacionesformulario.Formularios.nombreFormulario
                    };
            return l.SingleOrDefault();

        }

        public List<OperacionesFormulario> getOperacionesFormularioEntity(int id)
        {

            var l = from operacionesformulario in entity.OperacionesFormulario
                    where operacionesformulario.formularioId == id
                    select operacionesformulario;
            return l.ToList();

        }

        public static OperacionesFormularioViewModel getViewModel(OperacionesFormulario opF)
        {
            return new OperacionesFormularioViewModel()
            {
                id = opF.id,
                formularioId = opF.formularioId,
                operacionId = opF.operacionId,
                nombreOperacion = opF.Operaciones.nombreOperacion,
                descripcion = opF.descripcion,
                usuarioId = opF.usuarioId,
                nombreFormulario = opF.Formularios.nombreFormulario
            };
        }

        public Result guardarOperacionesFormulario(OperacionesFormulario registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }

            result = ValidateSession.validarOperacionesForm("OperacionesFormulario", "Nuevo", registro.usuarioId);
            if (result.error != null && result.error != "")
            {
                return result;
            }
            string nombreFormulario = new FormulariosController().getFormularios(registro.formularioId.Value).nombreFormulario;
            string operacion = OperacionesController.getOperaciones(registro.operacionId.Value).nombreOperacion;
            registro.descripcion = operacion + " " + nombreFormulario;
            entity.OperacionesFormulario.Add(registro);
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

        public Result guardarOperacionesFormulario(OperacionesFormulario[] registro, int usuarioId)
        {
            Result result = new Result() { error = "" };
            int formularioId = 0;
            if (registro.Count() > 0)
            {
                formularioId = registro[0].formularioId.Value;
            }

            List<OperacionesFormulario> lstOpFor = getOperacionesFormularioEntity(formularioId);
            foreach (OperacionesFormulario opfR in lstOpFor)
            {
                result.error += eliminarOperacionesFormulario(opfR.id, usuarioId).error;
            }

            if (result.error != null && result.error != "")
            {
                result.tipoAlerta = "warning";
                return result;
            }

            foreach (OperacionesFormulario opf in registro)
            {
                string nombreFormulario = new FormulariosController().getFormularios(opf.formularioId.Value).nombreFormulario;
                string operacion = OperacionesController.getOperaciones(opf.operacionId.Value).nombreOperacion;
                opf.descripcion = operacion + " " + nombreFormulario;
                opf.usuarioId = usuarioId;
                result.error += guardarOperacionesFormulario(opf).error;
            }

            if (result.error != null && result.error != "")
            {
                result.tipoAlerta = "warning";
                return result;
            }

            return result;
        }

        private static Result validarAtributos(OperacionesFormulario registro)
        {

            if (registro.formularioId == 0)
            {
                return new Result { error = "Seleccione formulario", tipoAlerta = "warning" };
            }
            if (registro.operacionId == 0)
            {
                return new Result { error = "Seleccione la Operación", tipoAlerta = "warning" };
            }

            return new Result() { error = "" };
        }
        public bool existeRegistro(int operacionesformularioId)
        {
            if (entity.OperacionesFormulario.Where(x => x.id == operacionesformularioId).Count() > 0)
                return true;
            return false;
        }
        public Result eliminarOperacionesFormulario(int operacionesformularioId, int usuarioId)
        {
            if (existeRegistro(operacionesformularioId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("OperacionesFormulario", "Eliminar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                OperacionesFormulario registroEliminar = entity.OperacionesFormulario.Where(x => x.id == operacionesformularioId).SingleOrDefault();
                entity.OperacionesFormulario.Remove(registroEliminar);
                MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "OperacionesFormulario", "Eliminado", usuarioId, "AplicacionMolde");
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = operacionesformularioId };
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
