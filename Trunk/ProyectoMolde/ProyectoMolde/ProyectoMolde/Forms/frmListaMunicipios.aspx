<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMasterPage.Master" AutoEventWireup="true" CodeBehind="frmListaMunicipios.aspx.cs" Inherits="ProyectoMolde.Forms.frmListaMunicipios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <br />
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Listado Municipios
            </div>
            <div class="panel-body">
                <div class="col-sm-6">
                    <button id="btnMunicipios_Nuevo" onclick="btnMunicipios_NuevoClick()" type="button" class="btn btn-default">Nuevo</button>
                </div>
                <div class="col-sm-6">                        
                        <input id="txtSearch" type="text" placeholder="Search"/>
                        <a type="button" onclick="btnOnSearch()" class="fa fa-search"></a>
                    </div>
            </div>
            <br />
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <table id="gridListaMunicipios" class="display" cellspacing="0" width="100%">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>#</th>
                                <th>Nombre Municipio</th>
                                <th>CódigoDane Municipio</th>
                                <th>Nombre Departamento</th>
                                <th>CodigoDane Departamento</th>
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
    <script src="../Js/Forms/Municipios.js"></script>
    <script>
        cargarListaMunicipios();
    </script>
</asp:Content>
