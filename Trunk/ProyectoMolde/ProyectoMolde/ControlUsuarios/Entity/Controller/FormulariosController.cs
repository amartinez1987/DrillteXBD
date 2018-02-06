using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class FormulariosController
    {
        MoldeEntities entity = new MoldeEntities();

        public MoldeEntities getEntity()
        {
            return entity;
        }
        public List<FormulariosViewModel> getListaFormularios(string valorBuscado)
        {
            switch (valorBuscado)
            {
                case "":
                    var l = from formularios in entity.Formularios
                            select new FormulariosViewModel { id = formularios.id, menuId = formularios.menuId, nombreMenu = formularios.Menus.nombreMenu, usuarioId = formularios.usuarioId, indexVisibilidad = formularios.indexVisibilidad, esVisible = formularios.esVisible, nombreFormulario = formularios.nombreFormulario, urlFormulario = formularios.urlFormulario, nombreMostrar = formularios.nombreMostrar, estados = formularios.estados, iconOpcion = formularios.iconOpcion };
                    return l.ToList();
                    
                default:
                    var lf = from formularios in entity.Formularios
                            where formularios.nombreFormulario.Contains(valorBuscado) || formularios.Menus.nombreMenu.Contains(valorBuscado) || formularios.estados.Contains(valorBuscado)
                            select new FormulariosViewModel { id = formularios.id, menuId = formularios.menuId, nombreMenu = formularios.Menus.nombreMenu, usuarioId = formularios.usuarioId, indexVisibilidad = formularios.indexVisibilidad, esVisible = formularios.esVisible, nombreFormulario = formularios.nombreFormulario, urlFormulario = formularios.urlFormulario, nombreMostrar = formularios.nombreMostrar, estados = formularios.estados, iconOpcion = formularios.iconOpcion };
                    return lf.ToList();
                    

            }
           
        }

        public FormulariosViewModel getFormularios(int id)
        {

            var l = from formularios in entity.Formularios
                    where formularios.id == id
                    select new FormulariosViewModel { id = formularios.id, menuId = formularios.menuId, nombreMenu = formularios.Menus.nombreMenu, usuarioId = formularios.usuarioId, indexVisibilidad = formularios.indexVisibilidad, esVisible = formularios.esVisible, nombreFormulario = formularios.nombreFormulario, urlFormulario = formularios.urlFormulario, nombreMostrar = formularios.nombreMostrar, estados = formularios.estados, iconOpcion = formularios.iconOpcion };
            return l.SingleOrDefault();

        }

        public Result guardarFormularios(Formularios registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }


            if (existeRegistro(registro.id))
            {
                result = ValidateSession.validarOperacionesForm("Formularios", "Editar", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                int formulariosId = registro.id;
                Formularios registroEditar = entity.Formularios.Where(x => x.id == formulariosId).SingleOrDefault();
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
                result = ValidateSession.validarOperacionesForm("Formularios", "Nuevo", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                registro.estados = "Activo";
                entity.Formularios.Add(registro);
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

        private Result validarAtributos(Formularios registro)
        {

            if (registro.menuId == 0)
            {
                return new Result { error = "Seleccione un menu.", tipoAlerta = "warning" };
            }

            if (registro.indexVisibilidad == 0)
            {
                return new Result { error = "Seleccione una posición a visualizar.", tipoAlerta = "warning" };
            }

            if (registro.nombreFormulario == "")
            {
                return new Result { error = "Digite el nombre formulario.", tipoAlerta = "warning" };
            }

            if (registro.urlFormulario == "")
            {
                return new Result { error = "Digite la url formulario.", tipoAlerta = "warning" };
            }

            if (registro.nombreMostrar == "")
            {
                return new Result { error = "Digite el nombre mostrar.", tipoAlerta = "warning" };
            }

            return new Result() { error = "" };
        }
        public bool existeRegistro(int formulariosId)
        {
            if (entity.Formularios.Where(x => x.id == formulariosId).Count() > 0)
                return true;
            return false;
        }
        public Result inactivarFormularios(int formulariosId, int usuarioId)
        {
            if (existeRegistro(formulariosId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("Formularios", "Inactivar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                Formularios registroInactivar= entity.Formularios.Where(x => x.id == formulariosId).SingleOrDefault();
                registroInactivar.estados = "Inactivo";
                registroInactivar.usuarioId = usuarioId;
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = formulariosId };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }
            }

            return new Result { error = "" };
        }

        public Result activarFormularios(int formulariosId, int usuarioId)
        {
            if (existeRegistro(formulariosId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("Formularios", "Activar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                Formularios registroActivar = entity.Formularios.Where(x => x.id == formulariosId).SingleOrDefault();
                registroActivar.estados = "Activo";
                registroActivar.usuarioId = usuarioId;
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = formulariosId };
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
