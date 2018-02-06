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
    public partial class maestroAnexos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Result getListaMaestroAnexos(int registroPartida, int totalAExtraer, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            int totalRegistros = 0;
            List<MaestroAnexosViewModel> lst = new List<MaestroAnexosViewModel>();
            try
            {
                MaestroAnexosController mac = new MaestroAnexosController();
                lst = mac.getListaMaestroAnexos();
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
        public static Result guardar(int id, int usuarioId, string tabla, int aplicacionId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            MaestroAnexos objEntity = new MaestroAnexos();
            objEntity.id = id;
            objEntity.usuarioId = usuarioId;
            objEntity.tabla = tabla;
            objEntity.aplicacionId = aplicacionId;

            try
            {
                MaestroAnexosController mac = new MaestroAnexosController();
                return mac.guardarMaestroAnexos(objEntity);
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
                MaestroAnexosController mac = new MaestroAnexosController();
                return mac.eliminarMaestroAnexos(id, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
    }
}
