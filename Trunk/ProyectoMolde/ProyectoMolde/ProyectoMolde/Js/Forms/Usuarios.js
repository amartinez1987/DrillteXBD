//atributos del objecto usuarios
var usuarios = new Object();
function cargarDatos(usuarios) {
    $('#PanelIDUsuarios').show();
    $('#PanelEstadousUsuarios').show();
    $('#PanelIDPersonas').show();
    $('#PanelClaveUsuarios').hide();
    $('#txtIdUsuarios').val(usuarios.id);
    $('#txtperfilIdUsuarios').val(usuarios.perfilId);
    $('#txtPerfilVerUsuarios').val(usuarios.perfilId);
    $('#txtDescripcionPerfil').val(usuarios.nombrePerfil);
    $('#txtnombreUsuarioUsuarios').val(usuarios.nombreUsuario);
    $('#txtclaveUsuarios').val(usuarios.clave);
    $('#txtestadoUsuarios').val(usuarios.estado);
    $('#txtIdPersonas').val(usuarios.idPersona);

    //datos persona

    $('#txtdocumentoIdentidadIdPersonas').val(usuarios.documentoIdentidadId);
    $('#txtdocumentoIdentidadVerPersonas').val(usuarios.siglaDocumentoIdentidad);
    $('#txtDescripcionDocumentoIdentidad').val(usuarios.descripcionDocumentoIdentidad);

    $('#txtmunicipioIdPersonas').val(usuarios.municipioId);
    $('#txtmunicipioVerPersona').val(usuarios.codigoDaneDepartamentoMunicipio);
    $('#txtDescripcionMunicipio').val(usuarios.nombreDepartamentoMunicipio);

    $('#txtgrupoSanguineoIdPersonas').val(usuarios.grupoSanguineoId);
    $('#txtgrupoSanguineoVerPersonas').val(usuarios.siglaGrupoSanguineo);
    $('#txtDescripcionGrupoSanguineo').val(usuarios.descripcionGrupoSanguineo);

    $('#txtsexoIdPersonas').val(usuarios.sexoId);
    $('#txtSexoVerPersonas').val(usuarios.siglaSexo);
    $('#txtDescripcionSexo').val(usuarios.descripcionSexo);

    $('#txtmunicipioExpedicionIdPersonas').val(usuarios.municipioExpedicionId);
    $('#txtmunicipioExpedicionVerPersonas').val(usuarios.codigoDaneDepartamentoExpedicion);
    $('#txtDescripcionMunicipioExpedicion').val(usuarios.nombreDepartamentoExpedicion);

    $('#txtbarrioIdPersonas').val(usuarios.barrioId);
    $('#txtbarrioVerPersonas').val(usuarios.barrioId);
    $('#txtDescripcionBarrio').val(usuarios.nombreDepartamentoBarrio);

    $('#txtestaturaPersonas').val(usuarios.estatura);
    $('#txtpesoPersonas').val(usuarios.peso);

    $('#txtestadoCivilIdPersonas').val(usuarios.estadoCivilId);
    $('#txtestadoCivilVerPersonas').val(usuarios.estadoCivilId);
    $('#txtDescripcioneEstadoCivi').val(usuarios.nombreEstadoCivil);

    $('#txttelefonoFijoPersonas').val(usuarios.telefonoFijo);
    $('#txttelefonoCelularPersonas').val(usuarios.telefonoCelular);
    $('#txtnumeroDocumentoPersonas').val(usuarios.numeroDocumento);
    $('#txtprimerNombrePersonas').val(usuarios.primerNombre);
    $('#txtsegundoNombrePersonas').val(usuarios.segundoNombre);
    $('#txtprimerApellidoPersonas').val(usuarios.primerApellido);
    $('#txtsegundoApellidoPersonas').val(usuarios.segundoApellido);
    $('#txtdirecccionPersonas').val(usuarios.direcccion);
    $('#txtcorreoPersonas').val(usuarios.correo);   
    $('#txtfechaNacimientoPersonas').val(getDateString(usuarios.fechaNacimiento));
    $('#txtfechaExpedicionCedulaPersonas').val(getDateString(usuarios.fechaExpedicionCedula));


}

