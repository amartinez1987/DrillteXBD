<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmMunicipios_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmMunicipios_Editar" %>

<%@ Register Src="~/Forms/frmMunicipios.ascx" TagPrefix="uc1" TagName="frmMunicipios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Municipios.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmMunicipios runat="server" ID="frmMunicipios" />
    <br />
    <a id="btnMunicipios_Editar" onclick="btnMunicipios_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/Municipios.js"></script>
    <script src="../Js/frmHelp.js"></script>
    <script>
<% string municipiosIdString = Request.QueryString["id"];
        int municipiosId = 0;
        int.TryParse(municipiosIdString, out municipiosId);
        string jsonMunicipios = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.MunicipiosController().getMunicipios(municipiosId)); %>
        municipios = <%= jsonMunicipios %>
        console.log(municipios);
        cargarDatos(municipios);
    </script>
</asp:Content>
