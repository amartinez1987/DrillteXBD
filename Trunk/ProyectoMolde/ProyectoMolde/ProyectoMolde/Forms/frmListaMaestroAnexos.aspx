<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMasterPage.Master" AutoEventWireup="true" CodeBehind="frmListaMaestroAnexos.aspx.cs" Inherits="ProyectoMolde.Forms.frmListaMaestroAnexos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <br />
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Listado Maestro Anexos
            </div>
            <div class="panel-body">
                <div class="col-sm-12">
                    <button id="btnMaestroAnexos_Nuevo" onclick="btnMaestroAnexos_NuevoClick()" type="button" class="btn btn-default">Nuevo</button>
                </div>
            </div>
            <br />
            <!-- /.row -->
            <div class="row">
                <div class="col-sm-12">
                    <table id="gridListaMaestroAnexos" class="display" cellspacing="0" width="100%">
                        <thead>
                            <tr>
                                <th>#</th>                                                                
                                <th>Tabla</th>
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
    <script src="../Js/Forms/MaestroAnexos.js"></script>
    <script>
        cargarListaMaestroAnexos();
    </script>
</asp:Content>
