//atributos del objecto personas
var personas = new Object();
function cargarDatos(personas)
{
    $('#PanelIDPersonas').show();
    $('#txtIdPersonas').val(personas.idPersona);

    $('#txtIdPersona_').val(personas.idPersona);
    

    //datos persona

    $('#txtdocumentoIdentidadIdPersonas').val(personas.documentoIdentidadId);
    $('#txtdocumentoIdentidadVerPersonas').val(personas.siglaDocumentoIdentidad);
    $('#txtDescripcionDocumentoIdentidad').val(personas.descripcionDocumentoIdentidad);

    $('#txtmunicipioIdPersonas').val(personas.municipioId);
    $('#txtmunicipioVerPersona').val(personas.codigoDaneDepartamentoMunicipio);
    $('#txtDescripcionMunicipio').val(personas.nombreDepartamentoMunicipio);

    $('#txtgrupoSanguineoIdPersonas').val(personas.grupoSanguineoId);
    $('#txtgrupoSanguineoVerPersonas').val(personas.siglaGrupoSanguineo);
    $('#txtDescripcionGrupoSanguineo').val(personas.descripcionGrupoSanguineo);

    $('#txtsexoIdPersonas').val(personas.sexoId);
    $('#txtSexoVerPersonas').val(personas.siglaSexo);
    $('#txtDescripcionSexo').val(personas.descripcionSexo);

    $('#txtmunicipioExpedicionIdPersonas').val(personas.municipioExpedicionId);
    $('#txtmunicipioExpedicionVerPersonas').val(personas.codigoDaneDepartamentoExpedicion);
    $('#txtDescripcionMunicipioExpedicion').val(personas.nombreDepartamentoExpedicion);

    $('#txtbarrioIdPersonas').val(personas.barrioId);
    $('#txtbarrioVerPersonas').val(personas.barrioId);
    $('#txtDescripcionBarrio').val(personas.nombreDepartamentoBarrio);

    $('#txtestaturaPersonas').val(personas.estatura);
    $('#txtpesoPersonas').val(personas.peso);

    $('#txtestadoCivilIdPersonas').val(personas.estadoCivilId);
    $('#txtestadoCivilVerPersonas').val(personas.estadoCivilId);
    $('#txtDescripcioneEstadoCivi').val(personas.nombreEstadoCivil);

    $('#txttelefonoFijoPersonas').val(personas.telefonoFijo);
    $('#txttelefonoCelularPersonas').val(personas.telefonoCelular);
    $('#txtnumeroDocumentoPersonas').val(personas.numeroDocumento);
    $('#txtprimerNombrePersonas').val(personas.primerNombre);
    $('#txtsegundoNombrePersonas').val(personas.segundoNombre);
    $('#txtprimerApellidoPersonas').val(personas.primerApellido);
    $('#txtsegundoApellidoPersonas').val(personas.segundoApellido);
    $('#txtdirecccionPersonas').val(personas.direcccion);
    $('#txtcorreoPersonas').val(personas.correo);
    $('#txtfechaNacimientoPersonas').val(getDateString(personas.fechaNacimiento));
    $('#txtfechaExpedicionCedulaPersonas').val(getDateString(personas.fechaExpedicionCedula));

}

function btnPersonas_EditarClick()
{
    
    if (validarCampos())
    {
        personas.persona = new Object();
        personas.persona.id = $('#txtIdPersona_').val();
        personas.persona.usuarioId = getLocalStorageNavegator("usuarioId");
        personas.persona.perfilId = $('#txtperfilIdpersonas').val();
        personas.persona.nombrepersona = $('#txtnombrepersonapersonas').val();
        personas.persona.clave = $('#txtclavepersonas').val();
        personas.persona.estado = $('#txtestadopersonas').val();
        personas.persona.documentoIdentidadId = $('#txtdocumentoIdentidadIdPersonas').val();
        personas.persona.municipioId = $('#txtmunicipioIdPersonas').val();
        personas.persona.grupoSanguineoId = $('#txtgrupoSanguineoIdPersonas').val();
        personas.persona.sexoId = $('#txtsexoIdPersonas').val();
        personas.persona.municipioExpedicionId = $('#txtmunicipioExpedicionIdPersonas').val();
        personas.persona.barrioId = $('#txtbarrioIdPersonas').val();
        personas.persona.estatura = $('#txtestaturaPersonas').val();
        personas.persona.peso = $('#txtpesoPersonas').val();
        personas.persona.estadoCivilId = $('#txtestadoCivilIdPersonas').val();
        personas.persona.telefonoFijo = $('#txttelefonoFijoPersonas').val();
        personas.persona.telefonoCelular = $('#txttelefonoCelularPersonas').val();
        personas.persona.numeroDocumento = $('#txtnumeroDocumentoPersonas').val();
        personas.persona.primerNombre = $('#txtprimerNombrePersonas').val();
        personas.persona.segundoNombre = $('#txtsegundoNombrePersonas').val();
        personas.persona.primerApellido = $('#txtprimerApellidoPersonas').val();
        personas.persona.segundoApellido = $('#txtsegundoApellidoPersonas').val();
        personas.persona.direcccion = $('#txtdirecccionPersonas').val();
        personas.persona.correo = $('#txtcorreoPersonas').val();
        personas.persona.fechaNacimiento = $('#txtfechaNacimientoPersonas').val();
        personas.persona.fechaExpedicionCedula = $('#txtfechaExpedicionCedulaPersonas').val();
        personas.usuarioAsociado = getLocalStorageNavegator("usuarioId");        

        var url = "/WebMethods/personas.aspx/guardar";
        enviarComoParametros(url, personas, OnSuccesSavePersonas);
    }
}

