var help = new Object();
function cargarTabla() {

    var coloumnas = getColumnasEtiqueta(help.columnas);
    var tableHelp = $(
        '<div id="popHelp" >' +
            '<div class="row">' +
                '<div class="col-sm-12">' +
                    '<label id="lbltextBusqueda">Registro Busqueda</label>' +
                    '<input id="txttextBusqueda" class="form-control">' +
                    '<button id="btnbuscarHelp" onclick="btnbuscarHelpClick()" type="button" class="btn btn-default">Buscar</button>' +
                '</div>' +
            '</div>' +
            '<br />' +
            '<div class="row">' +
                '<div class="col-sm-12">' +
                    '<table id="gridHelp" class="display" cellspacing="0" width="100%">' +
                        '<thead>' +
                            //headers
                                '<tr>' +
                                    coloumnas +
                                '</tr>' +
                            //endheader
                        '</thead>' +
                    '</table>' +
                '</div>' +
            '</div>'
        );
    return tableHelp;
}

function loadHelp(heading, tableHelp) {
    $('#modalHelp').remove();
    var modalUrl =
      $('<div id ="modalHelp" class="modal fade">' +
          '<div class="modal-dialog">' +
             '<div class="modal-content">' +
                '<div class="modal-header alert-info">' +
                    '<a id="croosModal" type="button" class="close" >X</a>' +
                    '<h4  class="modal-title">' + heading + '</h4>' +
                '</div>' +
                '<div class="modal-body">' +
                    '<p>Loading...</p>' +
                '</div>' +
                '<div class="modal-footer">' +
                    'Molde' +
                '</div>' +
            '</div>' +
          '</div>' +
        '</div>');

    modalUrl.find('#croosModal').click(function (event) {
        modalUrl.modal('hide');
    });

    modalUrl.on('hidden.bs.modal', function () {
        // do something…

    });

    modalUrl.on('shown.bs.modal', function () {
        cargarListaHelp();        
    });

    modalUrl.find('.modal-body').html(tableHelp);
    modalUrl.modal('show');
};


function getListaHelp(registroPartida, totalAExtraer, callbackFucntion) {
    help.registroPartida = registroPartida;
    help.totalAExtraer = totalAExtraer;
    help.usuarioId = getLocalStorageNavegator("usuarioId");    
    var url = "/WebMethods/help.aspx/getListaHelp";
    enviarComoParametros(url, help, callbackFucntion);
}

function cargarListaHelp() {
    help.textoBusqueda = $("#txttextBusqueda").val() == undefined ? "" : $("#txttextBusqueda").val();
    table = $('#gridHelp');
   
    if ($.fn.dataTable.isDataTable(table)) {
        table.DataTable();
    } else
    {
        table.on('dblclick', 'tr', function ()
        {
            console.log(help);
            
            getObjectHelp($(this).find('td')[0].innerText);


           
            $('#modalHelp').modal('toggle');
        });
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
            var lstHelp;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaHelp(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    return;
                }

                if (response.error == '') {
                    lstHelp = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;

                    for (var i = 0; i < lstHelp.length; i++)
                    {
                        var registro = new Array();
                        for (var x in help.columnas)
                        {
                            
                            registro.push(lstHelp[i][help.columnas[x]]);
                            
                        }                        
                        out.push(registro);
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


function btnbuscarHelpClick() {    
    cargarListaHelp();
}

function getColumnasEtiqueta(columns) {
    var columnaEtiqueta = '';
    for (var x = 0; x < columns.length; x++) {
        columnaEtiqueta += '<th>' + columns[x] + '</th>'
    }
    return columnaEtiqueta;
}

function getObjectHelp(id)
{    
    help.valorBuscar = id;    
    var url = "/WebMethods/help.aspx/getHelp";
    enviarComoParametros(url, help, OnSuccesObjectHelp);
}

function OnSuccesObjectHelp(response)
{    
    object = eval("(" + response.getCadena + ")");
    $(help.campoIdReturn).val(object.id);
    $(help.campoReturnView).val(object[help.atributoReturnView]);
    $(help.campoDescripReturn).val(object[help.atributoReturnDescripcion]);
}