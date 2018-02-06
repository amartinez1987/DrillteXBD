<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmMaestroAnexos_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmMaestroAnexos_Nuevo" %>

<%@ Register Src="~/Forms/frmMaestroAnexos.ascx" TagPrefix="uc1" TagName="frmMaestroAnexos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/MaestroAnexos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmMaestroAnexos runat="server" ID="frmMaestroAnexos" />
    <br />
    <a id="btnMaestroAnexos_Guardar" onclick="btnMaestroAnexos_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
</asp:Content>
