var host = "http://" + window.location.host;
var usuarioId = 0;
var aplicacion = "Molde";

function setLocalStorageNavegator(clave, valor) {
    localStorage.setItem(clave, valor);

}

function getLocalStorageNavegator(clave) {
    return localStorage.getItem(clave);
}

function enviarComoParametros(url, objeto, functionResult) {
    var urlComplete = host + url;
    dataParams = getParamsValues(objeto);    
    $.ajax(
    {
        type: "POST",
        url: urlComplete,
        data: dataParams,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (result) {
            return functionResult(result.d)
        }
    });
}

function getParamsValues(objeto)
{
    var arrayParams = "";
    arrayParams = "{";
    var arrayParams = "{";

    for (var atributo in objeto)
    {
        if (objeto.hasOwnProperty(atributo))
        {           
            arrayParams += atributo + ':' + JSON.stringify(objeto[atributo]) + ',';            
        }
    }

    arrayParams = arrayParams.substring(0, arrayParams.length - 1);
    arrayParams += "}";

    if (arrayParams == "}")
    {
        arrayParams = "";
    }


    return arrayParams;
}
