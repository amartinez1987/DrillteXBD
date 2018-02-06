<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmBarrios_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmBarrios_Nuevo" %>
<%@ Register Src="~/Forms/frmBarrios.ascx" TagPrefix="uc1" TagName="frmBarrios"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
<uc1:frmBarrios runat="server" ID="frmBarrios" />
<br />
<a id="btnBarrios_Guardar" onclick="btnBarrios_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/Barrios.js"></script>
    <script src="../Js/frmHelp.js"></script>
</asp:Content>
