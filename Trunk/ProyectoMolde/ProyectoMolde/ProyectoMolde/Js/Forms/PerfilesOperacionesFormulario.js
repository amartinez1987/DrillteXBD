//atributos del objecto perfilesOperacionesFormulario
var perfilesOperacionesFormulario = new Object();
var perfil = new Object();

function getListaOperacionesFormularioPerfiles(id)
{
    perfilesOperacionesFormulario.id = id;   
    perfilesOperacionesFormulario.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/perfilesOperacionesFormulario.aspx/getListaOperacionesFormularioDelPerfiles";
    enviarComoParametros(url, perfilesOperacionesFormulario, OnSuccesListaOperacionesFormularioPerfil);
}

function OnSuccesListaOperacionesFormularioPerfil(response)
{
    lstOperacionesFormularioPerfil = eval("(" + response.getCadena + ")");
    for (var x = 0; x < lstOperacionesFormularioPerfil.length; x++) {
        $('#lstBox2').append('<option value="' + lstOperacionesFormularioPerfil[x].operacionFormularioId + '">' + lstOperacionesFormularioPerfil[x].nombreOperacionFormulario + '</option>');
    }
}

function getListaOperacionesFormulario(id)
{
    perfilesOperacionesFormulario.id = id;
    console.log(perfilesOperacionesFormulario);
    perfilesOperacionesFormulario.aplicacionId = $('#txtaplicacionWebIdPerfilesOperacionesFormulario').val() == "" ? 0 : $('#txtaplicacionWebIdPerfilesOperacionesFormulario').val();
    perfilesOperacionesFormulario.menuId = $('#txtmenuIdPerfilesOperacionesFormulario').val() == "" ? 0 : $('#txtmenuIdPerfilesOperacionesFormulario').val();
    perfilesOperacionesFormulario.nombreFormulario = $('#txtnombreFormularioPerfilesOperacionesFormulario').val();
    perfilesOperacionesFormulario.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/perfilesOperacionesFormulario.aspx/getListaNoOperacionesFormularioDelPerfiles";
    enviarComoParametros(url, perfilesOperacionesFormulario, OnSuccesListaOperacionesFormulario);

}

function OnSuccesListaOperacionesFormulario(response)
{   
    $("#lstBox1").empty();
    lstOperacionesFormulario = eval("(" + response.getCadena + ")");
    for (var x = 0; x < lstOperacionesFormulario.length; x++) {
        $('#lstBox1').append('<option value="' + lstOperacionesFormulario[x].id + '">' + lstOperacionesFormulario[x].nombreFormularioOperacion + '</option>');
    }
}



function btnPerfilesOperacionesFormulario_GuardarClick()
{

    // get txn id from current table row
    var heading = 'Guardar Registro';
    var question = '¿Esta seguro realizar esta acci&oacute;n?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function ()
    {
        console.log($("#lstBox2")[0].options);
        var lstPerfilesOperacionesFormularioP = new Array();
        for (var x = 0; x < $("#lstBox2")[0].options.length; x++) {
            var oFP = new Object();
            oFP.id = 0;
            oFP.perfilId = perfilesOperacionesFormulario.id;
            oFP.operacionFormularioId = $("#lstBox2")[0].options[x].value;
            oFP.usuarioId = getLocalStorageNavegator("usuarioId");
            lstPerfilesOperacionesFormularioP.push(oFP);
        }

        var paramObjectOf = new Object();
        paramObjectOf.perfilesOperacionesFormulario = lstPerfilesOperacionesFormularioP;
        paramObjectOf.usuarioId = getLocalStorageNavegator("usuarioId");

        var url = "/WebMethods/perfilesOperacionesFormulario.aspx/guardar";
        enviarComoParametros(url, paramObjectOf, OnSuccesSaveOperacionesFormularioPerfiles);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);




}


function OnSuccesSaveOperacionesFormularioPerfiles(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }

    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}


function btnBuscar()
{
    getListaOperacionesFormulario(perfilesOperacionesFormulario.id);
}


function btnOpenHelpAplicacionesWeb(campoIdReturn, campoReturnView, campoDescripReturn) {
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

function leaveHelpAplicacionesWeb(campoIdReturn, campoDescripReturn) {
    help.tabla = 'AplicacionesWeb';
    help.valorBuscar = $("#txtaplicacionWebvVerMenus").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpAplicacionesWeb();
}


function getHelpAplicacionesWeb() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpAplicacionesWeb);
}

function OnSuccesHelpAplicacionesWeb(response) {
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

function btnOpenHelpMenu(campoIdReturn, campoReturnView, campoDescripReturn) {
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

function leaveHelpMenu(campoIdReturn, campoDescripReturn) {
    help.tabla = 'Menus';
    help.valorBuscar = $("#txtmenuVerPerfilesOperacionesFormulario").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpMenu();
}


function getHelpMenu() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpMenu);
}

function OnSuccesHelpMenu(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        try {
            var object = eval("(" + response.getCadena + ")");
            $(help.campoDescripReturn).val(object.nombreMenu);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e) {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }

        return;
    }
}

