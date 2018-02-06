//atributos del objecto menus
var menus = new Object();

function cargarDatos(menus) {
    $('#PanelIDMenus').show();
    $('#PanelEstadoMenus').show();
    $('#txtIdMenus').val(menus.id);
    $('#txtaplicacionWebIdMenus').val(menus.aplicacionWebId);
    $('#txtaplicacionWebvVerMenus').val(menus.aplicacionWebId);
    $('#txtDescripcionAplicacionWeb').val(menus.nombreAplicacionWeb);
    $('#txtusuarioIdMenus').val(menus.usuarioId);
    $('#txtindexVisibilidadMenus').val(menus.indexVisibilidad);
    $('#txtnombreMenuMenus').val(menus.nombreMenu);
    $('#txtestadoMenus').val(menus.estado);
    $('#txticonMenus').val(menus.icon);
}

function croosModalClick() {
    cargarListaMenus();
}

function btnMenus_NuevoClick() {
    loadUrlModal('Nueva Menus', 'frmMenus_Nuevo.aspx', croosModalClick);
}

function btnMenus_GuardarClick() {
    if (validarCampos()) {
        menus.id = 0;
        menus.aplicacionWebId = $('#txtaplicacionWebIdMenus').val();
        menus.usuarioId = getLocalStorageNavegator("usuarioId");
        menus.indexVisibilidad = $('#txtindexVisibilidadMenus').val();
        menus.nombreMenu = $('#txtnombreMenuMenus').val();
        menus.estado = $('#txtestadoMenus').val();
        menus.icon = $('#txticonMenus').val();
        var url = "/WebMethods/menus.aspx/guardar";
        enviarComoParametros(url, menus, OnSuccesSaveMenus);
    }
}

function btnMenus_EditarClick() {
    if (validarCampos()) {
        menus.id = $('#txtIdMenus').val();
        menus.aplicacionWebId = $('#txtaplicacionWebIdMenus').val();
        menus.usuarioId = getLocalStorageNavegator("usuarioId");
        menus.indexVisibilidad = $('#txtindexVisibilidadMenus').val();
        menus.nombreMenu = $('#txtnombreMenuMenus').val();
        menus.estado = $('#txtestadoMenus').val();
        menus.icon = $('#txticonMenus').val();
        var url = "/WebMethods/menus.aspx/guardar";
        enviarComoParametros(url, menus, OnSuccesSaveMenus);
    }
}

function OnSuccesSaveMenus(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnMenus_Editar(id) {
    loadUrlModal('Editar Menus', ('frmMenus_Editar.aspx?id=' + id), croosModalClick);
}

function btnMenus_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Inactivar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        menus.id = id;
        menus.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/menus.aspx/eliminar";
        enviarComoParametros(url, menus, OnSuccesDeleteMenus);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeleteMenus(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Inactivado con Exito.', 'success', "#boxMessages");
        cargarListaMenus();
        return;
    }
}

function btnMenus_Activar(id)
{
    // get txn id from current table row
    var heading = 'Activar Registro';
    var question = '¿Desea Activar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function ()
    {
        
        menus.id = id;
        menus.usuarioId = getLocalStorageNavegator("usuarioId");
        console.log(menus);
        var url = "/WebMethods/menus.aspx/activar";
        enviarComoParametros(url, menus, OnSuccesActivarMenus);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);

}

function OnSuccesActivarMenus(response)
{
    if ((response.error == null ? "" : response.error) != "")
    {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }

    if (response.error == '')
    {
        tipoAlerta('Registro Activado con Exito.', 'success', "#boxMessages");
        cargarListaMenus();
        return;
    }
}

function getListaMenus(registroPartida, totalAExtraer, callbackFucntion) {
    menus.registroPartida = registroPartida;
    menus.totalAExtraer = totalAExtraer;
    menus.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/menus.aspx/getListaMenus";
    enviarComoParametros(url, menus, callbackFucntion);
}
function validarCampos() {

   

    if ($('#txtaplicacionWebIdMenus').val() == 0) {
        tipoAlerta('El campo aplicacionWebId no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtindexVisibilidadMenus').val() == 0) {
        tipoAlerta('El campo indexVisibilidad no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtnombreMenuMenus').val() == 0) {
        tipoAlerta('El campo nombreMenu no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

   

    if ($('#txticonMenus').val() == 0) {
        tipoAlerta('El campo icon no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaMenus() {
    table = $('#gridListaMenus');

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
            var lstMenus;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaMenus(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstMenus = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstMenus.length; i++) {
                        var etiquetaEditar = "<a onclick='btnMenus_Editar(" + lstMenus[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnMenus_Eliminar(" + lstMenus[i].id + ")'><a>";
                        var etiquetaActivar = " <a class='fa fa-check' onclick='btnMenus_Activar(" + lstMenus[i].id + ")'><a>";
                        out.push([etiquetaEditar + etiquetaEliminar+ etiquetaActivar, lstMenus[i].nombreMenu, lstMenus[i].nombreAplicacionWeb, lstMenus[i].indexVisibilidad, lstMenus[i].estado, lstMenus[i].icon]);
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

function btnOpenHelp(campoIdReturn,campoReturnView, campoDescripReturn)
{    
    help.tabla = 'AplicacionesWeb';
    help.header = 'Listado';
    help.columnas = ['id', 'nombre'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "nombre";
    help.atributoReturnView = "id";
    loadHelp('Help', cargarTabla());
}

function leaveHelp(campoIdReturn, campoDescripReturn)
{
    help.tabla = 'AplicacionesWeb';
    help.valorBuscar = $("#txtaplicacionWebvVerMenus").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];    
    
    getHelp();
}


function getHelp()
{    
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelp);
}

function OnSuccesHelp(response)
{
    if ((response.error == null ? "" : response.error) != "")
    {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '')
    {
        try
        {
            var object = eval("(" + response.getCadena + ")");
            $(help.campoDescripReturn).val(object.nombre);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e)
        {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }
        
        return;
    }
}