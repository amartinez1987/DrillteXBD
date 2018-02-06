//atributos del objecto opcionesMaestroAnexos
var opcionesMaestroAnexos = new Object();
function cargarDatos(opcionesMaestroAnexos) {
    $('#PanelIDOpcionesMaestroAnexos').show();
    $('#txtIdOpcionesMaestroAnexos').val(opcionesMaestroAnexos.id);    
    $('#txtnombreOpcionOpcionesMaestroAnexos').val(opcionesMaestroAnexos.nombreOpcion);
}

function croosModalClick() {
    cargarListaOpcionesMaestroAnexos();
}

function btnOpcionesMaestroAnexos_NuevoClick() {    
    var modalUrl = $('#modalForm');
    modalUrl.find('.modal-body').load('frmOpcionesMaestroAnexos_Nuevo.aspx' );
}

function btnOpcionesMaestroAnexos_CancelarClick()
{
    console.log(maestroAnexos);
    var modalUrl = $('#modalForm');
    modalUrl.find('.modal-body').load('frmListaOpcionesMaestroAnexos.aspx?id=' + maestroAnexos.id);
}

function btnOpcionesMaestroAnexos_GuardarClick() {
    if (validarCampos()) {
        opcionesMaestroAnexos.id = 0;
        opcionesMaestroAnexos.maestroAnexosId = maestroAnexos.id;
        opcionesMaestroAnexos.usuarioId = getLocalStorageNavegator("usuarioId");
        opcionesMaestroAnexos.nombreOpcion = $('#txtnombreOpcionOpcionesMaestroAnexos').val();
        var url = "/WebMethods/opcionesMaestroAnexos.aspx/guardar";
        enviarComoParametros(url, opcionesMaestroAnexos, OnSuccesSaveOpcionesMaestroAnexos);
    }
}

function btnOpcionesMaestroAnexos_EditarClick() {
    if (validarCampos()) {
        opcionesMaestroAnexos.id = $('#txtIdOpcionesMaestroAnexos').val();
        opcionesMaestroAnexos.maestroAnexosId = maestroAnexos.id;
        opcionesMaestroAnexos.usuarioId = getLocalStorageNavegator("usuarioId");
        opcionesMaestroAnexos.nombreOpcion = $('#txtnombreOpcionOpcionesMaestroAnexos').val();
        var url = "/WebMethods/opcionesMaestroAnexos.aspx/guardar";
        enviarComoParametros(url, opcionesMaestroAnexos, OnSuccesSaveOpcionesMaestroAnexos);
    }
}

function OnSuccesSaveOpcionesMaestroAnexos(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnOpcionesMaestroAnexos_Editar(id) {
    var modalUrl = $('#modalForm');
    modalUrl.find('.modal-body').load('frmOpcionesMaestroAnexos_Editar.aspx?id=' + id);    
}

function btnOpcionesMaestroAnexos_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        opcionesMaestroAnexos.id = id;
        opcionesMaestroAnexos.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/opcionesMaestroAnexos.aspx/eliminar";
        enviarComoParametros(url, opcionesMaestroAnexos, OnSuccesDeleteOpcionesMaestroAnexos);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteOpcionesMaestroAnexos(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessagesCrud");
        cargarListaOpcionesMaestroAnexos(maestroAnexos.id);
        return;
    }
}

function getListaOpcionesMaestroAnexos(maestroAnexoId, registroPartida, totalAExtraer, callbackFucntion) {
    opcionesMaestroAnexos.maestroAnexoId = maestroAnexoId;
    opcionesMaestroAnexos.registroPartida = registroPartida;
    opcionesMaestroAnexos.totalAExtraer = totalAExtraer;
    opcionesMaestroAnexos.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/opcionesMaestroAnexos.aspx/getListaOpcionesMaestroAnexos";
    enviarComoParametros(url, opcionesMaestroAnexos, callbackFucntion);
}

function validarCampos() {   

    if ($('#txtnombreOpcionOpcionesMaestroAnexos').val() == 0) {
        tipoAlerta('El campo nombreOpcion no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaOpcionesMaestroAnexos(maestroAnexoId) {
    table = $('#gridListaOpcionesMaestroAnexos');

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
        language: {
            "processing": "Actualizando Datos"
        },
        ajax: function (data, callback, settings) {
            var out = [];
            var lstOpcionesMaestroAnexos;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaOpcionesMaestroAnexos(maestroAnexoId, data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstOpcionesMaestroAnexos = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstOpcionesMaestroAnexos.length; i++) {
                        var etiquetaEditar = "<a onclick='btnOpcionesMaestroAnexos_Editar(" + lstOpcionesMaestroAnexos[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnOpcionesMaestroAnexos_Eliminar(" + lstOpcionesMaestroAnexos[i].id + ")'><a>";
                        out.push([etiquetaEditar + etiquetaEliminar, lstOpcionesMaestroAnexos[i].nombreMaestroAnexo, lstOpcionesMaestroAnexos[i].nombreOpcion]);
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
