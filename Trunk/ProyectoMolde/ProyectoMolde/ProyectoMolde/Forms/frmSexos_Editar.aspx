<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmSexos_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmSexos_Editar" %>

<%@ Register Src="~/Forms/frmSexos.ascx" TagPrefix="uc1" TagName="frmSexos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Sexos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmSexos runat="server" ID="frmSexos" />
    <br />
    <a id="btnSexos_Editar" onclick="btnSexos_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
<% string sexosIdString = Request.QueryString["id"];
        int sexosId = 0;
        int.TryParse(sexosIdString, out sexosId);
        string jsonSexos = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ControlUsuarios.Entity.Controller.SexosController.getSexos(sexosId)); %>
        sexos = <%= jsonSexos %>
        console.log(sexos);
        cargarDatos(sexos);
    </script>
</asp:Content>
