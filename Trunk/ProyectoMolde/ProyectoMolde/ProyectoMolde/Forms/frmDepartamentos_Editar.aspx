<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmDepartamentos_Editar.aspx.cs" Inherits="ProyectoMolde.Forms.frmDepartamentos_Editar" %>

<%@ Register Src="~/Forms/frmDepartamentos.ascx" TagPrefix="uc1" TagName="frmDepartamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/Departamentos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmDepartamentos runat="server" ID="frmDepartamentos" />
    <br />
    <a id="btnDepartamentos_Editar" onclick="btnDepartamentos_EditarClick()" class="btn btn-success">Editar</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script>
<% string departamentosIdString = Request.QueryString["id"];
        int departamentosId = 0;
        int.TryParse(departamentosIdString, out departamentosId);
        string jsonDepartamentos = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ControlUsuarios.Entity.Controller.DepartamentosController.getDepartamentos(departamentosId)); %>
        departamentos = <%= jsonDepartamentos %>
        console.log(departamentos);
        cargarDatos(departamentos);
    </script>
</asp:Content>
