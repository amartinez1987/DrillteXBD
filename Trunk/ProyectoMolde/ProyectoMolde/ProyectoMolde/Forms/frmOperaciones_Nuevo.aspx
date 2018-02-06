<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmOperaciones_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmOperaciones_Nuevo" %>
<%@ Register Src="~/Forms/frmOperaciones.ascx" TagPrefix="uc1" TagName="frmOperaciones"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../Js/Forms/Operaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
<uc1:frmOperaciones runat="server" ID="frmOperaciones" />
<br />
<a id="btnOperaciones_Guardar" onclick="btnOperaciones_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
</asp:Content>
