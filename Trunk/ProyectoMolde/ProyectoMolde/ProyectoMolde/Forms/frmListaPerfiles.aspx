<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMasterPage.Master" AutoEventWireup="true" CodeBehind="frmListaPerfiles.aspx.cs" Inherits="ProyectoMolde.Forms.frmListaPerfiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <br />
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Listado Perfiles
            </div>
            <div class="panel-body">
                <div class="col-sm-5 col-md-5 col-lg-1">
                    <button id="btnPerfiles_Nuevo" onclick="btnPerfiles_NuevoClick()" type="button" class="btn btn-default">Nuevo</button>
                </div>
            </div>
            <br />
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <table id="gridListaPerfiles" class="display" cellspacing="0" width="100%">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>#</th>                                
                                <th>Nombre Perfil</th>
                                <th>Descripción</th>
                                <th>Estado</th>
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
    <script src="../Js/Forms/Perfiles.js"></script>
    <script>
        cargarListaPerfiles();
    </script>
</asp:Content>
