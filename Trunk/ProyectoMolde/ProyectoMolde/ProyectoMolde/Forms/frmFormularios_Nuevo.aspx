<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmFormularios_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmFormularios_Nuevo" %>

<%@ Register Src="~/Forms/frmFormularios.ascx" TagPrefix="uc1" TagName="frmFormularios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Formularios.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmFormularios runat="server" id="frmFormularios" />
    <br />
    <a id="btnFormularios_Guardar" onclick="btnFormularios_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/Formularios.js"></script>
    <script src="../Js/frmHelp.js"></script>
</asp:Content>
