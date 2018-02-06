//atributos del objecto usuariosOperacionesFormulario
var usuariosOperacionesFormulario = new Object();
var usuario = new Object();

function getListaOperacionesFormularioUsuario(id)
{
    usuariosOperacionesFormulario.id = id;
    usuariosOperacionesFormulario.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/usuariosOperacionesFormulario.aspx/getListaOperacionesFormularioDelUsuario";
    enviarComoParametros(url, usuariosOperacionesFormulario, OnSuccesListaOperacionesFormularioUsuario);
}

function OnSuccesListaOperacionesFormularioUsuario(response)
{
    lstOperacionesFormularioUsuario = eval("(" + response.getCadena + ")");
    for (var x = 0; x < lstOperacionesFormularioUsuario.length; x++)
    {
        $('#lstBox2').append('<option value="' + lstOperacionesFormularioUsuario[x].operacionFormularioId + '">' + lstOperacionesFormularioUsuario[x].nombreOperacionFormulario + '</option>');
    }
}

function getListaOperacionesFormulario(id)
{
    usuariosOperacionesFormulario.id = id;
    console.log(usuariosOperacionesFormulario);
    usuariosOperacionesFormulario.aplicacionId = $('#txtaplicacionWebIdUsuariosOperacionesFormulario').val() == "" ? 0 : $('#txtaplicacionWebIdUsuariosOperacionesFormulario').val();
    usuariosOperacionesFormulario.menuId = $('#txtmenuIdUsuariosOperacionesFormulario').val() == "" ? 0 : $('#txtmenuIdUsuariosOperacionesFormulario').val();
    usuariosOperacionesFormulario.nombreFormulario = $('#txtnombreFormularioUsuariosOperacionesFormulario').val();
    usuariosOperacionesFormulario.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/usuariosOperacionesFormulario.aspx/getListaNoOperacionesFormularioDelUsuario";
    enviarComoParametros(url, usuariosOperacionesFormulario, OnSuccesListaOperacionesFormulario);
}

function OnSuccesListaOperacionesFormulario(response)
{
    $("#lstBox1").empty();
    lstOperacionesFormulario = eval("(" + response.getCadena + ")");
    for (var x = 0; x < lstOperacionesFormulario.length; x++)
    {
        $('#lstBox1').append('<option value="' + lstOperacionesFormulario[x].id + '">' + lstOperacionesFormulario[x].nombreFormularioOperacion + '</option>');
    }
}



function btnUsuariosOperacionesFormulario_GuardarClick()
{

    // get txn id from current table row
    var heading = 'Guardar Registro';
    var question = '¿Esta seguro realizar esta acci&oacute;n?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function ()
    {
        console.log($("#lstBox2")[0].options);
        var lstUsuariosOperacionesFormularioU = new Array();
        for (var x = 0; x < $("#lstBox2")[0].options.length; x++) {
            var oFU = new Object();
            oFU.id = 0;
            oFU.usuarioId = usuariosOperacionesFormulario.id;
            oFU.operacionFormularioId = $("#lstBox2")[0].options[x].value;
            oFU.usuarioIdApl = getLocalStorageNavegator("usuarioId");
            lstUsuariosOperacionesFormularioU.push(oFU);
        }

        var paramObjectOf = new Object();
        paramObjectOf.usuariosOperacionesFormulario = lstUsuariosOperacionesFormularioU;
        paramObjectOf.usuarioId = getLocalStorageNavegator("usuarioId");

        var url = "/WebMethods/usuariosOperacionesFormulario.aspx/guardar";
        enviarComoParametros(url, paramObjectOf, OnSuccesSaveOperacionesFormularioUsuarios);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}


function OnSuccesSaveOperacionesFormularioUsuarios(response)
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


function btnBuscar()
{
    getListaOperacionesFormulario(usuariosOperacionesFormulario.id);
}


function btnOpenHelpAplicacionesWeb(campoIdReturn, campoReturnView, campoDescripReturn)
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

function leaveHelpAplicacionesWeb(campoIdReturn, campoDescripReturn)
{
    help.tabla = 'AplicacionesWeb';
    help.valorBuscar = $("#txtaplicacionWebvVerUsuariosOperacionesFormulario").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpAplicacionesWeb();
}


function getHelpAplicacionesWeb()
{
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpAplicacionesWeb);
}

function OnSuccesHelpAplicacionesWeb(response)
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

function btnOpenHelpMenu(campoIdReturn, campoReturnView, campoDescripReturn)
{
    help.tabla = 'Menus';
    help.header = 'Listado';
    help.columnas = ['id', 'nombreMenu'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "nombreMenu";
    help.atributoReturnView = "id";
    loadHelp('Help', cargarTabla());
}

function leaveHelpMenu(campoIdReturn, campoDescripReturn)
{
    help.tabla = 'Menus';
    help.valorBuscar = $("#txtmenuVerUsuariosOperacionesFormulario").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpMenu();
}


function getHelpMenu()
{
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpMenu);
}

function OnSuccesHelpMenu(response)
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
            $(help.campoDescripReturn).val(object.nombreMenu);
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