function OnSuccesSavePersonas(response) {
    if ((response.error == null ? "" : response.error) != "")
    {
        tipoAlerta(response.error, response.tipoAlerta, "#panelGuardar");
        return;
    }

    if (response.error == '')
    {
        console.log(response);
        $('#txtIdPersona_').val(response.id);        
        tipoAlerta('Registro Guardado con exito', 'success', "#panelGuardar");
        return;
    }
}

function validarCampos()
{        

    if ($('#txtdocumentoIdentidadIdPersonas').val() == 0)
    {
        tipoAlerta('El campo documentoIdentidadId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtmunicipioIdPersonas').val() == 0)
    {
        tipoAlerta('El campo municipioId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtgrupoSanguineoIdPersonas').val() == 0)
    {
        tipoAlerta('El campo grupoSanguineoId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtsexoIdPersonas').val() == 0)
    {
        tipoAlerta('El campo sexoId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtmunicipioExpedicionIdPersonas').val() == 0)
    {
        tipoAlerta('El campo municipioExpedicionId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtbarrioIdPersonas').val() == 0)
    {
        tipoAlerta('El campo barrioId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtestaturaPersonas').val() == 0)
    {
        tipoAlerta('El campo estatura no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtpesoPersonas').val() == 0)
    {
        tipoAlerta('El campo peso no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtestadoCivilIdPersonas').val() == 0)
    {
        tipoAlerta('El campo estadoCivilId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txttelefonoFijoPersonas').val() == "")
    {
        tipoAlerta('El campo telefonoFijo no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txttelefonoCelularPersonas').val() == "")
    {
        tipoAlerta('El campo telefonoCelular no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtnumeroDocumentoPersonas').val() == "")
    {
        tipoAlerta('El campo numeroDocumento no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtprimerNombrePersonas').val() == "")
    {
        tipoAlerta('El campo primerNombre no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtprimerApellidoPersonas').val() == "")
    {
        tipoAlerta('El campo primerApellido no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtdirecccionPersonas').val() == "")
    {
        tipoAlerta('El campo direcccion no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtcorreoPersonas').val() == "")
    {
        tipoAlerta('El campo correo no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    return true;
}

function btnOpenHelpDocumentoIdentidad(campoIdReturn, campoReturnView, campoDescripReturn)
{
    help.tabla = 'DocumentosIdentidad';
    help.header = 'Listado';
    help.columnas = ['sigla', 'descripcion'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "descripcion";
    help.atributoReturnView = "sigla";
    loadHelp('Help', cargarTabla());
}

function leaveHelpDocumentoIdentidad(campoIdReturn, campoDescripReturn)
{
    help.tabla = 'DocumentosIdentidad';
    help.valorBuscar = $("#txtdocumentoIdentidadVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpDocumentoIdentidad();
}


function getHelpDocumentoIdentidad()
{
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpDocumentoIdentidad);
}

function OnSuccesHelpDocumentoIdentidad(response)
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
            $(help.campoDescripReturn).val(object.descripcion);
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

function btnOpenHelpMunicipioExpedicion(campoIdReturn, campoReturnView, campoDescripReturn)
{
    help.tabla = 'Municipios';
    help.header = 'Listado';
    help.columnas = ['codigoDaneDepartamentoMunicipio', 'nombreDepartamentoMunicipio'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "nombreDepartamentoMunicipio";
    help.atributoReturnView = "codigoDaneDepartamentoMunicipio";
    loadHelp('Help', cargarTabla());
}

function leaveHelpMunicipioExpedicion(campoIdReturn, campoDescripReturn)
{
    help.tabla = 'Municipios';
    help.valorBuscar = $("#txtmunicipioExpedicionVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpMunicipioExpedicion();
}


function getHelpMunicipioExpedicion()
{
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpMunicipioExpedicion);
}

function OnSuccesHelpMunicipioExpedicion(response)
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
            $(help.campoDescripReturn).val(object.nombreDepartamentoMunicipio);
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

function btnOpenHelpSexo(campoIdReturn, campoReturnView, campoDescripReturn)
{
    help.tabla = 'Sexos';
    help.header = 'Listado';
    help.columnas = ['sigla', 'descripcion'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "descripcion";
    help.atributoReturnView = "sigla";
    loadHelp('Help', cargarTabla());
}

function leaveHelpSexo(campoIdReturn, campoDescripReturn)
{
    help.tabla = 'Sexos';
    help.valorBuscar = $("#txtSexoVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpSexo();
}


function getHelpSexo()
{
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpSexo);
}

function OnSuccesHelpSexo(response)
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
            $(help.campoDescripReturn).val(object.descripcion);
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


function btnOpenHelpGrupoSanguineo(campoIdReturn, campoReturnView, campoDescripReturn)
{
    help.tabla = 'GruposSanguineo';
    help.header = 'Listado';
    help.columnas = ['sigla', 'descripcion'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "descripcion";
    help.atributoReturnView = "sigla";
    loadHelp('Help', cargarTabla());
}

function leaveHelpGrupoSanguineo(campoIdReturn, campoDescripReturn)
{
    help.tabla = 'GruposSanguineo';
    help.valorBuscar = $("#txtgrupoSanguineoVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpGrupoSanguineo();
}


function getHelpGrupoSanguineo()
{
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpGrupoSanguineo);
}

function OnSuccesHelpGrupoSanguineo(response)
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
            $(help.campoDescripReturn).val(object.descripcion);
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


function btnOpenHelpMunicipio(campoIdReturn, campoReturnView, campoDescripReturn)
{
    help.tabla = 'Municipios';
    help.header = 'Listado';
    help.columnas = ['codigoDaneDepartamentoMunicipio', 'nombreDepartamentoMunicipio'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "nombreDepartamentoMunicipio";
    help.atributoReturnView = "codigoDaneDepartamentoMunicipio";
    loadHelp('Help', cargarTabla());
}

function leaveHelpMunicipio(campoIdReturn, campoDescripReturn)
{
    help.tabla = 'Municipios';
    help.valorBuscar = $("#txtmunicipioVerPersona").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpMunicipio();
}


function getHelpMunicipio()
{
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpMunicipio);
}

function OnSuccesHelpMunicipio(response)
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
            $(help.campoDescripReturn).val(object.nombreDepartamentoMunicipio);
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

function btnOpenHelpBarrio(campoIdReturn, campoReturnView, campoDescripReturn)
{
    help.tabla = 'Barrios';
    help.header = 'Listado';
    help.columnas = ['id', 'nombre', 'codigoDaneDepartamentoMunicipio', 'nombreDepartamentoMunicipio'];
    if ($('#txtmunicipioIdPersonas').val() == 0)
    {
        tipoAlerta('Seleccione un municipio.', 'danger', "#panelMunicipio");
        return false;
    };
    help.prefiltros = [$("#txtmunicipioIdPersonas").val()];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "nombre";
    help.atributoReturnView = "id";
    loadHelp('Help', cargarTabla());
}

function leaveHelpBarrio(campoIdReturn, campoDescripReturn)
{
    help.tabla = 'Barrios';
    help.valorBuscar = $("#txtbarrioVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;

    if ($('#txtmunicipioIdPersonas').val() == 0)
    {
        tipoAlerta('Seleccione un municipio.', 'warning', "#boxMessagesCrud");
        return false;
    };

    help.prefiltros = [$("#txtmunicipioIdPersonas").val()];

    getHelpBarrio();
}


function getHelpBarrio()
{
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    console.log(help);
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpBarrio);
}

function OnSuccesHelpBarrio(response)
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

function btnOpenHelpEstadoCivil(campoIdReturn, campoReturnView, campoDescripReturn)
{
    help.tabla = 'EstadosCivil';
    help.header = 'Listado';
    help.columnas = ['sigla', 'descripcion'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "descripcion";
    help.atributoReturnView = "sigla";
    loadHelp('Help', cargarTabla());
}

function leaveHelpEstadoCivil(campoIdReturn, campoDescripReturn)
{
    help.tabla = 'EstadosCivil';
    help.valorBuscar = $("#txtestadoCivilVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpEstadoCivil();
}


function getHelpEstadoCivil()
{
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpEstadoCivil);
}

function OnSuccesHelpEstadoCivil(response)
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
            $(help.campoDescripReturn).val(object.descripcion);
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
