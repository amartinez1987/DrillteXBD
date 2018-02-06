<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmEstadosCivil_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmEstadosCivil_Nuevo" %>

<%@ Register Src="~/Forms/frmEstadosCivil.ascx" TagPrefix="uc1" TagName="frmEstadosCivil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/EstadosCivil.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmEstadosCivil runat="server" ID="frmEstadosCivil" />
    <br />
    <a id="btnEstadosCivil_Guardar" onclick="btnEstadosCivil_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
</asp:Content>
