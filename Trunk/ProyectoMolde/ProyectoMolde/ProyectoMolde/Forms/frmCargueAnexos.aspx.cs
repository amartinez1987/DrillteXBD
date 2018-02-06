using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ControlUsuarios.Entity.Controller;
using ControlUsuarios.Entity.Model;
using System.Runtime.InteropServices;

namespace ProyectoMolde.Forms
{
    public partial class frmCargueAnexos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int maestroAnexoId = 0;
            if (!IsPostBack)
            {

               
                string tabla = Request.QueryString["tabla"];                
                hRegistro.Value = Request.QueryString["registroId"];

                OpcionesMaestroAnexosController omc = new OpcionesMaestroAnexosController();
                List<OpcionesMaestroAnexosViewModel> lstOMA = omc.getListaOpcionesMaestroAnexosPorMaestroNombreTabla(tabla);                

                foreach (OpcionesMaestroAnexosViewModel omavm in lstOMA)
                {
                    maestroAnexoId = omavm.maestroAnexosId;
                    cmbTipoAnexo.Items.Add(new ListItem() { Text = omavm.nombreOpcion, Value = omavm.id.ToString() });
                }

                try
                {
                    hConsecutivo.Value = ConsecutivosTemporalesController.getConsecutivo(maestroAnexoId);
                    Button1.Enabled = true;
                }
                catch (Exception)
                {
                    Button1.Enabled = false;
                }
            }

        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                string valueTipoAnexo = cmbTipoAnexo.SelectedValue;
                string val = hRegistro.Value;
                try
                {
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(File1.PostedFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(File1.PostedFile.ContentLength);
                    }

                    AnexoController ac = new AnexoController();
                    Anexos a = new Anexos();
                    a.anexo = fileData;
                    a.consecutivoTemporal = hConsecutivo.Value;
                    a.id = 0;
                    a.opcionMaestroAnexoId = int.Parse( valueTipoAnexo );
                    a.nombreAnexo = fn;
                    try
                    {
                        a.registroTablaId = int.Parse(hRegistro.Value.ToString());
                    }
                    catch (Exception)
                    {}
                    a.usuarioId = int.Parse( Session["usuarioId"].ToString());
                    
                   Result r = ac.guardarAnexos(a);

                   if (r.error != "")
                   {
                       Response.Write("<h1> Error: " + r.error + "</h1>");
                   }

                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                    //Note: Exception.Message returns detailed message that describes the current exception. 
                    //For security reasons, we do not recommend you return Exception.Message to end users in 
                    //production environments. It would be better just to put a generic error message. 
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }
    }
}