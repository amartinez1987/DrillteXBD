<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmOperaciones.ascx.cs" Inherits="ProyectoMolde.Forms.frmOperaciones" %>
<div class="row">
    <div class="col-sm-6">
        <div id="PanelIDOperaciones" hidden="hidden">
            <label id="lblIdOperaciones">Id</label>
            <input id="txtIdOperaciones" disabled class="form-control" />
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-6">
        <label id="lblnombreOperacionOperaciones">Nombre Operación</label>
        <input id="txtnombreOperacionOperaciones" class="form-control">
    </div>
</div>
<div class="row">
    <div class="col-sm-6">
        <label id="lblvisualizaFormularioMenuOperaciones">
            <input id="chvisualizaFormularioMenuOperaciones" type="checkbox" >¿Visualiza Formulario?
        </label>
    </div>
</div>
