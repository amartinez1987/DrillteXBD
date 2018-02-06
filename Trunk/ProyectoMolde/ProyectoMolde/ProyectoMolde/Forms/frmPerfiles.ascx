<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmPerfiles.ascx.cs" Inherits="ProyectoMolde.Forms.frmPerfiles" %>
<div class="row">
    <div class="col-sm-12">
        <div id="PanelIDPerfiles" hidden="hidden">
            <label id="lblIdPerfiles">Id</label>
            <input id="txtIdPerfiles" disabled class="form-control" />
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <label id="lblnombrePerfilPerfiles">Nombre Perfil</label>
        <input id="txtnombrePerfilPerfiles" class="form-control">
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <label id="lbldescripcionPerfiles">Descripción</label>
        <textarea id="txtdescripcionPerfiles" rows="3" class="form-control"></textarea>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <div id="PanelEstadoPerfiles" hidden="hidden">
            <label id="lblestadoPerfiles">Estado</label>
            <input id="txtestadoPerfiles" disabled class="form-control">
        </div>
    </div>
</div>
