<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmGruposSanguineo_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmGruposSanguineo_Editar" %>

<%@ Register Src="~/Forms/frmGruposSanguineo.ascx" TagPrefix="uc1" TagName="frmGruposSanguineo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/GruposSanguineo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmGruposSanguineo runat="server" ID="frmGruposSanguineo" />
    <br />
    <a id="btnGruposSanguineo_Editar" onclick="btnGruposSanguineo_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
<% string gruposSanguineoIdString = Request.QueryString["id"];
        int gruposSanguineoId = 0;
        int.TryParse(gruposSanguineoIdString, out gruposSanguineoId);
        string jsonGruposSanguineo = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ControlUsuarios.Entity.Controller.GruposSanguineoController.getGruposSanguineo(gruposSanguineoId)); %>
        gruposSanguineo = <%= jsonGruposSanguineo %>
        console.log(gruposSanguineo);
        cargarDatos(gruposSanguineo);
    </script>
</asp:Content>
