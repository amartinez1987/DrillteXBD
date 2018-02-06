<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmOpcionesMaestroAnexos_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmOpcionesMaestroAnexos_Editar" %>

<%@ Register Src="~/Forms/frmOpcionesMaestroAnexos.ascx" TagPrefix="uc1" TagName="frmOpcionesMaestroAnexos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/OpcionesMaestroAnexos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmOpcionesMaestroAnexos runat="server" ID="frmOpcionesMaestroAnexos" />
    <br />
    <div class="row">
        <div class="col-sm-6">
            <a id="btnOpcionesMaestroAnexos_Editar" onclick="btnOpcionesMaestroAnexos_EditarClick()" class="btn btn-success">Editar</a>
        </div>
        <div class="col-sm-6">
            <a id="btnOpcionesMaestroAnexos_Cancelar" onclick="btnOpcionesMaestroAnexos_CancelarClick()" class="btn btn-warning ">Regresar</a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
<% string opcionesMaestroAnexosIdString = Request.QueryString["id"];
        int opcionesMaestroAnexosId = 0;
        int.TryParse(opcionesMaestroAnexosIdString, out opcionesMaestroAnexosId);
        string jsonOpcionesMaestroAnexos = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.OpcionesMaestroAnexosController().getOpcionesMaestroAnexos(opcionesMaestroAnexosId)); %>
        opcionesMaestroAnexos = <%= jsonOpcionesMaestroAnexos %>
        console.log(opcionesMaestroAnexos);
        cargarDatos(opcionesMaestroAnexos);
    </script>
</asp:Content>
