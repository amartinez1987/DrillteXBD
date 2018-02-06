using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class MenusController
    {
        MoldeEntities entity = new MoldeEntities();
        public MoldeEntities getMoldeEntity()
        {
            return entity;
        }
        public List<MenusViewModel> getListaMenus()
        {
            var l = from menus in entity.Menus
                    select new MenusViewModel { id = menus.id, aplicacionWebId = menus.aplicacionWebId, nombreAplicacionWeb = menus.AplicacionesWeb.nombre, usuarioId = menus.usuarioId, indexVisibilidad = menus.indexVisibilidad, nombreMenu = menus.nombreMenu, estado = menus.estado, icon = menus.icon };
            return l.ToList();
        }
        public MenusViewModel getMenus(int id)
        {
            var l = from menus in entity.Menus
                    where menus.id == id
                    select new MenusViewModel { id = menus.id, aplicacionWebId = menus.aplicacionWebId, nombreAplicacionWeb = menus.AplicacionesWeb.nombre, usuarioId = menus.usuarioId, indexVisibilidad = menus.indexVisibilidad, nombreMenu = menus.nombreMenu, estado = menus.estado, icon = menus.icon };
            return l.SingleOrDefault();
        }
        public Result guardarMenus(Menus registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }

            if (existeRegistro(registro.id))
            {
                result = ValidateSession.validarOperacionesForm("Menus", "Editar", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                int menusId = registro.id;
                Menus registroEditar = entity.Menus.Where(x => x.id == menusId).SingleOrDefault();
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
                result = ValidateSession.validarOperacionesForm("Menus", "Nuevo", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                registro.estado = "Activo";
                entity.Menus.Add(registro);
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
        private Result validarAtributos(Menus registro)
        {
            if (registro.aplicacionWebId == 0)
            {
                return new Result { error = "Seleccione una Aplicación Web Valida.", tipoAlerta = "warning" };
            }

            if (registro.indexVisibilidad == 0)
            {
                return new Result { error = "Seleccione Un index o posición para visualizar la opción de menu.", tipoAlerta = "warning" };
            }
            if (registro.nombreMenu == "")
            {
                return new Result { error = "El nombre no debe ser vacío.", tipoAlerta = "warning" };
            }

            return new Result() { error = "" };
        }
        public bool existeRegistro(int menusId)
        {
            if (entity.Menus.Where(x => x.id == menusId).Count() > 0)
                return true;
            return false;
        }
        public Result inactivarMenus(int menusId, int usuarioId)
        {
            if (existeRegistro(menusId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("Menus", "Inactivar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }

                Menus registroInactivar = entity.Menus.Where(x => x.id == menusId).SingleOrDefault();
                registroInactivar.estado = "Inactivo";
                registroInactivar.usuarioId = usuarioId;
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = menusId };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }
            }

            return new Result { error = "" };
        }

        public Result activarrMenus(int menusId, int usuarioId)
        {
            if (existeRegistro(menusId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("Menus", "Activar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }

                Menus registroInactivar = entity.Menus.Where(x => x.id == menusId).SingleOrDefault();
                registroInactivar.estado = "Activo";
                registroInactivar.usuarioId = usuarioId;
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = menusId };
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
