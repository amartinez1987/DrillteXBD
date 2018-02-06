//atributos del objecto barrios
var barrios = new Object();
function cargarDatos(barrios) {
    $('#PanelIDBarrios').show();
    $('#txtIdBarrios').val(barrios.id);
    $('#txtmunicipioIdBarrios').val(barrios.municipioId);
    $('#txtMunicipiosVerBarrios').val(barrios.codigoDaneDepartamentoMunicipio);
    $('#txtDescripcionMunicipios').val(barrios.nombreDepartamentoMunicipio);
    $('#txtnombreBarrios').val(barrios.nombre);
}

function croosModalClick() {
    cargarListaBarrios();
}

function btnBarrios_NuevoClick() {
    loadUrlModal('Nueva Barrios', 'frmBarrios_Nuevo.aspx', croosModalClick);
}

function btnBarrios_GuardarClick() {
    if (validarCampos()) {
        barrios.id = 0;
        barrios.municipioId = $('#txtmunicipioIdBarrios').val();
        barrios.usuarioId = getLocalStorageNavegator("usuarioId");
        barrios.nombre = $('#txtnombreBarrios').val();
        var url = "/WebMethods/barrios.aspx/guardar";
        enviarComoParametros(url, barrios, OnSuccesSaveBarrios);
    }
}

function btnBarrios_EditarClick() {
    if (validarCampos()) {
        barrios.id = $('#txtIdBarrios').val();
        barrios.municipioId = $('#txtmunicipioIdBarrios').val();
        barrios.usuarioId = getLocalStorageNavegator("usuarioId");
        barrios.nombre = $('#txtnombreBarrios').val();
        var url = "/WebMethods/barrios.aspx/guardar";
        enviarComoParametros(url, barrios, OnSuccesSaveBarrios);
    }
}

function OnSuccesSaveBarrios(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnBarrios_Editar(id) {
    loadUrlModal('Editar Barrios', ('frmBarrios_Editar.aspx?id=' + id), croosModalClick);
}

function btnBarrios_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        barrios.id = id;
        barrios.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/barrios.aspx/eliminar";
        enviarComoParametros(url, barrios, OnSuccesDeleteBarrios);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteBarrios(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaBarrios();
        return;
    }
}

function getListaBarrios(valorBuscado, registroPartida, totalAExtraer, callbackFucntion) {
    barrios.valorBuscado = valorBuscado;
    barrios.registroPartida = registroPartida;
    barrios.totalAExtraer = totalAExtraer;
    barrios.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/barrios.aspx/getListaBarrios";
    enviarComoParametros(url, barrios, callbackFucntion);
}
function validarCampos() {

   

    if ($('#txtmunicipioIdBarrios').val() == 0) {
        tipoAlerta('El campo municipio no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtnombreBarrios').val() == 0) {
        tipoAlerta('El campo nombre no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaBarrios() {
    table = $('#gridListaBarrios');

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
            var lstBarrios;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaBarrios($("#txtSearch").val(), data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstBarrios = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstBarrios.length; i++) {
                        var etiquetaEditar = "<a onclick='btnBarrios_Editar(" + lstBarrios[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnBarrios_Eliminar(" + lstBarrios[i].id + ")'><a>";
                        out.push([etiquetaEditar + etiquetaEliminar, lstBarrios[i].nombre, lstBarrios[i].nombreDepartamentoMunicipio, lstBarrios[i].codigoDaneDepartamentoMunicipio]);
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
    help.tabla = 'Municipios';
    help.header = 'Listado';
    help.columnas = ['codigoDaneDepartamentoMunicipio', 'nombreDepartamentoMunicipio'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "nombreDepartamentoMunicipio";
    help.atributoReturnView = "codigoDaneDepartamentoMunicipio";
    loadHelp('Help', cargarTabla());
}

function leaveHelp(campoIdReturn, campoDescripReturn) {
    help.tabla = 'Municipios';
    help.valorBuscar = $("#txtMunicipiosVerBarrios").val();
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
            $(help.campoDescripReturn).val(object.nombreDepartamentoMunicipio);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e) {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }

        return;
    }
}


function btnOnSearch() {
    cargarListaBarrios();
}
