<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmUsuarios.ascx.cs" Inherits="ProyectoMolde.Forms.frmUsuarios" %>
<%@ Register Src="~/Forms/frmPersonas.ascx" TagPrefix="uc1" TagName="frmPersonas" %>


<div class="row">
    <div class="col-sm-12">
        <div id="PanelIDUsuarios" hidden="hidden">
            <label id="lblIdUsuarios">Id</label>
            <input id="txtIdUsuarios" disabled class="form-control" />
        </div>
    </div>
</div>

<div class="row">
    <div class="col-sm-12">
        <label id="lblnombreUsuarioUsuarios">Nombre Usuario</label>
        <input id="txtnombreUsuarioUsuarios" class="form-control">
    </div>
</div>

<div class="row">
    <div class="col-sm-6">
        <br />
        <label id="lblperfilIdUsuarios">Perfil</label>
        <div class="form-group input-group">
            <input id="txtPerfilVerUsuarios" onblur="leaveHelpPerfiles('#txtperfilIdUsuarios','#txtDescripcionPerfil')" type="text" class="form-control">
            <input id="txtperfilIdUsuarios" hidden="hidden" type="text">
            <span class="input-group-btn">
                <a onclick="btnOpenHelpPerfiles('#txtperfilIdUsuarios','#txtPerfilVerUsuarios' ,'#txtDescripcionPerfil')" class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </a>
            </span>
        </div>
    </div>
    <div class="col-sm-6">
        <br />
        <br />
        <input id="txtDescripcionPerfil" type="text" disabled class="form-control">
    </div>
</div>

<div class="row">
    <div id="PanelClaveUsuarios">
        <div class="col-sm-6">
            <label id="lblclaveUsuarios">Contraseña</label>
            <input id="txtclaveUsuarios" type="password" class="form-control">
        </div>
        <div class="col-sm-6">
            <label id="lblConfirmarclaveUsuarios">Confirmar Contraseña</label>
            <input id="txtConfirmarclaveUsuarios" type="password" class="form-control">
        </div>
    </div>
</div>

<div class="row">
    <div id="PanelEstadousUsuarios" hidden="hidden">
        <div class="col-sm-12">
            <label id="lblestadoUsuarios">Estado</label>
            <input id="txtestadoUsuarios" class="form-control">
        </div>
    </div>
</div>

<uc1:frmPersonas runat="server" ID="frmPersonas" />
