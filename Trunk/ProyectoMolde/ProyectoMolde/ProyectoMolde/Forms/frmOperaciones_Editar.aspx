<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmOperaciones_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmOperaciones_Editar" %>

<%@ Register Src="~/Forms/frmOperaciones.ascx" TagPrefix="uc1" TagName="frmOperaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Operaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmOperaciones runat="server" ID="frmOperaciones" />
    <br />
    <a id="btnOperaciones_Editar" onclick="btnOperaciones_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
<% string operacionesIdString = Request.QueryString["id"];
        int operacionesId = 0;
        int.TryParse(operacionesIdString, out operacionesId);
        string jsonOperaciones = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ControlUsuarios.Entity.Controller.OperacionesController.getOperaciones(operacionesId)); %>
        operaciones = <%= jsonOperaciones %>
        console.log(operaciones);
        cargarDatos(operaciones);
    </script>
</asp:Content>
