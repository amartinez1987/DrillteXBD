<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmSexos_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmSexos_Nuevo" %>

<%@ Register Src="~/Forms/frmSexos.ascx" TagPrefix="uc1" TagName="frmSexos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Sexos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmSexos runat="server" ID="frmSexos" />
    <br />
    <a id="btnSexos_Guardar" onclick="btnSexos_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
</asp:Content>
