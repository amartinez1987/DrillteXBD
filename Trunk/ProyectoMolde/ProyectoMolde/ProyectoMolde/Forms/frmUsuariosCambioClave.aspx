<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmUsuariosCambioClave.aspx.cs" Inherits="ProyectoMolde.Forms.frmUsuariosCambioClave" %>
<%@ Register Src="~/Forms/frmCambioContraseña.ascx" TagPrefix="uc1" TagName="frmCambioContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmCambioContraseña runat="server" id="frmCambioContraseña" />
    <a id="btnUsuariosActualizarClave" onclick="btnUsuariosActualizarClave_Click('#boxMessagesCrud')" class="btn btn-success">Actualizar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/Usuarios.js"></script>
    <script>
<% string usuariosIdString = Request.QueryString["id"];
        int usuariosId = 0;
        int.TryParse(usuariosIdString, out usuariosId);
        string jsonUsuarios = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.UsuariosController().getUsuariosId(usuariosId)); %>
        usuarios = <%= jsonUsuarios %>
    </script>
</asp:Content>
