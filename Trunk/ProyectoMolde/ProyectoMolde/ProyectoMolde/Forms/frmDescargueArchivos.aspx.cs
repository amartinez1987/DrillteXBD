using ControlUsuarios.Entity.Controller;
using ControlUsuarios.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMolde.Forms
{
    public partial class frmDescargueArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            AnexoController ac = new AnexoController();
            int anexoId = 0;
            int.TryParse( Request.QueryString["id"], out anexoId);
            AnexosViewModel avm = ac.getAnexos(anexoId);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(avm.anexo);
            WriteToResponse(avm.nombreAnexo,true, "", stream );
        }

        protected void WriteToResponse(string fileName, bool saveAsFile, string fileFormat, System.IO.MemoryStream stream)
        {
            fileName = fileName.Replace(' ', '_');
            if (Page == null || Page.Response == null) return;
            string disposition = saveAsFile ? "attachment" : "inline";
            Page.Response.Clear();
            Page.Response.Buffer = false;
            Page.Response.AppendHeader("Content-Type", string.Format("application/{0}", fileFormat));
            Page.Response.AppendHeader("Content-Transfer-Encoding", "binary");
            Page.Response.AppendHeader("Content-Disposition", string.Format("{0}; filename={1}", disposition, fileName, fileFormat));
            Page.Response.BinaryWrite(stream.ToArray());
            Page.Response.End();
        }
    }
}