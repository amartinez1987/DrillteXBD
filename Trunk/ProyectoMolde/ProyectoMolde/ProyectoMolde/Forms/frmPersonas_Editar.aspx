<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmPersonas_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmPersonas_Editar" %>

<%@ Register Src="~/Forms/frmPersonas.ascx" TagPrefix="uc1" TagName="frmPersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Personas.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmPersonas runat="server" ID="frmPersonas" />
    <br />
    <a id="btnPersonas_Editar" onclick="btnPersonas_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
<% string personasIdString = Request.QueryString["id"];
        int personasId = 0;
        int.TryParse(personasIdString, out personasId);
        string jsonPersonas = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.PersonasController().getPersonas(personasId)); %>
        personas = <%= jsonPersonas %>
        console.log(personas);
        cargarDatos(personas);
    </script>
</asp:Content>
