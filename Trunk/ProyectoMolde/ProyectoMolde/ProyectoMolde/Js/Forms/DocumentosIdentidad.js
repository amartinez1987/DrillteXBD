//atributos del objecto documentosIdentidad
var documentosIdentidad = new Object();
function cargarDatos(documentosIdentidad) {
    $('#PanelIDDocumentosIdentidad').show();
    $('#txtIdDocumentosIdentidad').val(documentosIdentidad.id);   
    $('#txtsiglaDocumentosIdentidad').val(documentosIdentidad.sigla);
    $('#txtdescripcionDocumentosIdentidad').val(documentosIdentidad.descripcion);
}

function croosModalClick() {
    cargarListaDocumentosIdentidad();
}

function btnDocumentosIdentidad_NuevoClick() {
    loadUrlModal('Nueva DocumentosIdentidad', 'frmDocumentosIdentidad_Nuevo.aspx', croosModalClick);
}

function btnDocumentosIdentidad_GuardarClick() {
    if (validarCampos()) {
        documentosIdentidad.id = 0;
        documentosIdentidad.usuarioId = getLocalStorageNavegator("usuarioId");
        documentosIdentidad.sigla = $('#txtsiglaDocumentosIdentidad').val();
        documentosIdentidad.descripcion = $('#txtdescripcionDocumentosIdentidad').val();
        var url = "/WebMethods/documentosIdentidad.aspx/guardar";
        enviarComoParametros(url, documentosIdentidad, OnSuccesSaveDocumentosIdentidad);
    }
}

function btnDocumentosIdentidad_EditarClick() {
    if (validarCampos()) {
        documentosIdentidad.id = $('#txtIdDocumentosIdentidad').val();
        documentosIdentidad.usuarioId = getLocalStorageNavegator("usuarioId");
        documentosIdentidad.sigla = $('#txtsiglaDocumentosIdentidad').val();
        documentosIdentidad.descripcion = $('#txtdescripcionDocumentosIdentidad').val();
        var url = "/WebMethods/documentosIdentidad.aspx/guardar";
        enviarComoParametros(url, documentosIdentidad, OnSuccesSaveDocumentosIdentidad);
    }
}

function OnSuccesSaveDocumentosIdentidad(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnDocumentosIdentidad_Editar(id) {
    loadUrlModal('Editar DocumentosIdentidad', ('frmDocumentosIdentidad_Editar.aspx?id=' + id), croosModalClick);
}

function btnDocumentosIdentidad_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        documentosIdentidad.id = id;
        documentosIdentidad.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/documentosIdentidad.aspx/eliminar";
        enviarComoParametros(url, documentosIdentidad, OnSuccesDeleteDocumentosIdentidad);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteDocumentosIdentidad(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaDocumentosIdentidad();
        return;
    }
}

function getListaDocumentosIdentidad(registroPartida, totalAExtraer, callbackFucntion) {
    documentosIdentidad.registroPartida = registroPartida;
    documentosIdentidad.totalAExtraer = totalAExtraer;
    documentosIdentidad.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/documentosIdentidad.aspx/getListaDocumentosIdentidad";
    enviarComoParametros(url, documentosIdentidad, callbackFucntion);
}
function validarCampos() {

    if ($('#txtIddocumentosIdentidad').val() == 0) {
        tipoAlerta('El campo id no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtsiglaDocumentosIdentidad').val() == 0) {
        tipoAlerta('El campo sigla no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtdescripcionDocumentosIdentidad').val() == 0) {
        tipoAlerta('El campo descripcion no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaDocumentosIdentidad() {
    table = $('#gridListaDocumentosIdentidad');

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
            var lstDocumentosIdentidad;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaDocumentosIdentidad(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstDocumentosIdentidad = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstDocumentosIdentidad.length; i++) {
                        var etiquetaEditar = "<a onclick='btnDocumentosIdentidad_Editar(" + lstDocumentosIdentidad[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnDocumentosIdentidad_Eliminar(" + lstDocumentosIdentidad[i].id + ")'><a>";
                        out.push(["",etiquetaEditar + etiquetaEliminar, lstDocumentosIdentidad[i].sigla, lstDocumentosIdentidad[i].descripcion]);
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