function croosModalClick() {
    cargarListaUsuarios();
}

function btnUsuarios_NuevoClick() {
    loadUrlModal('Nueva Usuarios', 'frmUsuarios_Nuevo.aspx', croosModalClick, ' style="height: 400px; overflow-y: scroll;" ');
}

function btnUsuarios_GuardarClick() {
    if (validarCampos()) {
        if ($('#txtclaveUsuarios').val() != $('#txtConfirmarclaveUsuarios').val()) {
            tipoAlerta("La Constraseñas no coinciden", "warning", "#panelGuardar");
            return;
        }
        usuarios.usuario = new Object();
        usuarios.usuario.id = 0;
        usuarios.usuario.idPersona = $('#txtIdPersonas').val();
        usuarios.usuario.usuarioId = getLocalStorageNavegator("usuarioId");
        usuarios.usuario.perfilId = $('#txtperfilIdUsuarios').val();
        usuarios.usuario.nombreUsuario = $('#txtnombreUsuarioUsuarios').val();
        usuarios.usuario.clave = $('#txtclaveUsuarios').val();
        usuarios.usuario.confirmarClave = $('#txtConfirmarclaveUsuarios').val();
        usuarios.usuario.estado = $('#txtestadoUsuarios').val();
        usuarios.usuario.documentoIdentidadId = $('#txtdocumentoIdentidadIdPersonas').val();
        usuarios.usuario.municipioId = $('#txtmunicipioIdPersonas').val();
        usuarios.usuario.grupoSanguineoId = $('#txtgrupoSanguineoIdPersonas').val();
        usuarios.usuario.sexoId = $('#txtsexoIdPersonas').val();
        usuarios.usuario.municipioExpedicionId = $('#txtmunicipioExpedicionIdPersonas').val();
        usuarios.usuario.barrioId = $('#txtbarrioIdPersonas').val();
        usuarios.usuario.estatura = $('#txtestaturaPersonas').val();
        usuarios.usuario.peso = $('#txtpesoPersonas').val();
        usuarios.usuario.estadoCivilId = $('#txtestadoCivilIdPersonas').val();
        usuarios.usuario.telefonoFijo = $('#txttelefonoFijoPersonas').val();
        usuarios.usuario.telefonoCelular = $('#txttelefonoCelularPersonas').val();
        usuarios.usuario.numeroDocumento = $('#txtnumeroDocumentoPersonas').val();
        usuarios.usuario.primerNombre = $('#txtprimerNombrePersonas').val();
        usuarios.usuario.segundoNombre = $('#txtsegundoNombrePersonas').val();
        usuarios.usuario.primerApellido = $('#txtprimerApellidoPersonas').val();
        usuarios.usuario.segundoApellido = $('#txtsegundoApellidoPersonas').val();
        usuarios.usuario.direcccion = $('#txtdirecccionPersonas').val();
        usuarios.usuario.correo = $('#txtcorreoPersonas').val();
        usuarios.usuario.fechaNacimiento = $('#txtfechaNacimientoPersonas').val();
        usuarios.usuario.fechaExpedicionCedula = $('#txtfechaExpedicionCedulaPersonas').val();

        var url = "/WebMethods/usuario.aspx/nuevo";
        enviarComoParametros(url, usuarios, OnSuccesSaveUsuarios);
    }
}

