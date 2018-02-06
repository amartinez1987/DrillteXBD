<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmUsuariosOperacionesFormulario.aspx.cs" Inherits="ProyectoMolde.Forms.frmUsuariosOperacionesFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
        .subject-info-box-1,
        .subject-info-box-2 {
            float: left;
            width: 45%;
            select;

        {
            padding: 0;
            option;

        {
            padding: 4px 10px 4px 10px;
        }

        option:hover {
            background: #EEEEEE;
        }

        }
        }

        .subject-info-arrows {
            float: left;
            width: 10%;
            input;

        {
            width: 70%;
            margin-bottom: 5px;
        }

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenPlaceDocument" runat="server">
    
    <div class="row">
        <div class="col-sm-6">
            
            <label id="lblaplicacionWebIdUsuariosOperacionesFormulario">Aplicación</label>
            <div class="form-group input-group">
                <input id="txtaplicacionWebvVerUsuariosOperacionesFormulario" onblur="leaveHelpAplicacionesWeb('#txtaplicacionWebIdUsuariosOperacionesFormulario','#txtDescripcionAplicacionWeb')" type="text" class="form-control">
                <input id="txtaplicacionWebIdUsuariosOperacionesFormulario" hidden="hidden" type="text">
                <span class="input-group-btn">
                    <a onclick="btnOpenHelpAplicacionesWeb('#txtaplicacionWebIdUsuariosOperacionesFormulario','#txtaplicacionWebvVerUsuariosOperacionesFormulario' ,'#txtDescripcionAplicacionWeb')" class="btn btn-default" type="button">
                        <i class="fa fa-search"></i>
                    </a>
                </span>
            </div>
        </div>
        <div class="col-sm-6">
           
            <br />
            <input id="txtDescripcionAplicacionWeb" type="text" disabled class="form-control">
        </div>

    </div>
    <div class="row">
        <div class="col-sm-6">
            
            <label id="lblmenuIdUsuariosOperacionesFormulario">menuId</label>
            <div class="form-group input-group">
                <input id="txtmenuVerUsuariosOperacionesFormulario" onblur="leaveHelpMenu('#txtmenuIdUsuariosOperacionesFormulario','#txtDescripcionMenus')" type="text" class="form-control">
                <input id="txtmenuIdUsuariosOperacionesFormulario" hidden="hidden" type="text">
                <span class="input-group-btn">
                    <a onclick="btnOpenHelpMenu('#txtmenuIdUsuariosOperacionesFormulario','#txtmenuVerUsuariosOperacionesFormulario' ,'#txtDescripcionMenus')" class="btn btn-default" type="button">
                        <i class="fa fa-search"></i>
                    </a>
                </span>
            </div>
        </div>
        <div class="col-sm-6">
            
            <br />
            <input id="txtDescripcionMenus" type="text" disabled class="form-control">
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            
            <label id="lblFormularioUsuariosOperacionesFormulario">Formulario</label>
            <input id="txtnombreFormularioUsuariosOperacionesFormulario" type="text" class="form-control">
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <button id="btnbuscar" onclick="btnBuscar()" type="button" class="btn btn-default">Buscar</button>
        </div>
    </div>

    <input id="txtIdOperacionesFormulario" hidden="hidden" type="text" />
    <div class="subject-info-box-1">
        Operaciones sin Asignar
        <select multiple="multiple" id='lstBox1' class="form-control" style="height: 300px">
        </select>
    </div>

    <div class="subject-info-arrows text-center">
        <input type="button" id="btnAllRight" value=">>" class="btn btn-default" /><br />
        <input type="button" id="btnRight" value=">" class="btn btn-default" /><br />
        <input type="button" id="btnLeft" value="<" class="btn btn-default" /><br />
        <input type="button" id="btnAllLeft" value="<<" class="btn btn-default" />
    </div>

    <div class="subject-info-box-2">
        Operaciones Asignadas
        <select multiple="multiple" id='lstBox2' class="form-control" style="height: 300px">
        </select>
    </div>

    <div class="clearfix"></div>
    <a id="btnOperacionesFormulario" onclick="btnUsuariosOperacionesFormulario_GuardarClick()" class="btn btn-success">Guardar</a>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceFoot" runat="server">
     <script>
         (function () {
             $('#btnRight').click(function (e) {
                 var selectedOpts = $('#lstBox1 option:selected');
                 if (selectedOpts.length == 0) {
                     tipoAlerta("No hay elementos a mover.", "warning", "#boxMessagesCrud");
                     e.preventDefault();
                 }

                 $('#lstBox2').append($(selectedOpts).clone());
                 $(selectedOpts).remove();
                 e.preventDefault();
             });

             $('#btnAllRight').click(function (e) {
                 var selectedOpts = $('#lstBox1 option');
                 if (selectedOpts.length == 0) {
                     tipoAlerta("No hay elementos a mover.", "warning", "#boxMessagesCrud");
                     e.preventDefault();
                 }

                 $('#lstBox2').append($(selectedOpts).clone());
                 $(selectedOpts).remove();
                 e.preventDefault();
             });

             $('#btnLeft').click(function (e) {
                 var selectedOpts = $('#lstBox2 option:selected');
                 if (selectedOpts.length == 0) {
                     tipoAlerta("No hay elementos a mover.", "warning", "#boxMessagesCrud");
                     e.preventDefault();
                 }

                 $('#lstBox1').append($(selectedOpts).clone());
                 $(selectedOpts).remove();
                 e.preventDefault();
             });

             $('#btnAllLeft').click(function (e) {
                 var selectedOpts = $('#lstBox2 option');
                 if (selectedOpts.length == 0) {
                     tipoAlerta("No hay elementos a mover.", "warning", "#boxMessagesCrud");
                     e.preventDefault();
                 }

                 $('#lstBox1').append($(selectedOpts).clone());
                 $(selectedOpts).remove();
                 e.preventDefault();
             });
         }(jQuery));
    </script>
    <script src="../Js/Forms/UsuariosOperacionesFormulario.js"></script>
    <script src="../Js/frmHelp.js"></script>
    <script>
<% string usuariosOperacionesFormularioIdString = Request.QueryString["id"];
        int usuariosOperacionesFormularioId = 0;
        int.TryParse(usuariosOperacionesFormularioIdString, out usuariosOperacionesFormularioId);
        string jsonUsuariosOperacionesFormulario = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.UsuariosController().getUsuariosId(usuariosOperacionesFormularioId)); %>
        usuariosOperacionesFormulario = <%= jsonUsuariosOperacionesFormulario %>
        getListaOperacionesFormularioUsuario(usuariosOperacionesFormulario.id);
        getListaOperacionesFormulario(usuariosOperacionesFormulario.id);
    </script>
</asp:Content>
