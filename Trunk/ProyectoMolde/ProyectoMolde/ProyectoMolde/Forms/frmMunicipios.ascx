<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmMunicipios.ascx.cs" Inherits="ProyectoMolde.Forms.frmMunicipios" %>
<div class="row">
    <div class="col-sm-12">
        <div id="PanelIDMunicipios" hidden="hidden">
            <label id="lblIdMunicipios">Id</label>
            <input id="txtIdMunicipios" disabled class="form-control" />
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <label id="lblnombreMunicipios">Nombre</label>
        <input id="txtnombreMunicipios" class="form-control">
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <label id="lblcodigoDaneMunicipios">Código Dane</label>
        <input id="txtcodigoDaneMunicipios" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-6">
        <br />
        <label id="lbldepartamentoIdMunicipios">Departamento</label>
        <div class="form-group input-group ">
            <input id="txtdepartamentosVerMunicipios" onblur="leaveHelp('#txtdepartamentosIdMunicipios','#txtDescripcionDepartamentos')" type="text" class=" form-control">
            <input id="txtdepartamentosIdMunicipios" hidden="hidden" type="text">
            <span class="input-group-btn">
                <a id="btnHelp" onclick="btnOpenHelp('#txtdepartamentosIdMunicipios','#txtdepartamentosVerMunicipios','#txtDescripcionDepartamentos')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>
    </div>
    <div class="col-sm-6">
        <br />
        <br />
        <input id="txtDescripcionDepartamentos" type="text" disabled class="form-control">
    </div>
</div>
