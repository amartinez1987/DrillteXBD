<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmBarrios_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmBarrios_Editar" %>

<%@ Register Src="~/Forms/frmBarrios.ascx" TagPrefix="uc1" TagName="frmBarrios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmBarrios runat="server" ID="frmBarrios" />
    <br />
    <a id="btnBarrios_Editar" onclick="btnBarrios_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/Barrios.js"></script>
    <script src="../Js/frmHelp.js"></script>
    <script>
<% string barriosIdString = Request.QueryString["id"];
        int barriosId = 0;
        int.TryParse(barriosIdString, out barriosId);
        string jsonBarrios = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.BarriosController().getBarrios(barriosId)); %>
        barrios = <%= jsonBarrios %>
        console.log(barrios);
        cargarDatos(barrios);
    </script>
</asp:Content>
