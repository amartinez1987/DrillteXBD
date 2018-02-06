<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmAplicacionesWeb_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmAplicacionesWeb_Nuevo" %>

<%@ Register Src="~/Forms/frmAplicacionesWeb.ascx" TagPrefix="uc1" TagName="frmAplicacionesWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
    <script src="../Js/Forms/AplicacionesWeb.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmAplicacionesWeb runat="server" ID="frmAplicacionesWeb" />
    <br />
    <a id="btnAplicacionesWeb_Guardar" onclick="btnAplicacionesWeb_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">    
</asp:Content>
