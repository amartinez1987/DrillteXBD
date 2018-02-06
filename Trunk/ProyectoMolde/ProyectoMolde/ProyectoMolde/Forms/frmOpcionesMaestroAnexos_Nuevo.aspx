<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmOpcionesMaestroAnexos_Nuevo.aspx.cs" Inherits="ProyectoMolde.Forms.frmOpcionesMaestroAnexos_Nuevo" %>

<%@ Register Src="~/Forms/frmOpcionesMaestroAnexos.ascx" TagPrefix="uc1" TagName="frmOpcionesMaestroAnexos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Js/Forms/OpcionesMaestroAnexos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <uc1:frmOpcionesMaestroAnexos runat="server" ID="frmOpcionesMaestroAnexos" />
    <br />
    <div class="row">
        <div class="col-sm-6">
            <a id="btnOpcionesMaestroAnexos_Guardar" onclick="btnOpcionesMaestroAnexos_GuardarClick()" class="btn btn-success">Guardar</a>
        </div>
        <div class="col-sm-6">
            <a id="btnOpcionesMaestroAnexos_Cancelar" onclick="btnOpcionesMaestroAnexos_CancelarClick()" class="btn btn-warning ">Regresar</a>
        </div>
    </div>
    
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
</asp:Content>
