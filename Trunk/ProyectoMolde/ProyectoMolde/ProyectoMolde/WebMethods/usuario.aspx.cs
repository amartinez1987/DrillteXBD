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
    public partial class usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static Result getListaMenuUsuario(int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            UsuariosController uc = new UsuariosController();
            return uc.getMenuUsuarioPorId(usuarioId, "Molde");
        }

        [WebMethod(EnableSession = true)]
        public static Result loginOut(int usuarioId)
        {
            HttpContext.Current.Session.RemoveAll();
            return new Result() { error = "", getCadena = "", id = 0, tipoAlerta = "" };
        }


        [WebMethod]
        public static Result getListaUsuarios(string valorBuscado, int registroPartida, int totalAExtraer, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            int totalRegistros = 0;
            List<UsuariosViewModel> lst = new List<UsuariosViewModel>();
            try
            {
                UsuariosController uc = new UsuariosController();
                lst = uc.getListaUsuarios(valorBuscado);
                totalRegistros = lst.Count();
                totalAExtraer = (lst.Count() - registroPartida) < totalAExtraer ? (lst.Count() - registroPartida) : totalAExtraer;
            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst.GetRange(registroPartida, totalAExtraer)), totalRegistros = totalRegistros };
        }

        [WebMethod]
        public static Result nuevo(UsuariosViewModel usuario)
        {
            Result r = ValidateSession.validarSession(usuario.id, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            if (usuario.clave != usuario.confirmarClave)
            {
                return new Result() { id = 0, error = "Las claves no coinciden.", tipoAlerta = "warning" };
            }

            Usuarios u = new UsuariosController().getModel(usuario);
            r = IFACTORY.createUsuarios("Nuevo").NuevoConDatosPersona(ref u);
            return r;
        }

        [WebMethod]
        public static Result editar(UsuariosViewModel usuario,string modificaPerfil)
        {
            Result r = ValidateSession.validarSession(usuario.usuarioId.Value, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            Usuarios u = new UsuariosController().getModel(usuario);
            r = IFACTORY.createUsuarios(u.estado).Editar(ref u, modificaPerfil);
            return r;
        }

        [WebMethod]
        public static Result inactivar(int id, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            UsuariosViewModel u = new UsuariosController().getUsuariosId(id);
            r = IFACTORY.createUsuarios(u.estado).Inactivar(id, usuarioId);
            return r;
        }

        [WebMethod]
        public static Result activar(int id, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            UsuariosViewModel u = new UsuariosController().getUsuariosId(id);
            r = IFACTORY.createUsuarios(u.estado).Activar(id, usuarioId);
            return r;
        }

        [WebMethod]
        public static Result actualizarClave(int id, string clave, string confirmarClave, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);

            if (clave != confirmarClave)
            {
                return new Result() { id = 0, error = "Las claves no coinciden.", tipoAlerta = "warning" };
            }

            UsuariosViewModel u = new UsuariosController().getUsuariosId(id);
            u.clave = clave;
            r = IFACTORY.createUsuarios(u.estado).actualizarClave(u, usuarioId);
            return r;

        }
    }
}