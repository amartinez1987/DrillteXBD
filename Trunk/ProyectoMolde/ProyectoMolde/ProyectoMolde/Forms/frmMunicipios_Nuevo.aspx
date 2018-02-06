<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmMunicipios_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmMunicipios_Nuevo" %>

<%@ Register Src="~/Forms/frmMunicipios.ascx" TagPrefix="uc1" TagName="frmMunicipios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Municipios.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmMunicipios runat="server" ID="frmMunicipios" />
    <br />
    <a id="btnMunicipios_Guardar" onclick="btnMunicipios_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/Municipios.js"></script>
    <script src="../Js/frmHelp.js"></script>
</asp:Content>
