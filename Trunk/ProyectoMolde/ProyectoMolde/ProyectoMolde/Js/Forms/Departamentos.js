//atributos del objecto departamentos
var departamentos = new Object();
function cargarDatos(departamentos) {
    $('#PanelIDDepartamentos').show();
    $('#txtIdDepartamentos').val(departamentos.id);    
    $('#txtnombreDepartamentos').val(departamentos.nombre);
    $('#txtcodigoDaneDepartamentos').val(departamentos.codigoDane);
}

function croosModalClick() {
    cargarListaDepartamentos();
}

function btnDepartamentos_NuevoClick() {
    loadUrlModal('Nuevo Departamento', 'frmDepartamentos_Nuevo.aspx', croosModalClick);
}

function btnDepartamentos_GuardarClick() {
    if (validarCampos()) {
        departamentos.id = 0;
        departamentos.usuarioId = getLocalStorageNavegator("usuarioId");
        departamentos.nombre = $('#txtnombreDepartamentos').val();
        departamentos.codigoDane = $('#txtcodigoDaneDepartamentos').val();
        var url = "/WebMethods/departamentos.aspx/guardar";
        enviarComoParametros(url, departamentos, OnSuccesSaveDepartamentos);
    }
}

function btnDepartamentos_EditarClick() {
    if (validarCampos()) {
        departamentos.id = $('#txtIdDepartamentos').val();
        departamentos.usuarioId = getLocalStorageNavegator("usuarioId");
        departamentos.nombre = $('#txtnombreDepartamentos').val();
        departamentos.codigoDane = $('#txtcodigoDaneDepartamentos').val();
        var url = "/WebMethods/departamentos.aspx/guardar";
        enviarComoParametros(url, departamentos, OnSuccesSaveDepartamentos);
    }
}

function OnSuccesSaveDepartamentos(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnDepartamentos_Editar(id) {
    loadUrlModal('Editar Departamentos', ('frmDepartamentos_Editar.aspx?id=' + id), croosModalClick);
}

function btnDepartamentos_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        departamentos.id = id;
        departamentos.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/departamentos.aspx/eliminar";
        enviarComoParametros(url, departamentos, OnSuccesDeleteDepartamentos);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteDepartamentos(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaDepartamentos();
        return;
    }
}

function getListaDepartamentos(registroPartida, totalAExtraer, callbackFucntion) {
    departamentos.registroPartida = registroPartida;
    departamentos.totalAExtraer = totalAExtraer;
    departamentos.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/departamentos.aspx/getListaDepartamentos";
    enviarComoParametros(url, departamentos, callbackFucntion);
}

function validarCampos()
{
    
    if ($('#txtnombreDepartamentos').val() == '')
    {
        tipoAlerta('El campo nombre no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaDepartamentos() {
    table = $('#gridListaDepartamentos');

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
            var lstDepartamentos;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaDepartamentos(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstDepartamentos = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstDepartamentos.length; i++) {
                        var etiquetaEditar = "<a onclick='btnDepartamentos_Editar(" + lstDepartamentos[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnDepartamentos_Eliminar(" + lstDepartamentos[i].id + ")'><a>";
                        out.push([etiquetaEditar + etiquetaEliminar, lstDepartamentos[i].nombre, lstDepartamentos[i].codigoDane]);
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
