<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmMaestroAnexos_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmMaestroAnexos_Editar" %>

<%@ Register Src="~/Forms/frmMaestroAnexos.ascx" TagPrefix="uc1" TagName="frmMaestroAnexos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/MaestroAnexos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmMaestroAnexos runat="server" ID="frmMaestroAnexos" />
    <br />
    <a id="btnMaestroAnexos_Editar" onclick="btnMaestroAnexos_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
<% string maestroAnexosIdString = Request.QueryString["id"];
   int maestroAnexosId = 0;
   int.TryParse(maestroAnexosIdString, out maestroAnexosId);
   string jsonMaestroAnexos = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.MaestroAnexosController().getMaestroAnexos(maestroAnexosId)); %>
        maestroAnexos = <%= jsonMaestroAnexos %>
        console.log(maestroAnexos);
        cargarDatos(maestroAnexos);
    </script>
</asp:Content>
