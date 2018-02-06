<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmBarrios.ascx.cs" Inherits="ProyectoMolde.Forms.frmBarrios" %>
<div class="row">
    <div class="col-sm-12">
        <div id="PanelIDBarrios" hidden="hidden">
            <label id="lblIdBarrios">Id</label>
            <input id="txtIdBarrios" disabled class="form-control" />
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <label id="lblnombreBarrios">Nombre</label>
        <input id="txtnombreBarrios" class="form-control">
    </div>
</div>
<div class="row">
    <div class="col-sm-6">
        <br />
        <label id="lblmunicipioIdBarrios">Municipio</label>
        <div class="form-group input-group">
            <input id="txtMunicipiosVerBarrios" onblur="leaveHelp('#txtmunicipioIdBarrios','#txtDescripcionMunicipios')" type="text" class="form-control">
            <input id="txtmunicipioIdBarrios" hidden="hidden" type="text" >
            <span class="input-group-btn">
                <a id="btnHelp" onclick="btnOpenHelp('#txtmunicipioIdBarrios','#txtMunicipiosVerBarrios' ,'#txtDescripcionMunicipios')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>

    </div>
    <div class="col-sm-6">
        <br />
        <br />

        <input id="txtDescripcionMunicipios" type="text" disabled class="form-control">
    </div>
</div>

