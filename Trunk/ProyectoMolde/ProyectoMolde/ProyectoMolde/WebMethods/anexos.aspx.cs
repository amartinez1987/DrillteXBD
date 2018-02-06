using ControlUsuarios.Entity.Controller;
using ControlUsuarios.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMolde.WebMethods
{
    public partial class anexos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static Result guardar(int id, int opcionMaestroAnexoId, int? registroTablaId, HttpPostedFile anexo, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            Anexos a = new Anexos();

            a.id = id;
            a.opcionMaestroAnexoId = opcionMaestroAnexoId;
            a.registroTablaId = registroTablaId;
           // a.anexo = anexo;
            a.usuarioId = usuarioId;

            try
            {
                AnexoController ac = new AnexoController();
                return ac.guardarAnexos(a);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
    }
}