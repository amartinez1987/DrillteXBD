<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmMenus_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmMenus_Editar" %>

<%@ Register Src="~/Forms/frmMenus.ascx" TagPrefix="uc1" TagName="frmMenus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmMenus runat="server" ID="frmMenus" />
    <br />
    <a id="btnMenus_Editar" onclick="btnMenus_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/Menus.js"></script>  
     <script src="../Js/frmHelp.js"></script>
    <script>
<% string menusIdString = Request.QueryString["id"];
        int menusId = 0;
        int.TryParse(menusIdString, out menusId);
        string jsonMenus = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.MenusController().getMenus(menusId)); %>
        menus = <%= jsonMenus %>
        console.log(menus);
        cargarDatos(menus);
    </script>
</asp:Content>
