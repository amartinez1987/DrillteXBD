<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmFormularios.ascx.cs" Inherits="ProyectoMolde.Forms.frmFormularios" %>

<div class="row">
    <div class="col-sm-12">
        <div id="PanelIDFormularios" hidden="hidden">
            <label id="lblIdFormularios">Id</label>
            <input id="txtIdFormularios" disabled class="form-control" />
        </div>
    </div>
</div>

<div class="row">
    <div class="col-sm-12">
        <label id="lblnombreFormularioFormularios">Nombre Formulario</label>
        <input id="txtnombreFormularioFormularios" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-6">
        <br />
        <label id="lblmenuIdFormularios">Menú</label>
        <div class="form-group input-group">
            <input id="txtmenuVerFormularios" onblur="leaveHelp('#txtmenuIdFormularios','#txtDescripcionMenus')" type="text" class="form-control">
            <input id="txtmenuIdFormularios" hidden="hidden" type="text">
            <span class="input-group-btn">
                <a id="btnHelp" onclick="btnOpenHelp('#txtmenuIdFormularios','#txtmenuVerFormularios' ,'#txtDescripcionMenus')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>
    </div>
    <div class="col-sm-6">
        <br />
        <br />

        <input id="txtDescripcionMenus" type="text" disabled class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-12">
        <label id="lblnombreMostrarFormularios">Nombre Mostrar</label>
        <input id="txtnombreMostrarFormularios" class="form-control">
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <label id="lblurlFormularioFormularios">Url Formulario</label>
        <input id="txturlFormularioFormularios" class="form-control">
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <label id="lblindexVisibilidadFormularios">Index Visibilidad</label>
        <input id="txtindexVisibilidadFormularios" type="number" class="form-control">
    </div>
</div>
<!-- Utilice check o Radio -->
<div class="row">
    <div class="col-sm-12">
        <br />
        <label>
            <input id="chesVisibleFormularios" type="checkbox" value="" />
            ¿Es Visible?
        </label>
    </div>
</div>


<div class="row">
    <div class="col-sm-12">
        <label id="lbliconOpcionFormularios">Icono de Opción</label>
        <input id="txticonOpcionFormularios" class="form-control">
    </div>
</div>
<div class="row">
    <div id="PanelEstadoFormularios" hidden="hidden">
        <div class="col-sm-12">
            <label id="lblestadosFormularios">Estado</label>
            <input id="txtestadosFormularios" disabled class="form-control">
        </div>
    </div>
</div>
