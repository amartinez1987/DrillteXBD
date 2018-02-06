<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmPerfiles_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmPerfiles_Nuevo" %>

<%@ Register Src="~/Forms/frmPerfiles.ascx" TagPrefix="uc1" TagName="frmPerfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Perfiles.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmPerfiles runat="server" ID="frmPerfiles" />
    <br />
    <a id="btnPerfiles_Guardar" onclick="btnPerfiles_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
</asp:Content>
