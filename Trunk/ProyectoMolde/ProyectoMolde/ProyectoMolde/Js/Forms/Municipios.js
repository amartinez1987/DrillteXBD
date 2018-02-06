//atributos del objecto municipios
var municipios = new Object();
function cargarDatos(municipios) {
    $('#PanelIDMunicipios').show();
    $('#txtIdMunicipios').val(municipios.id);
    $('#txtdepartamentosIdMunicipios').val(municipios.departamentoId);
    $('#txtdepartamentosVerMunicipios').val(municipios.codigoDaneDepartamento);
    $('#txtDescripcionDepartamentos').val(municipios.nombreDepartamento);      
    $('#txtnombreMunicipios').val(municipios.nombre);
    $('#txtcodigoDaneMunicipios').val(municipios.codigoDane);
}

function croosModalClick() {
    cargarListaMunicipios();
}

function btnMunicipios_NuevoClick() {
    loadUrlModal('Nueva Municipios', 'frmMunicipios_Nuevo.aspx', croosModalClick);
}

function btnMunicipios_GuardarClick() {
    if (validarCampos()) {
        municipios.id = 0;
        municipios.departamentoId = $('#txtdepartamentosIdMunicipios').val();
        municipios.usuarioId = getLocalStorageNavegator("usuarioId");
        municipios.nombre = $('#txtnombreMunicipios').val();
        municipios.codigoDane = $('#txtcodigoDaneMunicipios').val();
        var url = "/WebMethods/municipios.aspx/guardar";
        enviarComoParametros(url, municipios, OnSuccesSaveMunicipios);
    }
}

function btnMunicipios_EditarClick() {
    if (validarCampos()) {
        municipios.id = $('#txtIdMunicipios').val();
        municipios.departamentoId = $('#txtdepartamentosIdMunicipios').val();
        municipios.usuarioId = getLocalStorageNavegator("usuarioId");
        municipios.nombre = $('#txtnombreMunicipios').val();
        municipios.codigoDane = $('#txtcodigoDaneMunicipios').val();
        var url = "/WebMethods/municipios.aspx/guardar";
        enviarComoParametros(url, municipios, OnSuccesSaveMunicipios);
    }
}

function OnSuccesSaveMunicipios(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnMunicipios_Editar(id) {
    loadUrlModal('Editar Municipios', ('frmMunicipios_Editar.aspx?id=' + id), croosModalClick);
}

function btnMunicipios_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        municipios.id = id;
        municipios.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/municipios.aspx/eliminar";
        enviarComoParametros(url, municipios, OnSuccesDeleteMunicipios);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteMunicipios(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaMunicipios();
        return;
    }
}

function getListaMunicipios(valorBuscado,registroPartida, totalAExtraer, callbackFucntion) {
    municipios.valorBuscado = valorBuscado;
    municipios.registroPartida = registroPartida;
    municipios.totalAExtraer = totalAExtraer;
    municipios.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/municipios.aspx/getListaMunicipios";
    enviarComoParametros(url, municipios, callbackFucntion);
}
function validarCampos() {

    

    if ($('#txtdepartamentosIdMunicipios').val() == 0) {
        tipoAlerta('El campo departamentoId no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtnombreMunicipios').val() == 0) {
        tipoAlerta('El campo nombre no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtcodigoDaneMunicipios').val() == 0) {
        tipoAlerta('El campo codigoDane no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaMunicipios() {
    table = $('#gridListaMunicipios');

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
            var lstMunicipios;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaMunicipios($("#txtSearch").val(), data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstMunicipios = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstMunicipios.length; i++) {
                        var etiquetaEditar = "<a onclick='btnMunicipios_Editar(" + lstMunicipios[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnMunicipios_Eliminar(" + lstMunicipios[i].id + ")'><a>";
                        out.push(["", etiquetaEditar + etiquetaEliminar, lstMunicipios[i].nombre, lstMunicipios[i].codigoDane, lstMunicipios[i].nombreDepartamento, lstMunicipios[i].codigoDaneDepartamento]);
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
    help.tabla = 'Departamentos';
    help.header = 'Listado';
    help.columnas = ['codigoDane', 'nombre'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "nombre";
    help.atributoReturnView = "codigoDane";
    loadHelp('Help', cargarTabla());
}

function leaveHelp(campoIdReturn, campoDescripReturn) {
    help.tabla = 'Departamentos';
    help.valorBuscar = $("#txtdepartamentosVerMunicipios").val();
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
            $(help.campoDescripReturn).val(object.nombre);
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
    cargarListaFormularios();
}
