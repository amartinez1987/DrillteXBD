//atributos del objecto operaciones
var operaciones = new Object();
function cargarDatos(operaciones)
{
    $('#PanelIDOperaciones').show();
    $('#txtIdOperaciones').val(operaciones.id);  
    $('#txtnombreOperacionOperaciones').val(operaciones.nombreOperacion);    
    $('#chvisualizaFormularioMenuOperaciones').prop({ checked: operaciones.visualizaFormularioMenu });
}

function croosModalClick() {
    cargarListaOperaciones();
}

function btnOperaciones_NuevoClick() {
    loadUrlModal('Nueva Operaciones', 'frmOperaciones_Nuevo.aspx', croosModalClick);
}

function btnOperaciones_GuardarClick() {
    if (validarCampos())
    {
        operaciones.id = 0;
        operaciones.usuarioId = getLocalStorageNavegator("usuarioId");
        operaciones.nombreOperacion = $('#txtnombreOperacionOperaciones').val();
        operaciones.visualizaFormularioMenu = $('#chvisualizaFormularioMenuOperaciones').is(":checked");        
        var url = "/WebMethods/operaciones.aspx/guardar";
        enviarComoParametros(url, operaciones, OnSuccesSaveOperaciones);
    }
}

function btnOperaciones_EditarClick() {
    if (validarCampos()) {
        operaciones.id = $('#txtIdOperaciones').val();
        operaciones.usuarioId = getLocalStorageNavegator("usuarioId");
        operaciones.nombreOperacion = $('#txtnombreOperacionOperaciones').val();
        operaciones.visualizaFormularioMenu = $('#chvisualizaFormularioMenuOperaciones').is(":checked");
        var url = "/WebMethods/operaciones.aspx/guardar";
        enviarComoParametros(url, operaciones, OnSuccesSaveOperaciones);
    }
}

function OnSuccesSaveOperaciones(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnOperaciones_Editar(id) {
    loadUrlModal('Editar Operaciones', ('frmOperaciones_Editar.aspx?id=' + id), croosModalClick);
}

function btnOperaciones_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        operaciones.id = id;
        operaciones.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/operaciones.aspx/eliminar";
        enviarComoParametros(url, operaciones, OnSuccesDeleteOperaciones);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteOperaciones(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaOperaciones();
        return;
    }
}

function getListaOperaciones(registroPartida, totalAExtraer, callbackFucntion) {
    operaciones.registroPartida = registroPartida;
    operaciones.totalAExtraer = totalAExtraer;
    operaciones.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/operaciones.aspx/getListaOperaciones";
    enviarComoParametros(url, operaciones, callbackFucntion);
}
function validarCampos() {  

    if ($('#txtnombreOperacionOperaciones').val() == 0) {
        tipoAlerta('El campo nombreOperacion no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaOperaciones() {
    table = $('#gridListaOperaciones');

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
            var lstOperaciones;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaOperaciones(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstOperaciones = eval("(" + response.getCadena + ")");
                    console.log(lstOperaciones);
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstOperaciones.length; i++) {
                        var etiquetaEditar = "<a onclick='btnOperaciones_Editar(" + lstOperaciones[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnOperaciones_Eliminar(" + lstOperaciones[i].id + ")'><a>";
                        out.push([etiquetaEditar + etiquetaEliminar, lstOperaciones[i].nombreOperacion, lstOperaciones[i].visualizaFormularioMenu]);
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
