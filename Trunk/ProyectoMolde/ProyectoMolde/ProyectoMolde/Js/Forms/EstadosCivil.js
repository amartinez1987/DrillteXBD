//atributos del objecto estadosCivil
var estadosCivil = new Object();
function cargarDatos(estadosCivil) {
    $('#PanelIDEstadosCivil').show();
    $('#txtIdEstadosCivil').val(estadosCivil.id);
    $('#txtsiglaEstadosCivil').val(estadosCivil.sigla);
    $('#txtdescripcionEstadosCivil').val(estadosCivil.descripcion);
}

function croosModalClick() {
    cargarListaEstadosCivil();
}

function btnEstadosCivil_NuevoClick() {
    loadUrlModal('Nueva EstadosCivil', 'frmEstadosCivil_Nuevo.aspx', croosModalClick);
}

function btnEstadosCivil_GuardarClick() {
    if (validarCampos()) {
        estadosCivil.id = 0;
        estadosCivil.usuarioId = getLocalStorageNavegator("usuarioId");
        estadosCivil.sigla = $('#txtsiglaEstadosCivil').val();
        estadosCivil.descripcion = $('#txtdescripcionEstadosCivil').val();
        var url = "/WebMethods/estadosCivil.aspx/guardar";
        enviarComoParametros(url, estadosCivil, OnSuccesSaveEstadosCivil);
    }
}

function btnEstadosCivil_EditarClick() {
    if (validarCampos()) {
        estadosCivil.id = $('#txtIdEstadosCivil').val();
        estadosCivil.usuarioId = getLocalStorageNavegator("usuarioId");
        estadosCivil.sigla = $('#txtsiglaEstadosCivil').val();
        estadosCivil.descripcion = $('#txtdescripcionEstadosCivil').val();
        var url = "/WebMethods/estadosCivil.aspx/guardar";
        enviarComoParametros(url, estadosCivil, OnSuccesSaveEstadosCivil);
    }
}

function OnSuccesSaveEstadosCivil(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnEstadosCivil_Editar(id) {
    loadUrlModal('Editar EstadosCivil', ('frmEstadosCivil_Editar.aspx?id=' + id), croosModalClick);
}

function btnEstadosCivil_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        estadosCivil.id = id;
        estadosCivil.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/estadosCivil.aspx/eliminar";
        enviarComoParametros(url, estadosCivil, OnSuccesDeleteEstadosCivil);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteEstadosCivil(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaEstadosCivil();
        return;
    }
}

function getListaEstadosCivil(registroPartida, totalAExtraer, callbackFucntion) {
    estadosCivil.registroPartida = registroPartida;
    estadosCivil.totalAExtraer = totalAExtraer;
    estadosCivil.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/estadosCivil.aspx/getListaEstadosCivil";
    enviarComoParametros(url, estadosCivil, callbackFucntion);
}
function validarCampos() {

    if ($('#txtIdestadosCivil').val() == 0) {
        tipoAlerta('El campo id no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtsiglaEstadosCivil').val() == 0) {
        tipoAlerta('El campo sigla no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtdescripcionEstadosCivil').val() == 0) {
        tipoAlerta('El campo descripcion no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaEstadosCivil() {
    table = $('#gridListaEstadosCivil');

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
            var lstEstadosCivil;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaEstadosCivil(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstEstadosCivil = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstEstadosCivil.length; i++) {
                        var etiquetaEditar = "<a onclick='btnEstadosCivil_Editar(" + lstEstadosCivil[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnEstadosCivil_Eliminar(" + lstEstadosCivil[i].id + ")'><a>";
                        out.push(["", etiquetaEditar + etiquetaEliminar, lstEstadosCivil[i].sigla, lstEstadosCivil[i].descripcion]);
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
