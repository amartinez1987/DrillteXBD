<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmDocumentosIdentidad_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmDocumentosIdentidad_Editar" %>

<%@ Register Src="~/Forms/frmDocumentosIdentidad.ascx" TagPrefix="uc1" TagName="frmDocumentosIdentidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/DocumentosIdentidad.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmDocumentosIdentidad runat="server" ID="frmDocumentosIdentidad" />
    <br />
    <a id="btnDocumentosIdentidad_Editar" onclick="btnDocumentosIdentidad_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
<% string documentosIdentidadIdString = Request.QueryString["id"];
        int documentosIdentidadId = 0;
        int.TryParse(documentosIdentidadIdString, out documentosIdentidadId);
        string jsonDocumentosIdentidad = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ControlUsuarios.Entity.Controller.DocumentosIdentidadController.getDocumentosIdentidad(documentosIdentidadId)); %>
        documentosIdentidad = <%= jsonDocumentosIdentidad %>
        console.log(documentosIdentidad);
        cargarDatos(documentosIdentidad);
    </script>
</asp:Content>
