using ControlUsuarios.Entity.Controller;
using ControlUsuarios.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMolde.WebMethods
{
    public partial class usuariosOperacionesFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Result getListaOperacionesFormularioDelUsuario(int id, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            List<UsuariosOperacionesFormularioViewModel> lst = new List<UsuariosOperacionesFormularioViewModel>();
            try
            {
                UsuariosOperacionesFormularioController pOpFC = new UsuariosOperacionesFormularioController();
                lst = pOpFC.getListaUsuariosOperacionesFormulario(id);

            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst) };
        }

        [WebMethod]
        public static Result getListaNoOperacionesFormularioDelUsuario(int id, int aplicacionId, int menuId, string nombreFormulario, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            List<OperacionesFormularioViewModel> lst = new List<OperacionesFormularioViewModel>();
            try
            {
                UsuariosOperacionesFormularioController pOpFC = new UsuariosOperacionesFormularioController();
                lst = pOpFC.getListaNoOperacionesFormularioUsuarios(id, aplicacionId, menuId, nombreFormulario);

            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst) };
        }

        [WebMethod(EnableSession = true)]
        public static Result guardar(UsuariosOperacionesFormulario[] usuariosOperacionesFormulario, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            try
            {
                UsuariosOperacionesFormularioController pOpFC = new UsuariosOperacionesFormularioController();
                return pOpFC.guardarUsuariosOperacionesFormulario(usuariosOperacionesFormulario, usuarioId);
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
                UsuariosOperacionesFormularioController pOpFC = new UsuariosOperacionesFormularioController();
                return pOpFC.eliminarUsuariosOperacionesFormulario(id, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
    }
}