function btnUsuarios_EditarClick()
{
    if (validarCampos())
    {

        var heading = 'Editar Registro';
        var question = '¿Como desea guardar el registro?.';
        var cancelButtonTxt = 'Cancelar';
        var okButtonSinPerfilTxt = 'Guardar sin Cambiar Perfil';
        var okButtonAddPerfilTxt = 'Guardar y agregar opciones del perfil';
        var okButtonReplacePerfilTxt = 'Remplazar perfil';

        var callback = function (tipoModificacionPerfil)
        {           
            usuarios.usuario = new Object();
            usuarios.usuario.id = $('#txtIdUsuarios').val();
            usuarios.usuario.idPersona = $('#txtIdPersonas').val();
            usuarios.usuario.usuarioId = getLocalStorageNavegator("usuarioId");
            usuarios.usuario.perfilId = $('#txtperfilIdUsuarios').val();
            usuarios.usuario.nombreUsuario = $('#txtnombreUsuarioUsuarios').val();
            usuarios.usuario.clave = $('#txtclaveUsuarios').val();
            usuarios.usuario.estado = $('#txtestadoUsuarios').val();
            usuarios.usuario.documentoIdentidadId = $('#txtdocumentoIdentidadIdPersonas').val();
            usuarios.usuario.municipioId = $('#txtmunicipioIdPersonas').val();
            usuarios.usuario.grupoSanguineoId = $('#txtgrupoSanguineoIdPersonas').val();
            usuarios.usuario.sexoId = $('#txtsexoIdPersonas').val();
            usuarios.usuario.municipioExpedicionId = $('#txtmunicipioExpedicionIdPersonas').val();
            usuarios.usuario.barrioId = $('#txtbarrioIdPersonas').val();
            usuarios.usuario.estatura = $('#txtestaturaPersonas').val();
            usuarios.usuario.peso = $('#txtpesoPersonas').val();
            usuarios.usuario.estadoCivilId = $('#txtestadoCivilIdPersonas').val();
            usuarios.usuario.telefonoFijo = $('#txttelefonoFijoPersonas').val();
            usuarios.usuario.telefonoCelular = $('#txttelefonoCelularPersonas').val();
            usuarios.usuario.numeroDocumento = $('#txtnumeroDocumentoPersonas').val();
            usuarios.usuario.primerNombre = $('#txtprimerNombrePersonas').val();
            usuarios.usuario.segundoNombre = $('#txtsegundoNombrePersonas').val();
            usuarios.usuario.primerApellido = $('#txtprimerApellidoPersonas').val();
            usuarios.usuario.segundoApellido = $('#txtsegundoApellidoPersonas').val();
            usuarios.usuario.direcccion = $('#txtdirecccionPersonas').val();
            usuarios.usuario.correo = $('#txtcorreoPersonas').val();
            usuarios.usuario.fechaNacimiento = $('#txtfechaNacimientoPersonas').val();
            usuarios.usuario.fechaExpedicionCedula = $('#txtfechaExpedicionCedulaPersonas').val();
            usuarios.modificaPerfil = tipoModificacionPerfil;

            var url = "/WebMethods/usuario.aspx/editar";
            enviarComoParametros(url, usuarios, OnSuccesSaveUsuarios);

        }

        confirmPerfil(heading, question, okButtonSinPerfilTxt ,okButtonAddPerfilTxt, okButtonReplacePerfilTxt, cancelButtonTxt , callback);

        
    }
}

function OnSuccesSaveUsuarios(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#panelGuardar");
        return;
    }

    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#panelGuardar");
        return;
    }
}

function btnUsuarios_Editar(id) {
    loadUrlModal('Editar Usuarios', ('frmUsuarios_Editar.aspx?id=' + id), croosModalClick, ' style="height: 400px; overflow-y: scroll;" ');
}

function btnUsuarios_Inactivar(id) {
    // get txn id from current table row
    var heading = 'Inactivar Registro';
    var question = '¿Desea inactivar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        usuarios.id = id;
        usuarios.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/usuario.aspx/inactivar";
        enviarComoParametros(url, usuarios, OnSuccesInactivarUsuarios);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesInactivarUsuarios(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }

    if (response.error == '') {
        tipoAlerta('Registro inactivado con Exito.', 'success', "#boxMessages");
        cargarListaUsuarios();
        return;
    }
}

