//atributos del objecto aplicacionesWeb
var aplicacionesWeb = new Object();

function cargarDatos(aplicacionWeb)
{    
    $('#PanelIDAplicacionesWeb').show();
    $('#txtIdAplicacionesWeb').val(aplicacionWeb.id);
    $('#txtNombreAplicacionesWeb').val(aplicacionWeb.nombre);
    $('#txtDescripcionAplicacionesWeb').val(aplicacionWeb.descripcion);
}

function croosModalClick()
{
    cargarListaAplicacionesWeb();    
}

function btnAplicacionesWeb_NuevoClick()
{
    loadUrlModal('Nueva Aplicación Web', 'frmAplicacionesWeb_Nuevo.aspx', croosModalClick);
}

function btnAplicacionesWeb_GuardarClick()
{   
    if (validarCampos())
    {            
        aplicacionesWeb.id = 0;
        aplicacionesWeb.nombre = $('#txtNombreAplicacionesWeb').val() ;
        aplicacionesWeb.descripcion = $('#txtDescripcionAplicacionesWeb').val();
        aplicacionesWeb.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/aplicacionesWeb.aspx/guardar";
        enviarComoParametros(url, aplicacionesWeb, OnSuccesSaveAplicacionesWeb);
    }   
}

function btnAplicacionesWeb_EditarClick()
{
    if (validarCampos())
    {
        aplicacionesWeb.id = $('#txtIdAplicacionesWeb').val();
        aplicacionesWeb.nombre = $('#txtNombreAplicacionesWeb').val();
        aplicacionesWeb.descripcion = $('#txtDescripcionAplicacionesWeb').val();
        aplicacionesWeb.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/aplicacionesWeb.aspx/guardar";
        enviarComoParametros(url, aplicacionesWeb, OnSuccesSaveAplicacionesWeb);
    }
}

function OnSuccesSaveAplicacionesWeb(response)
{
    if ((response.error == null ? "" : response.error) != "")
    {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }

    if (response.error == '')
    {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}


function btnAplicacionesWeb_Editar(id)
{
    loadUrlModal('Editar Aplicación Web', ('frmAplicacionesWeb_Editar.aspx?id=' + id), croosModalClick);
}

function btnAplicacionesWeb_Eliminar(id)
{
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';

    var callback = function ()
    {
        aplicacionesWeb.id = id;
        aplicacionesWeb.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/aplicacionesWeb.aspx/eliminar";
        enviarComoParametros(url, aplicacionesWeb, OnSuccesDeleteAplicacionesWeb);
    };

    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}


function OnSuccesDeleteAplicacionesWeb(response)
{
    if ((response.error == null ? "" : response.error) != "")
    {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }

    if (response.error == '')
    {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaAplicacionesWeb();
        return;
    }
}

function getListaAplicacionesWeb(registroPartida, totalAExtraer, callbackFucntion)
{
    aplicacionesWeb.registroPartida = registroPartida;
    aplicacionesWeb.totalAExtraer = totalAExtraer;
    aplicacionesWeb.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/aplicacionesWeb.aspx/getListaAplicacionesWeb";
    enviarComoParametros(url, aplicacionesWeb, callbackFucntion);
}

function validarCampos()
{
    if ($('#txtNombreAplicacionesWeb').val()=='')
    {
        tipoAlerta('El campo nombre no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    }

    if ($('#txtDescripcionAplicacionesWeb').val()=='')
    {
        tipoAlerta('El campo descripción no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    }
    return true;
}

function cargarListaAplicacionesWeb()
{
    table = $('#gridListaAplicacionesWeb');

    if ($.fn.dataTable.isDataTable(table))
    {
        table.DataTable();       
    }

    table.DataTable(
    {
        serverSide: true,
        ordering: false,
        searching: false,
        processing: true,
        destroy:true,
        language: {
            "processing": "Actualizando Datos"
        },
        ajax: function (data, callback, settings)
        {
            var out = [];
            var lstAplicacionesWeb;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaAplicacionesWeb(data.start, data.length, function (response)
            {

                if ((response.error == null ? "" : response.error) != "")
                {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '')
                {
                    lstAplicacionesWeb = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstAplicacionesWeb.length; i++)
                    {
                        var etiquetaEditar = "<a  onclick = 'btnAplicacionesWeb_Editar(" + lstAplicacionesWeb[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = "<a  class='fa fa-minus' onclick='btnAplicacionesWeb_Eliminar(" + lstAplicacionesWeb[i].id + ")'><a>";
                        out.push([etiquetaEditar + etiquetaEliminar, lstAplicacionesWeb[i].nombre, lstAplicacionesWeb[i].descripcion]);
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