<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMasterPage.Master" AutoEventWireup="true" CodeBehind="frmListaBarrios.aspx.cs" Inherits="ProyectoMolde.Forms.frmListaBarrios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <br />
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Listado Barrios
            </div>
            <div class="panel-body">
                <div class="col-sm-6">
                    <button id="btnBarrios_Nuevo" onclick="btnBarrios_NuevoClick()" type="button" class="btn btn-default">Nuevo</button>
                </div>
                <div class="col-sm-6">
                    <input id="txtSearch" type="text" placeholder="Search" />
                    <a type="button" onclick="btnOnSearch()" class="fa fa-search"></a>
                </div>
            </div>
            <br />
            <!-- /.row -->
            <div class="row">
                <div class="col-sm-12">
                    <table id="gridListaBarrios" class="display" cellspacing="0" width="100%">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Nombre</th>
                                <th>Nombre departamento y municipio asociado</th>
                                <th>Código Dane departamento municipio asociado</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <!-- /.col-lg-12 -->
            </div>
        </div>
    </div>
    <!-- /.row -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footerScripst" runat="server">
    <script src="../Js/Forms/Barrios.js"></script>
    <script>
        cargarListaBarrios();
    </script>
</asp:Content>
