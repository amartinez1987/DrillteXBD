//atributos del objecto operacionesFormulario
var operacionesFormulario = new Object();
var formulario = new Object();

function getListaOperacionesFormulario(id)
{    
    operacionesFormulario.id = id ;
    operacionesFormulario.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/operacionesFormulario.aspx/getListaOperacionesDelFormulario";
    enviarComoParametros(url, operacionesFormulario, OnSuccesListaOperacionesFormulario);
}


function getListaOperaciones(id)
{    
    operacionesFormulario.id = id;
    operacionesFormulario.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/operacionesFormulario.aspx/getListaNoOperacionesFormulario";
    enviarComoParametros(url, operacionesFormulario, OnSuccesListaOperaciones);
}

function OnSuccesListaOperacionesFormulario(response)
{
    lstOperacionesFormulario = eval("(" + response.getCadena + ")");
    for (var x = 0; x < lstOperacionesFormulario.length;x++ )
    {
        $('#lstBox2').append('<option value="' + lstOperacionesFormulario[x].operacionId + '">' + lstOperacionesFormulario[x].nombreOperacion + '</option>');
    }
}

function OnSuccesListaOperaciones(response)
{
    lstOperaciones = eval("(" + response.getCadena + ")");
    for (var x = 0; x < lstOperaciones.length; x++) {
        $('#lstBox1').append('<option value="' + lstOperaciones[x].id + '">' + lstOperaciones[x].nombreOperacion + '</option>');
    }
}


function btnOperacionesFormulario_GuardarClick()
{

    // get txn id from current table row
    var heading = 'Guardar Registro';
    var question = '¿Esta seguro realizar esta acci&oacute;n?. NOTA: Todos los usuarios y perfiles que tengan esa operacion sera removida, y se asiganran las nuevas operaciones.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function ()
    {
        var lstOperacionesFormulario = new Array();
        for (var x = 0; x < $("#lstBox2")[0].options.length; x++) {
            var oF = new Object();
            oF.id = 0;
            oF.formularioId = operacionesFormulario.id;
            oF.operacionId = $("#lstBox2")[0].options[x].value;
            oF.usuarioId = getLocalStorageNavegator("usuarioId");
            lstOperacionesFormulario.push(oF);
        }

        var paramObjectOf = new Object();
        paramObjectOf.operacionesFormulario = lstOperacionesFormulario;
        paramObjectOf.usuarioId = getLocalStorageNavegator("usuarioId");

        var url = "/WebMethods/operacionesFormulario.aspx/guardar";
        enviarComoParametros(url, paramObjectOf, OnSuccesSaveOperacionesFormulario);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);

    
    

}


function OnSuccesSaveOperacionesFormulario(response)
{
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }

    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}
