<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmDocumentosIdentidad_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmDocumentosIdentidad_Nuevo" %>

<%@ Register Src="~/Forms/frmDocumentosIdentidad.ascx" TagPrefix="uc1" TagName="frmDocumentosIdentidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/DocumentosIdentidad.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmDocumentosIdentidad runat="server" ID="frmDocumentosIdentidad" />
    <br />
    <a id="btnDocumentosIdentidad_Guardar" onclick="btnDocumentosIdentidad_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
</asp:Content>
