<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmEstadosCivil_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmEstadosCivil_Editar" %>

<%@ Register Src="~/Forms/frmEstadosCivil.ascx" TagPrefix="uc1" TagName="frmEstadosCivil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/EstadosCivil.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmEstadosCivil runat="server" ID="frmEstadosCivil" />
    <br />
    <a id="btnEstadosCivil_Editar" onclick="btnEstadosCivil_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
<% string estadosCivilIdString = Request.QueryString["id"];
        int estadosCivilId = 0;
        int.TryParse(estadosCivilIdString, out estadosCivilId);
        string jsonEstadosCivil = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ControlUsuarios.Entity.Controller.EstadosCivilController.getEstadosCivil(estadosCivilId)); %>
        estadosCivil = <%= jsonEstadosCivil %>
        console.log(estadosCivil);
        cargarDatos(estadosCivil);
    </script>
</asp:Content>
