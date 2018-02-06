<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMasterPage.Master" AutoEventWireup="true" CodeBehind="frmListaFormularios.aspx.cs" Inherits="ProyectoMolde.Forms.frmListaFormularios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <br />
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Listado Formularios
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-sm-6">
                        <button id="btnFormularios_Nuevo" onclick="btnFormularios_NuevoClick()" type="button" class="btn btn-default">Nuevo</button>                        
                    </div>
                    <div class="col-sm-6">                        
                        <input id="txtSearch" type="text" placeholder="Search"/>
                        <a type="button" onclick="btnOnSearch()" class="fa fa-search"></a>
                    </div>
                </div>
            </div>
            <br />
            <!-- /.row -->
            <div class="row">
                <div class="col-sm-12">
                    <table id="gridListaFormularios" class="display" cellspacing="0" width="100%">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>#</th>
                                <th>Nombre Formulario</th>
                                <th>Nombre Mostrar</th>
                                <th>Menu Asociado</th>
                                <th>Url Formulario</th>
                                <th>¿Es Visible?</th>
                                <th>Estados</th>
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
    <script src="../Js/Forms/Formularios.js"></script>
    <script>
        cargarListaFormularios();        
    </script>
</asp:Content>
