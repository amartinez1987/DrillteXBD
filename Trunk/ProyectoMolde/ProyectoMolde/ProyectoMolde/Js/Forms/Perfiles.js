//atributos del objecto perfiles
var perfiles = new Object();
function cargarDatos(perfiles)
{
    $('#PanelIDPerfiles').show();    
    $('#PanelEstadoPerfiles').show();
    $('#txtIdPerfiles').val(perfiles.id);   
    $('#txtnombrePerfilPerfiles').val(perfiles.nombrePerfil);
    $('#txtdescripcionPerfiles').val(perfiles.descripcion);
    $('#txtestadoPerfiles').val(perfiles.estado);
}

function croosModalClick()
{
    cargarListaPerfiles();
}

function btnPerfiles_NuevoClick()
{
    loadUrlModal('Nueva Perfiles', 'frmPerfiles_Nuevo.aspx', croosModalClick);
}

function btnPerfiles_GuardarClick()
{
    if (validarCampos())
    {
        perfiles.id = 0;
        perfiles.usuarioId = getLocalStorageNavegator("usuarioId");
        perfiles.nombrePerfil = $('#txtnombrePerfilPerfiles').val();
        perfiles.descripcion = $('#txtdescripcionPerfiles').val();
        perfiles.estado = $('#txtestadoPerfiles').val();
        var url = "/WebMethods/perfiles.aspx/guardar";
        enviarComoParametros(url, perfiles, OnSuccesSavePerfiles);
    }
}

function btnPerfiles_EditarClick()
{
    if (validarCampos())
    {
        perfiles.id = $('#txtIdPerfiles').val();
        perfiles.usuarioId = getLocalStorageNavegator("usuarioId");
        perfiles.nombrePerfil = $('#txtnombrePerfilPerfiles').val();
        perfiles.descripcion = $('#txtdescripcionPerfiles').val();
        perfiles.estado = $('#txtestadoPerfiles').val();
        var url = "/WebMethods/perfiles.aspx/guardar";
        enviarComoParametros(url, perfiles, OnSuccesSavePerfiles);
    }
}

function OnSuccesSavePerfiles(response)
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

function btnPerfiles_Editar(id)
{
    loadUrlModal('Editar Perfiles', ('frmPerfiles_Editar.aspx?id=' + id), croosModalClick);
}

function btnPerfiles_Inactivar(id) {
    // get txn id from current table row
    var heading = 'Inactivar Registro';
    var question = '¿Desea inactivar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        perfiles.id = id;
        perfiles.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/perfiles.aspx/inactivar";
        enviarComoParametros(url, perfiles, OnSuccesInactivarPerfiles);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesInactivarPerfiles(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro inactivado con Exito.', 'success', "#boxMessages");
        cargarListaPerfiles();
        return;
    }
}

function btnPerfiles_Activar(id)
{
    // get txn id from current table row
    var heading = 'Activar Registro';
    var question = '¿Desea activar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function ()
    {
        perfiles.id = id;
        perfiles.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/perfiles.aspx/activar";
        enviarComoParametros(url, perfiles, OnSuccesActivarPerfiles);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesActivarPerfiles(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro activado con Exito.', 'success', "#boxMessages");
        cargarListaPerfiles();
        return;
    }
}

function getListaPerfiles(registroPartida, totalAExtraer, callbackFucntion) {
    perfiles.registroPartida = registroPartida;
    perfiles.totalAExtraer = totalAExtraer;
    perfiles.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/perfiles.aspx/getListaPerfiles";
    enviarComoParametros(url, perfiles, callbackFucntion);
}
function validarCampos() {

    if ($('#txtIdperfiles').val() == 0) {
        tipoAlerta('El campo id no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtnombrePerfilPerfiles').val() == 0) {
        tipoAlerta('El campo nombrePerfil no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtdescripcionPerfiles').val() == 0) {
        tipoAlerta('El campo descripcion no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    return true;
}

function cargarListaPerfiles() {
    table = $('#gridListaPerfiles');

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
            var lstPerfiles;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaPerfiles(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstPerfiles = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstPerfiles.length; i++) {
                        var etiquetaEditar = "<a onclick='btnPerfiles_Editar(" + lstPerfiles[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaInactivar = " <a class='fa fa-minus' onclick='btnPerfiles_Inactivar(" + lstPerfiles[i].id + ")'><a>";
                        var etiquetaActivar = " <a class='fa fa-check' onclick='btnPerfiles_Activar(" + lstPerfiles[i].id + ")'><a>";
                        var etiquetaOperacionPerfiles = " <a class='fa fa-gears' onclick='btnPerfiles_Operaciones(" + lstPerfiles[i].id +",\""+ lstPerfiles[i].nombrePerfil + "\")'><a>";
                        out.push(["", etiquetaEditar + etiquetaInactivar + etiquetaActivar + etiquetaOperacionPerfiles, lstPerfiles[i].nombrePerfil, lstPerfiles[i].descripcion, lstPerfiles[i].estado]);
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



function btnPerfiles_Operaciones(id,nombrePerfil) {
    loadUrlModal('Operaciones Perfil ' + nombrePerfil, ('frmPerfilesOperacionesFormulario.aspx?id=' + id), croosModalClick, ' style="height: 500px; overflow-y: scroll;" ');
}