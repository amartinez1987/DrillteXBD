using ControlUsuarios.Entity.Controller;
using ControlUsuarios.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMolde.WebMethods
{
    public partial class help : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Result getListaHelp(string tabla, string[] prefiltros, string textoBusqueda, int registroPartida, int totalAExtraer, int usuarioId)
        {
            int totalRegistros = 0;
            MethodInfo metRange;
            object lst;
            try
            {
                helpController hc = new helpController();
                lst = hc.getLista(tabla, prefiltros, textoBusqueda);
                Type tpLs = lst.GetType();
                MethodInfo[] metArry = tpLs.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                MethodInfo metCount = tpLs.GetMethod("get_Count");
                metRange = tpLs.GetMethod("GetRange");
                totalRegistros = int.Parse(metCount.Invoke(lst, null).ToString());
                totalAExtraer = (totalRegistros - registroPartida) < totalAExtraer ? (totalRegistros - registroPartida) : totalAExtraer;

            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(metRange.Invoke(lst, new object[] { registroPartida, totalAExtraer })), totalRegistros = totalRegistros };
        }

        [WebMethod]
        public static Result getHelp(string tabla, string valorBuscar, int usuarioId, string[] prefiltros)
        {
            object lst;
            try
            {
                helpController hc = new helpController();
                lst = hc.getObject(tabla, valorBuscar, prefiltros);
            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst) };
        }
    }
}