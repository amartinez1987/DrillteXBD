<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmPersonas.ascx.cs" Inherits="ProyectoMolde.Forms.frmPersonas" %>

<div class="row">
    <div class="col-sm-12">
        <div id="PanelIDPersonas" hidden="hidden">
            <label id="lblIdPersonas">Id</label>
            <input id="txtIdPersonas" disabled class="form-control" />
        </div>
    </div>
</div>

<div class="row">
    <div class="col-sm-6">
        <br />
        <label id="lbldocumentoIdentidadIdPersonas">Documento identidad</label>
        <div class="form-group input-group">
            <input id="txtdocumentoIdentidadVerPersonas" onblur="leaveHelpDocumentoIdentidad('#txtdocumentoIdentidadIdPersonas','#txtDescripcionDocumentoIdentidad')" type="text" class="form-control">
            <input id="txtdocumentoIdentidadIdPersonas" type="text" hidden="hidden">
            <span class="input-group-btn">
                <a onclick="btnOpenHelpDocumentoIdentidad('#txtdocumentoIdentidadIdPersonas','#txtdocumentoIdentidadVerPersonas' ,'#txtDescripcionDocumentoIdentidad')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>
    </div>
    <div class="col-sm-6">
        <br />
        <br />
        <input id="txtDescripcionDocumentoIdentidad" type="text" disabled class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-12">
        <label id="lblnumeroDocumentoPersonas">Número Documento</label>
        <input id="txtnumeroDocumentoPersonas" class="form-control">
    </div>
</div>


