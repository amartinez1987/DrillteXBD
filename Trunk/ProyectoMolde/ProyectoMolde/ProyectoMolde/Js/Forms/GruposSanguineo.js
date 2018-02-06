//atributos del objecto gruposSanguineo
var gruposSanguineo = new Object();
function cargarDatos(gruposSanguineo) {
    $('#PanelIDGruposSanguineo').show();
    $('#txtIdGruposSanguineo').val(gruposSanguineo.id);    
    $('#txtsiglaGruposSanguineo').val(gruposSanguineo.sigla);
    $('#txtdescripcionGruposSanguineo').val(gruposSanguineo.descripcion);
}

function croosModalClick() {
    cargarListaGruposSanguineo();
}

function btnGruposSanguineo_NuevoClick() {
    loadUrlModal('Nueva GruposSanguineo', 'frmGruposSanguineo_Nuevo.aspx', croosModalClick);
}

function btnGruposSanguineo_GuardarClick() {
    if (validarCampos()) {
        gruposSanguineo.id = 0;
        gruposSanguineo.usuarioId = getLocalStorageNavegator("usuarioId");
        gruposSanguineo.sigla = $('#txtsiglaGruposSanguineo').val();
        gruposSanguineo.descripcion = $('#txtdescripcionGruposSanguineo').val();
        var url = "/WebMethods/gruposSanguineo.aspx/guardar";
        enviarComoParametros(url, gruposSanguineo, OnSuccesSaveGruposSanguineo);
    }
}

function btnGruposSanguineo_EditarClick() {
    if (validarCampos()) {
        gruposSanguineo.id = $('#txtIdGruposSanguineo').val();
        gruposSanguineo.usuarioId = getLocalStorageNavegator("usuarioId");
        gruposSanguineo.sigla = $('#txtsiglaGruposSanguineo').val();
        gruposSanguineo.descripcion = $('#txtdescripcionGruposSanguineo').val();
        var url = "/WebMethods/gruposSanguineo.aspx/guardar";
        enviarComoParametros(url, gruposSanguineo, OnSuccesSaveGruposSanguineo);
    }
}

function OnSuccesSaveGruposSanguineo(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnGruposSanguineo_Editar(id) {
    loadUrlModal('Editar GruposSanguineo', ('frmGruposSanguineo_Editar.aspx?id=' + id), croosModalClick);
}

function btnGruposSanguineo_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        gruposSanguineo.id = id;
        gruposSanguineo.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/gruposSanguineo.aspx/eliminar";
        enviarComoParametros(url, gruposSanguineo, OnSuccesDeleteGruposSanguineo);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteGruposSanguineo(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaGruposSanguineo();
        return;
    }
}

function getListaGruposSanguineo(registroPartida, totalAExtraer, callbackFucntion) {
    gruposSanguineo.registroPartida = registroPartida;
    gruposSanguineo.totalAExtraer = totalAExtraer;
    gruposSanguineo.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/gruposSanguineo.aspx/getListaGruposSanguineo";
    enviarComoParametros(url, gruposSanguineo, callbackFucntion);
}
function validarCampos() {

    
    if ($('#txtsiglaGruposSanguineo').val() == 0) {
        tipoAlerta('El campo sigla no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtdescripcionGruposSanguineo').val() == 0) {
        tipoAlerta('El campo descripcion no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaGruposSanguineo() {
    table = $('#gridListaGruposSanguineo');

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
            var lstGruposSanguineo;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaGruposSanguineo(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstGruposSanguineo = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstGruposSanguineo.length; i++) {
                        var etiquetaEditar = "<a onclick='btnGruposSanguineo_Editar(" + lstGruposSanguineo[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnGruposSanguineo_Eliminar(" + lstGruposSanguineo[i].id + ")'><a>";
                        out.push(["",etiquetaEditar + etiquetaEliminar, lstGruposSanguineo[i].sigla, lstGruposSanguineo[i].descripcion]);
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
