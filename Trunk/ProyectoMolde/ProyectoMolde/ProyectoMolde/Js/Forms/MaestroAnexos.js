//atributos del objecto maestroAnexos
var maestroAnexos = new Object();
function cargarDatos(maestroAnexos) {
    $('#PanelIDMaestroAnexos').show();
    $('#txtIdMaestroAnexos').val(maestroAnexos.id);    
    $('#txttablaMaestroAnexos').val(maestroAnexos.tabla);
}

function croosModalClick() {
    cargarListaMaestroAnexos();
}

function btnMaestroAnexos_NuevoClick() {
    loadUrlModal('Nuevo Maestro Anexos', 'frmMaestroAnexos_Nuevo.aspx', croosModalClick);
}

function btnMaestroAnexos_GuardarClick() {
    if (validarCampos()) {
        maestroAnexos.id = 0;
        maestroAnexos.usuarioId = getLocalStorageNavegator("usuarioId");
        maestroAnexos.tabla = $('#txttablaMaestroAnexos').val();
        var url = "/WebMethods/maestroAnexos.aspx/guardar";
        enviarComoParametros(url, maestroAnexos, OnSuccesSaveMaestroAnexos);
    }
}

function btnMaestroAnexos_EditarClick() {
    if (validarCampos()) {
        maestroAnexos.id = $('#txtIdMaestroAnexos').val();
        maestroAnexos.usuarioId = getLocalStorageNavegator("usuarioId");
        maestroAnexos.tabla = $('#txttablaMaestroAnexos').val();
        var url = "/WebMethods/maestroAnexos.aspx/guardar";
        enviarComoParametros(url, maestroAnexos, OnSuccesSaveMaestroAnexos);
    }
}

function OnSuccesSaveMaestroAnexos(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnMaestroAnexos_Editar(id) {
    loadUrlModal('Editar MaestroAnexos', ('frmMaestroAnexos_Editar.aspx?id=' + id), croosModalClick);
}

function btnMaestroAnexos_OpcionesAnexos(id)
{
    loadUrlModal('Tipos Anexo', ('frmListaOpcionesMaestroAnexos.aspx?id=' + id), croosModalClick);
}

function btnMaestroAnexos_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        maestroAnexos.id = id;
        maestroAnexos.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/maestroAnexos.aspx/eliminar";
        enviarComoParametros(url, maestroAnexos, OnSuccesDeleteMaestroAnexos);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteMaestroAnexos(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaMaestroAnexos();
        return;
    }
}

function getListaMaestroAnexos(registroPartida, totalAExtraer, callbackFucntion) {
    maestroAnexos.registroPartida = registroPartida;
    maestroAnexos.totalAExtraer = totalAExtraer;
    maestroAnexos.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/maestroAnexos.aspx/getListaMaestroAnexos";
    enviarComoParametros(url, maestroAnexos, callbackFucntion);
}
function validarCampos()
{
    if ($('#txttablaMaestroAnexos').val() == '')
    {
        tipoAlerta('El campo tabla no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaMaestroAnexos() {
    table = $('#gridListaMaestroAnexos');

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
            var lstMaestroAnexos;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaMaestroAnexos(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstMaestroAnexos = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstMaestroAnexos.length; i++) {
                        var etiquetaEditar = "<a onclick='btnMaestroAnexos_Editar(" + lstMaestroAnexos[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnMaestroAnexos_Eliminar(" + lstMaestroAnexos[i].id + ")'><a>";
                        var etiquetaOpcionesAnexos = " <a class='fa fa-gears' onclick='btnMaestroAnexos_OpcionesAnexos(" + lstMaestroAnexos[i].id + ")'><a>";
                        out.push([etiquetaEditar + etiquetaEliminar + etiquetaOpcionesAnexos, lstMaestroAnexos[i].tabla]);
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
