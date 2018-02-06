using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class PerfilesOperacionesFormularioController
    {
        MoldeEntities entity = new MoldeEntities();
        public MoldeEntities getEntity()
        {
            return entity;
        }

        public List<PerfilesOperacionesFormularioViewModel> getListaPerfilesOperacionesFormulario()
        {

            var l = from perfilesoperacionesformulario in entity.PerfilesOperacionesFormulario
                    select new PerfilesOperacionesFormularioViewModel
                    {
                        id = perfilesoperacionesformulario.id,
                        operacionFormularioId = perfilesoperacionesformulario.operacionFormularioId,
                        nombreFormulario = perfilesoperacionesformulario.OperacionesFormulario.Formularios.nombreFormulario,
                        nombreOperacion = perfilesoperacionesformulario.OperacionesFormulario.Operaciones.nombreOperacion,
                        perfilId = perfilesoperacionesformulario.perfilId,
                        nombrePerfil = perfilesoperacionesformulario.Perfiles.nombrePerfil,
                        usuarioId = perfilesoperacionesformulario.usuarioId
                    };
            return l.ToList();

        }
        public List<PerfilesOperacionesFormularioViewModel> getListaPerfilesOperacionesFormulario(int pefilId)
        {

            var l = from perfilesoperacionesformulario in entity.PerfilesOperacionesFormulario
                    where perfilesoperacionesformulario.perfilId == pefilId

                    select new PerfilesOperacionesFormularioViewModel
                    {
                        id = perfilesoperacionesformulario.id,
                        operacionFormularioId = perfilesoperacionesformulario.operacionFormularioId,
                        nombreFormulario = perfilesoperacionesformulario.OperacionesFormulario.Formularios.nombreFormulario,
                        nombreOperacion = perfilesoperacionesformulario.OperacionesFormulario.Operaciones.nombreOperacion,
                        perfilId = perfilesoperacionesformulario.perfilId,
                        nombrePerfil = perfilesoperacionesformulario.Perfiles.nombrePerfil,
                        usuarioId = perfilesoperacionesformulario.usuarioId
                    };
            return l.ToList();

        }

        public List<OperacionesFormularioViewModel> getListaNoOperacionesFormularioPerfil(int perfilId, int aplicacionId = 0, int menuId = 0, string nombreFormulario = "")
        {

            var of = from operacionesFormulario in entity.OperacionesFormulario
                     where operacionesFormulario.Formularios.nombreFormulario.Contains(nombreFormulario == "" ? operacionesFormulario.Formularios.nombreFormulario : nombreFormulario)
                   && operacionesFormulario.Formularios.menuId == (menuId == 0 ? operacionesFormulario.Formularios.menuId : menuId)
                   && operacionesFormulario.Formularios.Menus.aplicacionWebId == (aplicacionId == 0 ? operacionesFormulario.Formularios.Menus.aplicacionWebId : aplicacionId)
                     select operacionesFormulario;

            var ofp = from perfilesOperacionesFormulario in entity.PerfilesOperacionesFormulario
                      where perfilesOperacionesFormulario.perfilId == perfilId
                      select perfilesOperacionesFormulario;

            List<OperacionesFormulario> lstOf = of.ToList();
            List<OperacionesFormulario> lstOfR = ofp.Select(x => x.OperacionesFormulario).ToList();

            foreach (OperacionesFormulario opFR in lstOfR)
            {
                lstOf.Remove(opFR);
            }

            List<OperacionesFormularioViewModel> lstOpFViewModel = new List<OperacionesFormularioViewModel>();

            foreach (OperacionesFormulario opF in lstOf)
            {
                lstOpFViewModel.Add(OperacionesFormularioController.getViewModel(opF));
            }

            return lstOpFViewModel;
        }

        public PerfilesOperacionesFormularioViewModel getPerfilesOperacionesFormulario(int perfilId)
        {

            var l = from perfilesoperacionesformulario in entity.PerfilesOperacionesFormulario
                    where perfilesoperacionesformulario.perfilId == perfilId
                    select new PerfilesOperacionesFormularioViewModel
                    {
                        id = perfilesoperacionesformulario.id,
                        operacionFormularioId = perfilesoperacionesformulario.operacionFormularioId,
                        nombreFormulario = perfilesoperacionesformulario.OperacionesFormulario.Formularios.nombreFormulario,
                        nombreOperacion = perfilesoperacionesformulario.OperacionesFormulario.Operaciones.nombreOperacion,
                        perfilId = perfilesoperacionesformulario.perfilId,
                        nombrePerfil = perfilesoperacionesformulario.Perfiles.nombrePerfil,
                        usuarioId = perfilesoperacionesformulario.usuarioId
                    };

            return l.SingleOrDefault();

        }

        public List<PerfilesOperacionesFormulario> getPerfilesOperacionesFormularioEntity(int id)
        {
            var l = from perfilesoperacionesformulario in entity.PerfilesOperacionesFormulario
                    where perfilesoperacionesformulario.perfilId == id
                    select perfilesoperacionesformulario;
            return l.ToList();
        }

        public Result guardarPerfilesOperacionesFormulario(PerfilesOperacionesFormulario registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }


            if (existeRegistro(registro.id))
            {
                result = ValidateSession.validarOperacionesForm("PerfilesOperacionesFormulario", "Editar", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                int perfilesoperacionesformularioId = registro.id;
                PerfilesOperacionesFormulario registroEditar = entity.PerfilesOperacionesFormulario.Where(x => x.id == perfilesoperacionesformularioId).SingleOrDefault();
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
                result = ValidateSession.validarOperacionesForm("PerfilesOperacionesFormulario", "Nuevo", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                entity.PerfilesOperacionesFormulario.Add(registro);
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

        public Result guardarPerfilesOperacionesFormulario(PerfilesOperacionesFormulario[] registro, int usuarioId)
        {
            Result result = new Result() { error = "" };
            int perfilId = 0;
            if (registro.Count() > 0)
            {
                perfilId = registro[0].perfilId.Value;
            }

            List<PerfilesOperacionesFormulario> lstPopF = getPerfilesOperacionesFormularioEntity(perfilId);
            foreach (PerfilesOperacionesFormulario PopfR in lstPopF)
            {
                result.error += eliminarPerfilesOperacionesFormulario(PopfR.id, usuarioId).error;
            }

            if (result.error != null && result.error != "")
            {
                result.tipoAlerta = "warning";
                return result;
            }

            foreach (PerfilesOperacionesFormulario pOpf in registro)
            {
                pOpf.usuarioId = usuarioId;
                result.error += guardarPerfilesOperacionesFormulario(pOpf).error;
            }

            if (result.error != null && result.error != "")
            {
                result.tipoAlerta = "warning";
                return result;
            }

            return result;

        }


        private Result validarAtributos(PerfilesOperacionesFormulario registro)
        {

            if (registro.operacionFormularioId == 0)
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }
            if (registro.perfilId == 0)
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }

            return new Result() { error = "" };
        }
        public bool existeRegistro(int perfilesoperacionesformularioId)
        {

            if (entity.PerfilesOperacionesFormulario.Where(x => x.id == perfilesoperacionesformularioId).Count() > 0)
                return true;
            return false;

        }
        public Result eliminarPerfilesOperacionesFormulario(int perfilesoperacionesformularioId, int usuarioId)
        {

            if (existeRegistro(perfilesoperacionesformularioId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("PerfilesOperacionesFormulario", "Eliminar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                PerfilesOperacionesFormulario registroEliminar = entity.PerfilesOperacionesFormulario.Where(x => x.id == perfilesoperacionesformularioId).SingleOrDefault();
                entity.PerfilesOperacionesFormulario.Remove(registroEliminar);
                MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "PerfilesOperacionesFormulario", "Eliminado", usuarioId, "AplicacionMolde");
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = perfilesoperacionesformularioId };
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
