//atributos del objecto formularios
var formularios = new Object();
function cargarDatos(formularios) {
    $('#PanelIDFormularios').show();
    $('#PanelEstadoFormularios').show();
    $('#txtIdFormularios').val(formularios.id);   
    $('#txtmenuIdFormularios').val(formularios.menuId);
    $('#txtmenuVerFormularios').val(formularios.menuId);
    $('#txtDescripcionMenus').val(formularios.nombreMenu);
    $('#txtusuarioIdFormularios').val(formularios.usuarioId);
    $('#txtindexVisibilidadFormularios').val(formularios.indexVisibilidad);
    $('#chesVisibleFormularios').prop({ checked: formularios.esVisible });    
    $('#txtnombreFormularioFormularios').val(formularios.nombreFormulario);
    $('#txturlFormularioFormularios').val(formularios.urlFormulario);
    $('#txtnombreMostrarFormularios').val(formularios.nombreMostrar);
    $('#txtestadosFormularios').val(formularios.estados);
    $('#txticonOpcionFormularios').val(formularios.iconOpcion);
}

function croosModalClick() {
    cargarListaFormularios();
}

function btnFormularios_NuevoClick() {
    loadUrlModal('Nueva Formularios', 'frmFormularios_Nuevo.aspx', croosModalClick);
}

function btnFormularios_GuardarClick() {
    if (validarCampos()) {
        formularios.id = 0;
        formularios.menuId = $('#txtmenuIdFormularios').val();
        formularios.usuarioId = getLocalStorageNavegator("usuarioId");
        formularios.indexVisibilidad = $('#txtindexVisibilidadFormularios').val();        
        formularios.esVisible = $('#chesVisibleFormularios').is(":checked");
        formularios.nombreFormulario = $('#txtnombreFormularioFormularios').val();
        formularios.urlFormulario = $('#txturlFormularioFormularios').val();
        formularios.nombreMostrar = $('#txtnombreMostrarFormularios').val();
        formularios.estados = $('#txtestadosFormularios').val();
        formularios.iconOpcion = $('#txticonOpcionFormularios').val();
        var url = "/WebMethods/formularios.aspx/guardar";
        enviarComoParametros(url, formularios, OnSuccesSaveFormularios);
    }
}

function btnFormularios_EditarClick() {
    if (validarCampos()) {
        formularios.id = $('#txtIdFormularios').val();
        formularios.menuId = $('#txtmenuIdFormularios').val();
        formularios.usuarioId = getLocalStorageNavegator("usuarioId");
        formularios.indexVisibilidad = $('#txtindexVisibilidadFormularios').val();
        formularios.esVisible = $('#chesVisibleFormularios').is(":checked");
        formularios.nombreFormulario = $('#txtnombreFormularioFormularios').val();
        formularios.urlFormulario = $('#txturlFormularioFormularios').val();
        formularios.nombreMostrar = $('#txtnombreMostrarFormularios').val();
        formularios.estados = $('#txtestadosFormularios').val();
        formularios.iconOpcion = $('#txticonOpcionFormularios').val();
        var url = "/WebMethods/formularios.aspx/guardar";
        enviarComoParametros(url, formularios, OnSuccesSaveFormularios);
    }
}