<div class="row">
    <div class="col-sm-6">
        <label id="lblprimerNombrePersonas">Primer Nombre</label>
        <input id="txtprimerNombrePersonas" class="form-control">
    </div>
     <div class="col-sm-6">
        <label id="lblsegundoNombrePersonas">Segundo Nombre</label>
        <input id="txtsegundoNombrePersonas" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-6">
        <label id="lblprimerApellidoPersonas">Primer Apellido</label>
        <input id="txtprimerApellidoPersonas" class="form-control">
    </div>
    <div class="col-sm-6">
        <label id="lblsegundoApellidoPersonas">Segundo Apellido</label>
        <input id="txtsegundoApellidoPersonas" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-12">
        <label id="lblfechaNacimientoPersonas">Fecha Nacimiento</label>
        <input id="txtfechaNacimientoPersonas" type="date" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-6">
        <br />
        <label id="lblmunicipioExpedicionIdPersonas">Municipio Expedicion Cedula</label>
        <div class="form-group input-group">
            <input id="txtmunicipioExpedicionVerPersonas" onblur="leaveHelpMunicipioExpedicion('#txtmunicipioExpedicionIdPersonas','#txtDescripcionMunicipioExpedicion')" type="text" class="form-control">
            <input id="txtmunicipioExpedicionIdPersonas" type="text" hidden="hidden">
            <span class="input-group-btn">
                <a onclick="btnOpenHelpMunicipioExpedicion('#txtmunicipioExpedicionIdPersonas','#txtmunicipioExpedicionVerPersonas' ,'#txtDescripcionMunicipioExpedicion')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>
    </div>
    <div class="col-sm-6">
        <br />
        <br />
        <input id="txtDescripcionMunicipioExpedicion" type="text" disabled class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-12">
        <label id="lblfechaExpedicionCedulaPersonas">Fecha Expedición Cedula</label>
        <input id="txtfechaExpedicionCedulaPersonas" type="date" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-3">
        <br />
        <label id="lblsexoIdPersonas">Sexo</label>
        <div class="form-group input-group">
            <input id="txtSexoVerPersonas" onblur="leaveHelpSexo('#txtsexoIdPersonas','#txtDescripcionSexo')" type="text" class="form-control">
            <input id="txtsexoIdPersonas" type="text" hidden="hidden">
            <span class="input-group-btn">
                <a onclick="btnOpenHelpSexo('#txtsexoIdPersonas','#txtSexoVerPersonas' ,'#txtDescripcionSexo')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>
    </div>
    <div class="col-sm-3">
        <br />
        <br />
        <input id="txtDescripcionSexo" type="text" disabled class="form-control">
    </div>
    <div class="col-sm-3">
        <br />
        <label id="lblgrupoSanguineoIdPersonas">Grupo Sanguineo</label>
        <div class="form-group input-group">
            <input id="txtgrupoSanguineoVerPersonas" onblur="leaveHelpGrupoSanguineo('#txtgrupoSanguineoIdPersonas','#txtDescripcionGrupoSanguineo')" type="text" class="form-control">
            <input id="txtgrupoSanguineoIdPersonas" type="text" hidden="hidden">
            <span class="input-group-btn">
                <a onclick="btnOpenHelpGrupoSanguineo('#txtgrupoSanguineoIdPersonas','#txtgrupoSanguineoVerPersonas' ,'#txtDescripcionGrupoSanguineo')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>
    </div>
    <div class="col-sm-3">
        <br />
        <br />
        <input id="txtDescripcionGrupoSanguineo" type="text" disabled class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-6" >
        <br />
        <label id="lblmunicipioIdPersonas">Municipio Recidencia</label>
        <div id="panelMunicipio" class="form-group input-group">
            <input id="txtmunicipioVerPersona" onblur="leaveHelpMunicipio('#txtmunicipioIdPersonas','#txtDescripcionMunicipio')" type="text" class="form-control">
            <input id="txtmunicipioIdPersonas" type="text" hidden="hidden">
            <span class="input-group-btn">
                <a onclick="btnOpenHelpMunicipio('#txtmunicipioIdPersonas','#txtmunicipioVerPersona' ,'#txtDescripcionMunicipio')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>
    </div>
    <div class="col-sm-6">
        <br />
        <br />
        <input id="txtDescripcionMunicipio" type="text" disabled class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-6">
        <br />
        <label id="lblbarrioIdPersonas">Barrio</label>
        <div class="form-group input-group">
            <input id="txtbarrioVerPersonas" onblur="leaveHelpBarrio('#txtbarrioIdPersonas','#txtDescripcionBarrio')" type="text" class="form-control">
            <input id="txtbarrioIdPersonas" type="text" hidden="hidden">
            <span class="input-group-btn">
                <a onclick="btnOpenHelpBarrio('#txtbarrioIdPersonas','#txtbarrioVerPersonas' ,'#txtDescripcionBarrio')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>
    </div>
    <div class="col-sm-6">
        <br />
        <br />
        <input id="txtDescripcionBarrio" type="text" disabled class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-12">
        <label id="lbldirecccionPersonas">Direccción</label>
        <input id="txtdirecccionPersonas" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-6">
        <label id="lblestaturaPersonas">Estatura</label>
        <input id="txtestaturaPersonas" type="number" class="form-control">
    </div>
    <div class="col-sm-6">
        <label id="lblpesoPersonas">Peso</label>
        <input id="txtpesoPersonas" type="number" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-6">
        <br />
        <label id="lblestadoCivilIdPersonas">Estado Civil</label>
        <div class="form-group input-group">
            <input id="txtestadoCivilVerPersonas" onblur="leaveHelpEstadoCivil('#txtestadoCivilIdPersonas','#txtDescripcioneEstadoCivi')" type="text" class="form-control">
            <input id="txtestadoCivilIdPersonas" type="text" hidden="hidden">
            <span class="input-group-btn">
                <a id="btnHelp" onclick="btnOpenHelpEstadoCivil('#txtestadoCivilIdPersonas','#txtestadoCivilVerPersonas' ,'#txtDescripcioneEstadoCivi')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>
    </div>
    <div class="col-sm-6">
        <br />
        <br />
        <input id="txtDescripcioneEstadoCivi" type="text" disabled class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-12">
        <label id="lbltelefonoFijoPersonas">Telefono Fijo</label>
        <input id="txttelefonoFijoPersonas" type="number" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-12">
        <label id="lbltelefonoCelularPersonas">Telefono Celular</label>
        <input id="txttelefonoCelularPersonas" type="number" class="form-control">
    </div>
</div>


<div class="row">
    <div class="col-sm-12">
        <label id="lblcorreoPersonas">Correo</label>
        <input id="txtcorreoPersonas" class="form-control">
    </div>
</div>
