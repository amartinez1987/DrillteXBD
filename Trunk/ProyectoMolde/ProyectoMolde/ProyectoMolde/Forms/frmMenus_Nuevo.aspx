<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmMenus_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmMenus_Nuevo" %>

<%@ Register Src="~/Forms/frmMenus.ascx" TagPrefix="uc1" TagName="frmMenus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">        
         
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmMenus runat="server" ID="frmMenus" />
    <br />
    <a id="btnMenus_Guardar" onclick="btnMenus_GuardarClick()" class="btn btn-success">Guardar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/Menus.js"></script>  
     <script src="../Js/frmHelp.js"></script>     
</asp:Content>
