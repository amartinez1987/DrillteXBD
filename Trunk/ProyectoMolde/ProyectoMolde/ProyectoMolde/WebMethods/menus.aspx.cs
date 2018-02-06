using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Threading.Tasks;
using ControlUsuarios.Entity.Model;
using ControlUsuarios.Entity.Controller;
using System.Web;

namespace ProyectoMolde.WebMethods
{
    public partial class menus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Result getListaMenus(int registroPartida, int totalAExtraer, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            int totalRegistros = 0;
            List<MenusViewModel> lst = new List<MenusViewModel>();
            try
            {
                MenusController mc = new MenusController();
                lst = mc.getListaMenus();
                totalRegistros = lst.Count();
                totalAExtraer = (lst.Count() - registroPartida) < totalAExtraer ? (lst.Count() - registroPartida) : totalAExtraer;
            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst.GetRange(registroPartida, totalAExtraer)), totalRegistros = totalRegistros };
        }

        [WebMethod(EnableSession = true)]
        public static Result guardar(int id, int? aplicacionWebId, int usuarioId, int indexVisibilidad, string nombreMenu, string estado, string icon)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            Menus objEntity = new Menus();
            objEntity.id = id;
            objEntity.aplicacionWebId = aplicacionWebId;
            objEntity.usuarioId = usuarioId;
            objEntity.indexVisibilidad = indexVisibilidad;
            objEntity.nombreMenu = nombreMenu;
            objEntity.estado = estado;
            objEntity.icon = icon;
            try
            {
                MenusController mc = new MenusController();
                return mc.guardarMenus(objEntity);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
        [WebMethod(EnableSession = true)]
        public static Result eliminar(int id, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            try
            {
                MenusController mc = new MenusController();
                return mc.inactivarMenus(id, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
        [WebMethod(EnableSession = true)]
        public static Result activar(int id, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            try
            {
                MenusController mc = new MenusController();
                return mc.activarrMenus(id, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
    }
}
