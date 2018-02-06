<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmPerfiles_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmPerfiles_Editar" %>

<%@ Register Src="~/Forms/frmPerfiles.ascx" TagPrefix="uc1" TagName="frmPerfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Perfiles.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmPerfiles runat="server" ID="frmPerfiles" />
    <br />
    <a id="btnPerfiles_Editar" onclick="btnPerfiles_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
<% string perfilesIdString = Request.QueryString["id"];
        int perfilesId = 0;
        int.TryParse(perfilesIdString, out perfilesId);
        string jsonPerfiles = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ControlUsuarios.Entity.Controller.PerfilesController.getPerfiles(perfilesId)); %>
        perfiles = <%= jsonPerfiles %>
        console.log(perfiles);
        cargarDatos(perfiles);
    </script>
</asp:Content>
