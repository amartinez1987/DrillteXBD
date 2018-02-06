<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmUsuarios_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmUsuarios_Editar" %>

<%@ Register Src="~/Forms/frmUsuarios.ascx" TagPrefix="uc1" TagName="frmUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmUsuarios runat="server" ID="frmUsuarios" />
    <br />
    <div id="panelGuardar" >
        </div>
        <a id="btnUsuarios_Editar" onclick="btnUsuarios_EditarClick()" class="btn btn-success">Editar</a>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/Usuarios.js"></script>
    <script src="../Js/frmHelp.js"></script>
    <script>
<% string usuariosIdString = Request.QueryString["id"];
   int usuariosId = 0;
   int.TryParse(usuariosIdString, out usuariosId);
   string jsonUsuarios = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.UsuariosController().getUsuariosId(usuariosId)); %>
        usuarios = <%= jsonUsuarios %>
        console.log(usuarios);
        cargarDatos(usuarios);
    </script>
</asp:Content>
