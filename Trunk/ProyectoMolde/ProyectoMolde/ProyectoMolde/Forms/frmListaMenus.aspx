<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMasterPage.Master" AutoEventWireup="true" CodeBehind="frmListaMenus.aspx.cs" Inherits="ProyectoMolde.Forms.frmListaMenus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <br />
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Listado Menus
            </div>
            <div class="panel-body">
                <div class="col-sm-8">
                    <button id="btnMenus_Nuevo" onclick="btnMenus_NuevoClick()" type="button" class="btn btn-default">Nuevo</button>
                </div>
            </div>
            <br />



            <table id="gridListaMenus" class="display" cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Nombre Menu</th>
                        <th>Nombre Aplicación</th>
                        <th>Index Visibilidad</th>
                        <th>Estado</th>
                        <th>Icono</th>
                    </tr>
                </thead>
            </table>



        </div>
    </div>
    <!-- /.row -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footerScripst" runat="server">
    <script src="../Js/Forms/Menus.js"></script>
    <script>
        cargarListaMenus();
    </script>
</asp:Content>
