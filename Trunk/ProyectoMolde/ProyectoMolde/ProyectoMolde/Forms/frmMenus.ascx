<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmMenus.ascx.cs" Inherits="ProyectoMolde.Forms.frmMenus" %>
<div class="row">
    <div class="col-sm-12">
        <div id="PanelIDMenus" hidden="hidden">
            <label id="lblIdMenus">Id</label>
            <input id="txtIdMenus" disabled class="form-control" />
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <label id="lblnombreMenuMenus">Nombre Menu</label>
        <input id="txtnombreMenuMenus" class="form-control">
    </div>
</div>
<div class="row">
    <div class="col-sm-6">
        <br />
        <label id="lblaplicacionWebIdMenus">Aplicación Web Asociada</label>
        <div class="form-group input-group">
            <input id="txtaplicacionWebvVerMenus"onblur="leaveHelp('#txtaplicacionWebIdMenus','#txtDescripcionAplicacionWeb')" type="text" class="form-control">
            <input id="txtaplicacionWebIdMenus" hidden="hidden" type="text">
            <span class="input-group-btn">
                <a id="btnHelp" onclick="btnOpenHelp('#txtaplicacionWebIdMenus','#txtaplicacionWebvVerMenus' ,'#txtDescripcionAplicacionWeb')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>            
    </div>
    <div class="col-sm-6">
        <br />
        <br />

        <input id="txtDescripcionAplicacionWeb" type="text" disabled class="form-control">
    </div>

</div>
<div class="row">
    <div class="col-sm-12">
        <label id="lblindexVisibilidadMenus">Index Visibilidad</label>
        <input id="txtindexVisibilidadMenus" type="number" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-12">
        <div id="PanelEstadoMenus" hidden="hidden">
            <label id="lblestadoMenus">Estado</label>
            <input id="txtestadoMenus" disabled class="form-control">
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <label id="lbliconMenus">Iconono</label>
        <input id="txticonMenus" class="form-control">
    </div>
</div>