function btnUsuarios_Activar(id) {
    // get txn id from current table row
    var heading = 'Activar Registro';
    var question = '¿Desea activar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        usuarios.id = id;
        usuarios.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/usuario.aspx/activar";
        enviarComoParametros(url, usuarios, OnSuccesActivarUsuarios);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesActivarUsuarios(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }

    if (response.error == '') {
        tipoAlerta('Registro activado con Exito.', 'success', "#boxMessages");
        cargarListaUsuarios();
        return;
    }
}


function btnUsuarios_Operaciones(id, nombreUsuario) {
    loadUrlModal('Operaciones Usuario ' + nombreUsuario, ('frmUsuariosOperacionesFormulario.aspx?id=' + id), croosModalClick, ' style="height: 500px; overflow-y: scroll;" ');
}

function btnUsuarios_CambiarClave(id, nombreUsuario) {
    loadUrlModal('Cambiar Clave Usuario ' + nombreUsuario, ('frmUsuariosCambioClave.aspx?id=' + id), croosModalClick, ' style="height: 500px; overflow-y: scroll;" ');
}
var pMsg = "";
function btnUsuariosActualizarClave_Click(panelMensaje) {
    pMsg = panelMensaje;
    var heading = 'Cambiar Clave';
    var question = '¿Esta seguro de cambiar su clave?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';

    var callback = function () {
        usuario = new Object();
        usuario.id = usuarios.id;
        usuario.clave = $('#txtclaveUsuarios').val();
        usuario.confirmarClave = $('#txtConfirmarclaveUsuarios').val();
        usuario.usuarioId = getLocalStorageNavegator("usuarioId");

        var url = "/WebMethods/usuario.aspx/actualizarClave";
        enviarComoParametros(url, usuario, OnSuccesCambioClaveUsuarios);
    }

    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesCambioClaveUsuarios(response) {
    console.log(pMsg);
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, pMsg);
        return;
    }

    if (response.error == '') {
        tipoAlerta('Contraseña actualizada.', 'success', pMsg);
        return;
    }
}

function getListaUsuarios(valorBuscado, registroPartida, totalAExtraer, callbackFucntion) {
    usuarios.valorBuscado = valorBuscado;
    usuarios.registroPartida = registroPartida;
    usuarios.totalAExtraer = totalAExtraer;
    usuarios.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/usuario.aspx/getListaUsuarios";
    enviarComoParametros(url, usuarios, callbackFucntion);
}

