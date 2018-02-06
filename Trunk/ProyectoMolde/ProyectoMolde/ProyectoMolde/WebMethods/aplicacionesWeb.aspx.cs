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
    public partial class aplicacionesWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        [WebMethod]
        public static Result getListaAplicacionesWeb(int registroPartida, int totalAExtraer, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            int totalRegistros = 0;
            List<AplicacionesWebViewModel> lst = new List<AplicacionesWebViewModel>();
            try
            {
                lst = AplicacionesWebController.getListaAplicacionesWeb();
                totalRegistros = lst.Count();
                totalAExtraer = (lst.Count() - registroPartida) < totalAExtraer ? (lst.Count() - registroPartida) : totalAExtraer;
            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }

            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst.GetRange(registroPartida, totalAExtraer)), totalRegistros = totalRegistros };
        }


        [WebMethod(EnableSession= true)]
        public static Result guardar(int id, string nombre, string descripcion, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            AplicacionesWeb aw = new AplicacionesWeb();

            aw.id = id;
            aw.nombre = nombre;
            aw.descripcion = descripcion;
            aw.usuarioId = usuarioId;

            try
            {
                return AplicacionesWebController.guardarAplicacionesWeb(aw);
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
                return AplicacionesWebController.eliminarAplicacionesWeb(id, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }

    }
}