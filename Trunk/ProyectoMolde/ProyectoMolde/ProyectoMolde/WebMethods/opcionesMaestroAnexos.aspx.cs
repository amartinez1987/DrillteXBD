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
    public partial class opcionesMaestroAnexos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Result getListaOpcionesMaestroAnexos(int maestroAnexoId, int registroPartida, int totalAExtraer, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            int totalRegistros = 0;
            List<OpcionesMaestroAnexosViewModel> lst = new List<OpcionesMaestroAnexosViewModel>();
            try
            {
                OpcionesMaestroAnexosController omac = new OpcionesMaestroAnexosController();
                lst = omac.getListaOpcionesMaestroAnexosPorMaestroAnexoId(maestroAnexoId );

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
        public static Result guardar(int id, int maestroAnexosId, int usuarioId, string nombreOpcion)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            OpcionesMaestroAnexos objEntity = new OpcionesMaestroAnexos();
            objEntity.id = id;
            objEntity.maestroAnexosId = maestroAnexosId;
            objEntity.usuarioId = usuarioId;
            objEntity.nombreOpcion = nombreOpcion;
            try
            {
                OpcionesMaestroAnexosController omac = new OpcionesMaestroAnexosController();
                return omac.guardarOpcionesMaestroAnexos(objEntity);
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
                OpcionesMaestroAnexosController omac = new OpcionesMaestroAnexosController();
                return omac.eliminarOpcionesMaestroAnexos(id, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
    }
}