function validarCampos() {

    if ($('#txtperfilIdUsuarios').val() == 0) {        
        tipoAlerta('El campo perfilId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtnombreUsuarioUsuarios').val() == "") {
        tipoAlerta('El campo nombreUsuario no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtclaveUsuarios').val() == "") {
        tipoAlerta('El campo clave no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtdocumentoIdentidadIdPersonas').val() == 0) {
        tipoAlerta('El campo documentoIdentidadId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtmunicipioIdPersonas').val() == 0) {
        tipoAlerta('El campo municipioId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtgrupoSanguineoIdPersonas').val() == 0) {
        tipoAlerta('El campo grupoSanguineoId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtsexoIdPersonas').val() == 0) {
        tipoAlerta('El campo sexoId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtmunicipioExpedicionIdPersonas').val() == 0) {
        tipoAlerta('El campo municipioExpedicionId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtbarrioIdPersonas').val() == 0) {
        tipoAlerta('El campo barrioId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtestaturaPersonas').val() == 0) {
        tipoAlerta('El campo estatura no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtpesoPersonas').val() == 0) {
        tipoAlerta('El campo peso no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtestadoCivilIdPersonas').val() == 0) {
        tipoAlerta('El campo estadoCivilId no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txttelefonoFijoPersonas').val() == "") {
        tipoAlerta('El campo telefonoFijo no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txttelefonoCelularPersonas').val() == "") {
        tipoAlerta('El campo telefonoCelular no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtnumeroDocumentoPersonas').val() == "") {
        tipoAlerta('El campo numeroDocumento no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtprimerNombrePersonas').val() == "") {
        tipoAlerta('El campo primerNombre no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtprimerApellidoPersonas').val() == "") {
        tipoAlerta('El campo primerApellido no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };
 
    if ($('#txtdirecccionPersonas').val() == "") {
        tipoAlerta('El campo direcccion no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    if ($('#txtcorreoPersonas').val() == "") {
        tipoAlerta('El campo correo no puede ir vacío.', 'warning', "#panelGuardar");
        return false;
    };

    return true;
}

function cargarListaUsuarios() {
    table = $('#gridListaUsuarios');

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
            var lstUsuarios;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaUsuarios($("#txtSearch").val(), data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstUsuarios = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstUsuarios.length; i++) {
                        var etiquetaEditar = "<a onclick='btnUsuarios_Editar(" + lstUsuarios[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaInactivar = " <a class='fa fa-minus' onclick='btnUsuarios_Inactivar(" + lstUsuarios[i].id + ")'><a>";
                        var etiquetaActivar = " <a class='fa fa-check' onclick='btnUsuarios_Activar(" + lstUsuarios[i].id + ")'><a>";
                        var etiquetaOperacionUsuarios = " <a class='fa fa-gears' onclick='btnUsuarios_Operaciones(" + lstUsuarios[i].id + ",\"" + lstUsuarios[i].nombreUsuario + "\")'><a>";
                        var etiquetaCambiarClaveUsuarios = " <a class='fa fa-key' onclick='btnUsuarios_CambiarClave(" + lstUsuarios[i].id + ",\"" + lstUsuarios[i].nombreUsuario + "\")'><a>";
                        out.push(["", etiquetaEditar + etiquetaInactivar + etiquetaActivar + etiquetaOperacionUsuarios + etiquetaCambiarClaveUsuarios, lstUsuarios[i].nombreUsuario, lstUsuarios[i].siglaDocumentoIdentidad, lstUsuarios[i].nombreCompletoPersona, lstUsuarios[i].nombrePerfil, lstUsuarios[i].estado]);
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

function btnOnSearch() {
    cargarListaUsuarios();
}

function btnOpenHelpPerfiles(campoIdReturn, campoReturnView, campoDescripReturn) {
    help.tabla = 'Perfiles';
    help.header = 'Listado';
    help.columnas = ['id', 'nombrePerfil'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "nombrePerfil";
    help.atributoReturnView = "id";
    loadHelp('Help', cargarTabla());
}

function leaveHelpPerfiles(campoIdReturn, campoDescripReturn) {
    help.tabla = 'Perfiles';
    help.valorBuscar = $("#txtPerfilVerUsuarios").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpPerfiles();
}


function getHelpPerfiles() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpPerfiles);
}

function OnSuccesHelpPerfiles(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        try {
            var object = eval("(" + response.getCadena + ")");
            $(help.campoDescripReturn).val(object.nombrePerfil);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e) {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }

        return;
    }
}


function btnOpenHelpDocumentoIdentidad(campoIdReturn, campoReturnView, campoDescripReturn) {
    help.tabla = 'DocumentosIdentidad';
    help.header = 'Listado';
    help.columnas = [ 'sigla', 'descripcion'];
    help.prefiltros = [];
    help.campoIdReturn = campoIdReturn;
    help.campoReturnView = campoReturnView;
    help.campoDescripReturn = campoDescripReturn;
    help.atributoReturnDescripcion = "descripcion";
    help.atributoReturnView = "sigla";
    loadHelp('Help', cargarTabla());
}

function leaveHelpDocumentoIdentidad(campoIdReturn, campoDescripReturn) {
    help.tabla = 'DocumentosIdentidad';
    help.valorBuscar = $("#txtdocumentoIdentidadVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpDocumentoIdentidad();
}


function getHelpDocumentoIdentidad() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpDocumentoIdentidad);
}

function OnSuccesHelpDocumentoIdentidad(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        try {
            var object = eval("(" + response.getCadena + ")");
            $(help.campoDescripReturn).val(object.descripcion);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e) {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }

        return;
    }
}


function btnOpenHelpMunicipioExpedicion(campoIdReturn, campoReturnView, campoDescripReturn) {
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

function leaveHelpMunicipioExpedicion(campoIdReturn, campoDescripReturn) {
    help.tabla = 'Municipios';
    help.valorBuscar = $("#txtmunicipioExpedicionVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpMunicipioExpedicion();
}


function getHelpMunicipioExpedicion() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpMunicipioExpedicion);
}

function OnSuccesHelpMunicipioExpedicion(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        try {
            var object = eval("(" + response.getCadena + ")");
            $(help.campoDescripReturn).val(object.nombreDepartamentoMunicipio);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e) {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }

        return;
    }
}

function btnOpenHelpSexo(campoIdReturn, campoReturnView, campoDescripReturn) {
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

function leaveHelpSexo(campoIdReturn, campoDescripReturn) {
    help.tabla = 'Sexos';
    help.valorBuscar = $("#txtSexoVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpSexo();
}


function getHelpSexo() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpSexo);
}

function OnSuccesHelpSexo(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        try {
            var object = eval("(" + response.getCadena + ")");
            $(help.campoDescripReturn).val(object.descripcion);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e) {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }

        return;
    }
}