function OnSuccesSaveFormularios(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnFormularios_Editar(id) {
    loadUrlModal('Editar Formularios', ('frmFormularios_Editar.aspx?id=' + id), croosModalClick);
}

function btnFormularios_Inactivar(id) {
    // get txn id from current table row
    var heading = 'Inactivar Registro';
    var question = '¿Desea inactivar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        formularios.id = id;
        formularios.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/formularios.aspx/inactivar";
        enviarComoParametros(url, formularios, OnSuccesDeleteFormularios);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteFormularios(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro inactivado con Exito.', 'success', "#boxMessages");
        cargarListaFormularios();
        return;
    }
}

function btnFormularios_Activar(id) {
    // get txn id from current table row
    var heading = 'Activar Registro';
    var question = '¿Desea activar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        formularios.id = id;
        formularios.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/formularios.aspx/activar";
        enviarComoParametros(url, formularios, OnSuccesActivarFormularios);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesActivarFormularios(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro activado con Exito.', 'success', "#boxMessages");
        cargarListaFormularios();
        return;
    }
}

function getListaFormularios(valorBuscado, registroPartida, totalAExtraer, callbackFucntion) {
    formularios.valorBuscado = valorBuscado;
    formularios.registroPartida = registroPartida;
    formularios.totalAExtraer = totalAExtraer;
    formularios.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/formularios.aspx/getListaFormularios";
    enviarComoParametros(url, formularios, callbackFucntion);
}
function validarCampos()
{   

    if ($('#txtmenuIdFormularios').val() == 0) {
        tipoAlerta('El campo menuId no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtindexVisibilidadFormularios').val() == 0) {
        tipoAlerta('El campo indexVisibilidad no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };    

    if ($('#txtnombreFormularioFormularios').val() == 0) {
        tipoAlerta('El campo nombreFormulario no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txturlFormularioFormularios').val() == 0) {
        tipoAlerta('El campo urlFormulario no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtnombreMostrarFormularios').val() == 0) {
        tipoAlerta('El campo nombreMostrar no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    return true;
}

function cargarListaFormularios() {
    table = $('#gridListaFormularios');
       
    if ($.fn.dataTable.isDataTable(table)) {
        table.DataTable();
    }

    table.DataTable(
    {
        serverSide: true,
        ordering: false,
        searching: false,
        processing: true,
        destroy: true,
        responsive:true,
        language: {
            "processing": "Actualizando Datos"
        },
        ajax: function (data, callback, settings) {
            var out = [];
            var lstFormularios;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaFormularios($("#txtSearch").val(), data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstFormularios = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstFormularios.length; i++) {
                        var etiquetaEditar = "<a onclick='btnFormularios_Editar(" + lstFormularios[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaInactivar = " <a class='fa fa-minus' onclick='btnFormularios_Inactivar(" + lstFormularios[i].id + ")'><a>";
                        var etiquetaActivar = " <a class='fa fa-check' onclick='btnFormularios_Activar(" + lstFormularios[i].id + ")'><a>";
                        var etiquetaOperacionFormularios= " <a class='fa fa-gears' onclick='btnFormularios_Operaciones(" + lstFormularios[i].id + ")'><a>";
                        out.push(["",etiquetaEditar + etiquetaInactivar + etiquetaActivar+etiquetaOperacionFormularios, lstFormularios[i].nombreFormulario, lstFormularios[i].nombreMostrar, lstFormularios[i].nombreMenu, lstFormularios[i].urlFormulario, lstFormularios[i].esVisible, lstFormularios[i].estados]);
                    }

                    setTimeout(callback(
                    {
                        draw: data.draw,
                        data: out,
                        recordsTotal: totalRegistros,
                        recordsFiltered: totalRegistros
                    }), 50);
                }
            });
        }
    });
   
}


function btnOpenHelp(campoIdReturn, campoReturnView, campoDescripReturn) {
    help.tabla = 'Menus';
    help.header = 'Listado';
    help.columnas = ['id', 'nombreMenu'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "nombreMenu";
    help.atributoReturnView = "id";
    loadHelp('Help', cargarTabla());
}

function leaveHelp(campoIdReturn, campoDescripReturn) {
    help.tabla = 'Menus';
    help.valorBuscar = $("#txtmenuVerFormularios").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelp();
}


function getHelp() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelp);
}

function OnSuccesHelp(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        try {
            var object = eval("(" + response.getCadena + ")");
            $(help.campoDescripReturn).val(object.nombreMenu);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e) {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }

        return;
    }
}


function btnOnSearch()
{   
    cargarListaFormularios();
}

function btnFormularios_Operaciones(id)
{    
    loadUrlModal('Operaciones Formulario', ('frmOperacionesFormulario.aspx?id=' + id), croosModalClick);
}