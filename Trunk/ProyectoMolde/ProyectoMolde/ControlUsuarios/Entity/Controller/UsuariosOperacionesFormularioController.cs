using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class UsuariosOperacionesFormularioController
    {
        MoldeEntities entity = new MoldeEntities();
        public MoldeEntities getEntity()
        {
            return entity;
        }

        public List<UsuariosOperacionesFormularioViewModel> getListaUsuariosOperacionesFormulario()
        {

            var l = from usuariosoperacionesformulario in entity.UsuariosOperacionesFormulario
                    select new UsuariosOperacionesFormularioViewModel { id = usuariosoperacionesformulario.id, usuarioId = usuariosoperacionesformulario.usuarioId, operacionFormularioId = usuariosoperacionesformulario.operacionFormularioId, usuarioIdApl = usuariosoperacionesformulario.usuarioIdApl, nombreFormulario = usuariosoperacionesformulario.OperacionesFormulario.Formularios.nombreFormulario, nombreOperacion = usuariosoperacionesformulario.OperacionesFormulario.Operaciones.nombreOperacion, nombreUsuario  = usuariosoperacionesformulario.Usuarios.nombreUsuario };
            return l.ToList();

        }

        public List<UsuariosOperacionesFormularioViewModel> getListaUsuariosOperacionesFormulario(int usuarioId)
        {

            var l = from usuariosoperacionesformulario in entity.UsuariosOperacionesFormulario
                    where usuariosoperacionesformulario.usuarioId == usuarioId
                    select new UsuariosOperacionesFormularioViewModel { id = usuariosoperacionesformulario.id, usuarioId = usuariosoperacionesformulario.usuarioId, operacionFormularioId = usuariosoperacionesformulario.operacionFormularioId, usuarioIdApl = usuariosoperacionesformulario.usuarioIdApl, nombreFormulario = usuariosoperacionesformulario.OperacionesFormulario.Formularios.nombreFormulario, nombreOperacion = usuariosoperacionesformulario.OperacionesFormulario.Operaciones.nombreOperacion, nombreUsuario = usuariosoperacionesformulario.Usuarios.nombreUsuario };
            return l.ToList();

        }


        public List<OperacionesFormularioViewModel> getListaNoOperacionesFormularioUsuarios(int usuarioId, int aplicacionId = 0, int menuId = 0, string nombreFormulario = "")
        {

            var of = from operacionesFormulario in entity.OperacionesFormulario
                     where operacionesFormulario.Formularios.nombreFormulario.Contains(nombreFormulario == "" ? operacionesFormulario.Formularios.nombreFormulario : nombreFormulario)
                   && operacionesFormulario.Formularios.menuId == (menuId == 0 ? operacionesFormulario.Formularios.menuId : menuId)
                   && operacionesFormulario.Formularios.Menus.aplicacionWebId == (aplicacionId == 0 ? operacionesFormulario.Formularios.Menus.aplicacionWebId : aplicacionId)
                     select operacionesFormulario;

            var l = from usuariosoperacionesformulario in entity.UsuariosOperacionesFormulario
                    where usuariosoperacionesformulario.usuarioId == usuarioId
                    select usuariosoperacionesformulario;

            List<OperacionesFormulario> lstOf = of.ToList();
            List<OperacionesFormulario> lstOfR = l.Select(x => x.OperacionesFormulario).ToList();

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

        public UsuariosOperacionesFormularioViewModel getUsuariosOperacionesFormulario(int usuarioId)
        {

            var l = from usuariosoperacionesformulario in entity.UsuariosOperacionesFormulario
                    where usuariosoperacionesformulario.usuarioId == usuarioId
                    select new UsuariosOperacionesFormularioViewModel { id = usuariosoperacionesformulario.id, usuarioId = usuariosoperacionesformulario.usuarioId, operacionFormularioId = usuariosoperacionesformulario.operacionFormularioId, usuarioIdApl = usuariosoperacionesformulario.usuarioIdApl, nombreFormulario = usuariosoperacionesformulario.OperacionesFormulario.Formularios.nombreFormulario, nombreOperacion = usuariosoperacionesformulario.OperacionesFormulario.Operaciones.nombreOperacion, nombreUsuario = usuariosoperacionesformulario.Usuarios.nombreUsuario };
            return l.SingleOrDefault();

        }

        public List<UsuariosOperacionesFormulario> getUsuariosOperacionesFormularioEntity(int id)
        {
            var l = from usuariosOperacionesFormulario in entity.UsuariosOperacionesFormulario
                    where usuariosOperacionesFormulario.usuarioId == id
                    select usuariosOperacionesFormulario;
            return l.ToList();
        }

        public Result guardarUsuariosOperacionesFormulario(UsuariosOperacionesFormulario registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }

            if (existeRegistro(registro.id))
            {
                return result;
            }
            else
            {
                result = ValidateSession.validarOperacionesForm("UsuariosOperacionesFormulario", "Nuevo", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                entity.UsuariosOperacionesFormulario.Add(registro);
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

        public Result guardarUsuariosOperacionesFormulario(UsuariosOperacionesFormulario[] registro, int usuarioApliId)
        {
            Result result = new Result() { error = "" };

            result = new Result() { error = "" };
            result = ValidateSession.validarOperacionesForm("UsuariosOperacionesFormulario", "Eliminar", usuarioApliId);

            if (result.error != null && result.error != "")
            {
                return result;
            }

            result = ValidateSession.validarOperacionesForm("UsuariosOperacionesFormulario", "Nuevo", usuarioApliId);
            if (result.error != null && result.error != "")
            {
                return result;
            }

            int usuarioId = 0;
            if (registro.Count() > 0)
            {
                usuarioId = registro[0].usuarioId;
            }

            List<UsuariosOperacionesFormulario> lstPopF = getUsuariosOperacionesFormularioEntity(usuarioId);

            foreach (UsuariosOperacionesFormulario PopfR in lstPopF)
            {
                result.error += eliminarUsuariosOperacionesFormulario(PopfR.id, usuarioApliId).error;
            }

            if (result.error != null && result.error != "")
            {
                result.tipoAlerta = "warning";
                return result;
            }

            entity.UsuariosOperacionesFormulario.AddRange(registro);

            try
            {
                entity.SaveChanges();

                return new Result { error = result.error, id = 0 };
            }
            catch (Exception e)
            {
                return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
        }

        private Result validarAtributos(UsuariosOperacionesFormulario registro)
        {

            if (registro.usuarioId == 0)
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }

            if (registro.operacionFormularioId == 0)
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }


            return new Result() { error = "" };
        }
        public bool existeRegistro(int usuariosoperacionesformularioId)
        {

            if (entity.UsuariosOperacionesFormulario.Where(x => x.id == usuariosoperacionesformularioId).Count() > 0)
                return true;
            return false;

        }
        public Result eliminarUsuariosOperacionesFormulario(int usuariosoperacionesformularioId, int usuarioId)
        {

            if (existeRegistro(usuariosoperacionesformularioId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("UsuariosOperacionesFormulario", "Eliminar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                UsuariosOperacionesFormulario registroEliminar = entity.UsuariosOperacionesFormulario.Where(x => x.id == usuariosoperacionesformularioId).SingleOrDefault();
                entity.UsuariosOperacionesFormulario.Remove(registroEliminar);
                MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "UsuariosOperacionesFormulario", "Eliminado", usuarioId, "AplicacionMolde");
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = usuariosoperacionesformularioId };
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