function btnOpenHelpGrupoSanguineo(campoIdReturn, campoReturnView, campoDescripReturn) {
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

function leaveHelpGrupoSanguineo(campoIdReturn, campoDescripReturn) {
    help.tabla = 'GruposSanguineo';
    help.valorBuscar = $("#txtgrupoSanguineoVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpGrupoSanguineo();
}


function getHelpGrupoSanguineo() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpGrupoSanguineo);
}

function OnSuccesHelpGrupoSanguineo(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        try {
            var object = eval("(" + response.getCadena + ")");
            $(help.campoDescripReturn).val(object.descripcion);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e) {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }

        return;
    }
}


function btnOpenHelpMunicipio(campoIdReturn, campoReturnView, campoDescripReturn) {
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

function leaveHelpMunicipio(campoIdReturn, campoDescripReturn) {
    help.tabla = 'Municipios';
    help.valorBuscar = $("#txtmunicipioVerPersona").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpMunicipio();
}


function getHelpMunicipio() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpMunicipio);
}

function OnSuccesHelpMunicipio(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        try {
            var object = eval("(" + response.getCadena + ")");
            $(help.campoDescripReturn).val(object.nombreDepartamentoMunicipio);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e) {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }

        return;
    }
}


function btnOpenHelpBarrio(campoIdReturn, campoReturnView, campoDescripReturn) {
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

function leaveHelpBarrio(campoIdReturn, campoDescripReturn) {
    help.tabla = 'Barrios';
    help.valorBuscar = $("#txtbarrioVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;

    if ($('#txtmunicipioIdPersonas').val() == 0) {
        tipoAlerta('Seleccione un municipio.', 'warning', "#boxMessagesCrud");
        return false;
    };

    help.prefiltros = [$("#txtmunicipioIdPersonas").val()];
    
    getHelpBarrio();
}


function getHelpBarrio() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    console.log(help);
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpBarrio);
}

function OnSuccesHelpBarrio(response) {
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


function btnOpenHelpEstadoCivil(campoIdReturn, campoReturnView, campoDescripReturn) {
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

function leaveHelpEstadoCivil(campoIdReturn, campoDescripReturn) {
    help.tabla = 'EstadosCivil';
    help.valorBuscar = $("#txtestadoCivilVerPersonas").val();
    help.campoIdReturn = campoIdReturn;
    help.campoDescripReturn = campoDescripReturn;
    help.prefiltros = [];

    getHelpEstadoCivil();
}


function getHelpEstadoCivil() {
    help.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesHelpEstadoCivil);
}

function OnSuccesHelpEstadoCivil(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        try {
            var object = eval("(" + response.getCadena + ")");
            $(help.campoDescripReturn).val(object.descripcion);
            $(help.campoIdReturn).val(object.id);
        }
        catch (e) {
            $(help.campoDescripReturn).val('');
            $(help.campoIdReturn).val('');
        }

        return;
    }
}

