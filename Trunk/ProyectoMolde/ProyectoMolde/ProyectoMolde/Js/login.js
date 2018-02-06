//atributos del objecto Usuario
var usuario = new Object();

$("#btnIngresar").click
(
    function ()
    {
        usuario.nombreUsuario = $("#nombreUsuario").val();
        usuario.clave = $("#clave").val();        
        var url = "/WebMethods/login.aspx/AutenticarUsuario";
        enviarComoParametros(url, usuario, OnSuccessLogin);
    }
);

$("#btnRegistrarse").click
(
    function ()
    {        
        usuario.nombreUsuario = $("#nombreUsuario").val();
        usuario.clave = $("#clave").val();
        usuario.confirmarClave = $("#confirmarClave").val();             
        var url = "/WebMethods/login.aspx/registrarUsuarioParams";
        enviarComoParametros(url, usuario, OnSuccess);
    }
);

$("#btnLogOut").click
(
    function ()
    {
        usuario.usuarioId = getLocalStorageNavegator("usuarioId");
        localStorage.myPageDataArr = undefined;
        var url = "/WebMethods/usuario.aspx/loginOut";
        enviarComoParametros(url, usuario, OnSuccessLoginOut);
    }
);

function OnSuccessLoginOut(response)
{
    console.log(response);
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }

    if (response.error == '')
    {
        var redireccion = host + "/Forms/Usuarios/frmLogin.aspx";
        window.location.replace(redireccion);
        return;
    }
}


function OnSuccess(response)
{
    
    if ((response.error == null ? "" : response.error) != "")
    {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }

    if (response.error == '')
    {
        tipoAlerta('Se ha enviado un correo para activar el usuario.', 'success', "#boxMessages");
        return;
    }
}

function OnSuccessLogin(response)
{
    
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }

    if (response.error == '')
    {        
        setLocalStorageNavegator("usuarioId", response.id);        
        var redireccion = host + "/Forms/index.aspx";
        window.location.replace(redireccion);
        
        return;
    }
}



function getListaMenuPerfilUsuario() {    
    usuario.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/usuario.aspx/getListaMenuUsuario";
    enviarComoParametros(url, usuario, OnSuccessListUsuario);
}

function OnSuccessListUsuario(response) {

    if ((response.error == null ? "" : response.error) != "")
    {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }

    if (response.error == '') {
        $("#menu").html(response.getCadena);        
        $('#menu').metisMenu();
        return;
    }
}
