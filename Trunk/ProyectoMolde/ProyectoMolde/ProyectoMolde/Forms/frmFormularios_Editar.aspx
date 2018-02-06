<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmFormularios_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmFormularios_Editar" %>

<%@ Register Src="~/Forms/frmFormularios.ascx" TagPrefix="uc1" TagName="frmFormularios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmFormularios runat="server" ID="frmFormularios" />
    <br />
    <a id="btnFormularios_Editar" onclick="btnFormularios_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/Formularios.js"></script>
    <script src="../Js/frmHelp.js"></script>
    <script>
<% string formulariosIdString = Request.QueryString["id"];
        int formulariosId = 0;
        int.TryParse(formulariosIdString, out formulariosId);
        string jsonFormularios = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.FormulariosController().getFormularios(formulariosId)); %>
        formularios = <%= jsonFormularios %>
        console.log(formularios);
        cargarDatos(formularios);
    </script>
</asp:Content>
