<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmCrudMaster.Master" AutoEventWireup="true" CodeBehind="frmOperacionesFormulario.aspx.cs" Inherits="ProyectoMolde.Forms.frmOperacionesFormulario" %>

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
    <a id="btnOperacionesFormulario" onclick="btnOperacionesFormulario_GuardarClick()" class="btn btn-success">Guardar</a>
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
    <script src="../Js/Forms/OperacionesFormulario.js"></script>
    <script>
<% string operacionesFormularioIdString = Request.QueryString["id"];
        int operacionesFormularioId = 0;
        int.TryParse(operacionesFormularioIdString, out operacionesFormularioId);
        string jsonOperacionesFormulario = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new ControlUsuarios.Entity.Controller.FormulariosController().getFormularios(operacionesFormularioId)); %>
        formulario = <%= jsonOperacionesFormulario %>              
        getListaOperacionesFormulario(formulario.id);
        getListaOperaciones(formulario.id);
    </script>
</asp:Content>
