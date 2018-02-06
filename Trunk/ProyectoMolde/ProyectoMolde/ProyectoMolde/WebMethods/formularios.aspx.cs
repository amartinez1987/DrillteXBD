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
    public partial class formularios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Result getListaFormularios(string valorBuscado, int registroPartida, int totalAExtraer, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            int totalRegistros = 0;
            List<FormulariosViewModel> lst = new List<FormulariosViewModel>();
            try
            {
                FormulariosController fc = new FormulariosController();
                lst = fc.getListaFormularios(valorBuscado);
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
        public static Result guardar(int id, int menuId, int usuarioId, int indexVisibilidad, bool esVisible, string nombreFormulario, string urlFormulario, string nombreMostrar, string estados, string iconOpcion)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            Formularios objEntity = new Formularios();
            objEntity.id = id;
            objEntity.menuId = menuId;
            objEntity.usuarioId = usuarioId;
            objEntity.indexVisibilidad = indexVisibilidad;
            objEntity.esVisible = esVisible;
            objEntity.nombreFormulario = nombreFormulario;
            objEntity.urlFormulario = urlFormulario;
            objEntity.nombreMostrar = nombreMostrar;
            objEntity.estados = estados;
            objEntity.iconOpcion = iconOpcion;
            try
            {
                FormulariosController fc = new FormulariosController();
                return fc.guardarFormularios(objEntity);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
        [WebMethod(EnableSession = true)]
        public static Result inactivar(int id, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            try
            {
                FormulariosController fc = new FormulariosController();
                return fc.inactivarFormularios(id, usuarioId);
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
                FormulariosController fc = new FormulariosController();
                return fc.activarFormularios(id, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
    }
}
