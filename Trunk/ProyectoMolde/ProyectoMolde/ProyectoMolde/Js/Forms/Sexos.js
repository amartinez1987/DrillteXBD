//atributos del objecto sexos
var sexos = new Object();
function cargarDatos(sexos) {
    $('#PanelIDSexos').show();
    $('#txtIdSexos').val(sexos.id);
    $('#txtsiglaSexos').val(sexos.sigla);
    $('#txtdescripcionSexos').val(sexos.descripcion);
}

function croosModalClick() {
    cargarListaSexos();
}

function btnSexos_NuevoClick() {
    loadUrlModal('Nueva Sexos', 'frmSexos_Nuevo.aspx', croosModalClick);
}

function btnSexos_GuardarClick() {
    if (validarCampos()) {
        sexos.id = 0;
        sexos.usuarioId = getLocalStorageNavegator("usuarioId");
        sexos.sigla = $('#txtsiglaSexos').val();
        sexos.descripcion = $('#txtdescripcionSexos').val();
        var url = "/WebMethods/sexos.aspx/guardar";
        enviarComoParametros(url, sexos, OnSuccesSaveSexos);
    }
}

function btnSexos_EditarClick() {
    if (validarCampos()) {
        sexos.id = $('#txtIdSexos').val();
        sexos.usuarioId = getLocalStorageNavegator("usuarioId");
        sexos.sigla = $('#txtsiglaSexos').val();
        sexos.descripcion = $('#txtdescripcionSexos').val();
        var url = "/WebMethods/sexos.aspx/guardar";
        enviarComoParametros(url, sexos, OnSuccesSaveSexos);
    }
}

function OnSuccesSaveSexos(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnSexos_Editar(id) {
    loadUrlModal('Editar Sexos', ('frmSexos_Editar.aspx?id=' + id), croosModalClick);
}

function btnSexos_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        sexos.id = id;
        sexos.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/sexos.aspx/eliminar";
        enviarComoParametros(url, sexos, OnSuccesDeleteSexos);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteSexos(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaSexos();
        return;
    }
}

function getListaSexos(registroPartida, totalAExtraer, callbackFucntion) {
    sexos.registroPartida = registroPartida;
    sexos.totalAExtraer = totalAExtraer;
    sexos.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/sexos.aspx/getListaSexos";
    enviarComoParametros(url, sexos, callbackFucntion);
}
function validarCampos() {

    if ($('#txtIdsexos').val() == 0) {
        tipoAlerta('El campo id no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtsiglaSexos').val() == 0) {
        tipoAlerta('El campo sigla no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtdescripcionSexos').val() == 0) {
        tipoAlerta('El campo descripcion no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaSexos() {
    table = $('#gridListaSexos');

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
        responsive: true,
        language: {
            "processing": "Actualizando Datos"
        },
        ajax: function (data, callback, settings) {
            var out = [];
            var lstSexos;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaSexos(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstSexos = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstSexos.length; i++) {
                        var etiquetaEditar = "<a onclick='btnSexos_Editar(" + lstSexos[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnSexos_Eliminar(" + lstSexos[i].id + ")'><a>";
                        out.push(["",etiquetaEditar + etiquetaEliminar, lstSexos[i].sigla, lstSexos[i].descripcion]);
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
