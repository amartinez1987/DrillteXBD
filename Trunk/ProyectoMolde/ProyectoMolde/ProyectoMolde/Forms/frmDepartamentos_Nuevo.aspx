<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmDepartamentos_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmDepartamentos_Nuevo" %>

<%@ Register Src="~/Forms/frmDepartamentos.ascx" TagPrefix="uc1" TagName="frmDepartamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Departamentos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmDepartamentos runat="server" ID="frmDepartamentos" />
    <br />
    <a id="btnDepartamentos_Guardar" onclick="btnDepartamentos_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
</asp:Content>
