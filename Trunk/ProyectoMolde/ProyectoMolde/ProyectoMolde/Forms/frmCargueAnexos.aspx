<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmCargueAnexos.aspx.cs" Inherits="ProyectoMolde.Forms.frmCargueAnexos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:HiddenField ID="hRegistro" runat="server" />
            <asp:HiddenField ID="hConsecutivo" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <label>Tipo Anexo</label>
            <asp:DropDownList ID="cmbTipoAnexo" runat="server">
            </asp:DropDownList>
        </div>

    </div>
    <div class="row">
        <div class="col-sm-12">
            <input type="file" id="File1" name="File1" runat="server" />
        </div>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Subir" OnClick="Button1_Click"  />
    <table width="100%" border="1">
        <thead>
            <tr role="row">
                <th>Tipo Anexo</th>
                <th>Nombre Archivo Cargado</th> 
                <th>#</th>                
            </tr>
        </thead>
        <tbody>
            <%
                List<ControlUsuarios.Entity.Model.AnexosViewModel> lst = null; try { lst = new ControlUsuarios.Entity.Controller.AnexoController().getListaAnexosPorConsecutivoTemporal(hConsecutivo.Value.ToString()); }
                catch (Exception) { }

                foreach (ControlUsuarios.Entity.Model.AnexosViewModel item in lst)
                {
               %>
            <%= "<tr><td>"+item.nombreOpcionMaestroAnexo+"</td>"+"<td>"+item.nombreAnexo+"</td><td>"+"<a target=\"_blanck\" href=\"frmDescargueArchivos.aspx?id="+item.id+"\">Descargar</a></td></tr>" %>       
            <%} %>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
       consecutivoAnexo = <%= hConsecutivo.Value  %>;
    </script>
    
</asp:Content>
