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
    public partial class municipios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Result getListaMunicipios(string valorBuscado,int registroPartida, int totalAExtraer, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            int totalRegistros = 0;
            List<MunicipiosViewModel> lst = new List<MunicipiosViewModel>();
            try
            {
                MunicipiosController mc = new MunicipiosController();
                lst = mc.getListaMunicipios(valorBuscado);
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
        public static Result guardar(int id, int departamentoId, int usuarioId, string nombre, string codigoDane)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            Municipios objEntity = new Municipios();
            objEntity.id = id;
            objEntity.departamentoId = departamentoId;
            objEntity.usuarioId = usuarioId;
            objEntity.nombre = nombre;
            objEntity.codigoDane = codigoDane;
            try
            {
                MunicipiosController mc = new MunicipiosController();
                return mc.guardarMunicipios(objEntity);
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
                MunicipiosController mc = new MunicipiosController();
                return mc.eliminarMunicipios(id, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
    }
}
