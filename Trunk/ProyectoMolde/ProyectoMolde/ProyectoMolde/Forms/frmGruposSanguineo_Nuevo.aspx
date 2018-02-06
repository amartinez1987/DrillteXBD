<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmGruposSanguineo_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmGruposSanguineo_Nuevo" %>

<%@ Register Src="~/Forms/frmGruposSanguineo.ascx" TagPrefix="uc1" TagName="frmGruposSanguineo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/GruposSanguineo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmGruposSanguineo runat="server" ID="frmGruposSanguineo" />
    <br />
    <a id="btnGruposSanguineo_Guardar" onclick="btnGruposSanguineo_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
</asp:Content>
