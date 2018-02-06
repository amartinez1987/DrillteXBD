<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmListaOpcionesMaestroAnexos.aspx.cs" Inherits="ProyectoMolde.Forms.frmListaOpcionesMaestroAnexos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    <br />
    <div class="row">
        <div class="col-sm-12">
            <button id="btnOpcionesMaestroAnexos_Nuevo" onclick="btnOpcionesMaestroAnexos_NuevoClick()" type="button" class="btn btn-default">Nuevo</button>
        </div>
    </div>
    <br />
    <!-- /.row -->
    <div class="row">
        <div class="col-sm-12">
            <table id="gridListaOpcionesMaestroAnexos" class="display" cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Maestro Anexos</th>
                        <th>Nombre Opción</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>



    <!-- /.row -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
    <script src="../Js/Forms/OpcionesMaestroAnexos.js"></script>
    <script>
        <% string maestroAnexosIdString = Request.QueryString["id"];
           int maestroAnexosId = 0;
           int.TryParse(maestroAnexosIdString, out maestroAnexosId);
           string jsonMaestroAnexos = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.MaestroAnexosController().getMaestroAnexos(maestroAnexosId)); %>
        maestroAnexos = <%= jsonMaestroAnexos %>
             
    </script>
    <script>
        cargarListaOpcionesMaestroAnexos(maestroAnexos.id);
    </script>
</asp:Content>
