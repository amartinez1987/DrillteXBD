using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Threading.Tasks;
using ControlUsuarios.Entity.Model;
using System.Web;
using ControlUsuarios.Entity.Controller;

namespace ProyectoMolde.WebMethods
{
    public partial class perfilesOperacionesFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Result getListaOperacionesFormularioDelPerfiles(int id, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            List<PerfilesOperacionesFormularioViewModel> lst = new List<PerfilesOperacionesFormularioViewModel>();
            try
            {
                PerfilesOperacionesFormularioController pOpFC = new PerfilesOperacionesFormularioController();
                lst = pOpFC.getListaPerfilesOperacionesFormulario(id);

            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst) };
        }

        [WebMethod]
        public static Result getListaNoOperacionesFormularioDelPerfiles(int id,  int aplicacionId, int menuId, string nombreFormulario, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            List<OperacionesFormularioViewModel> lst = new List<OperacionesFormularioViewModel>();
            try
            {
                PerfilesOperacionesFormularioController pOpFC = new PerfilesOperacionesFormularioController();
                lst = pOpFC.getListaNoOperacionesFormularioPerfil(id, aplicacionId, menuId, nombreFormulario);

            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst) };
        }

        [WebMethod(EnableSession = true)]
        public static Result guardar(PerfilesOperacionesFormulario[] perfilesOperacionesFormulario, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            try
            {
                PerfilesOperacionesFormularioController pOpFC = new PerfilesOperacionesFormularioController();
                return pOpFC.guardarPerfilesOperacionesFormulario(perfilesOperacionesFormulario, usuarioId);
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
                PerfilesOperacionesFormularioController pOpFC = new PerfilesOperacionesFormularioController();
                return pOpFC.eliminarPerfilesOperacionesFormulario(id, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
    }
}
