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
    public partial class operacionesFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Result getListaOperacionesDelFormulario(int id, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
           
            List<OperacionesFormularioViewModel> lst = new List<OperacionesFormularioViewModel>();
            try
            {
                OperacionesFormularioController opfc = new OperacionesFormularioController();
                lst = opfc.getListaOperacionesFormulario(id);
           
            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst)};
        }

        [WebMethod]
        public static Result getListaNoOperacionesFormulario(int id, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            List<OperacionesViewModel> lst = new List<OperacionesViewModel>();
            try
            {
                OperacionesFormularioController opfc = new OperacionesFormularioController();
                lst = opfc.getListaNoOperacionesFormulario(id);

            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst) };
        }


        [WebMethod(EnableSession = true)]
        public static Result guardar(OperacionesFormulario[] operacionesFormulario, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
           
            try
            {
                OperacionesFormularioController opfc = new OperacionesFormularioController();
                return opfc.guardarOperacionesFormulario(operacionesFormulario, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }


      
    }
}
