const uri = "api/contribuinte";

$(document).ready(function () {
    $('#table_contribuintes_ir_calculado').hide();
    $('.cpf').mask('000.000.000-00', { reverser: true });
    $('.money').mask('000000000000000.00', { reverse: true });
    getContribuintes();
});

function getContribuintes() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#contribuintes').empty();
            $.each(data, function (key, contribuinte) {

                $('#contribuintes').append('<tr>' +
                    '<td>' + contribuinte.nome + '</td> ' +
                    '<td>' + contribuinte.cpf + '</td> ' +
                    '<td>' + contribuinte.numeroDependentes + '</td> ' +
                    '<td>' + contribuinte.rendaBrutaMensal + '</td> ' +
                    '</tr>');
            });
        }
    });
}

function getContribuintesIRCalculado() {
    $.ajax({
        type: 'GET',
        url: uri + '/ir_calculado/' + parseFloat($('#salario_minimo').val()),
        success: function (data) {
            $('#table_contribuintes_ir_calculado').show();
            $('#contribuintes_ir_calculado').empty();
            $.each(data, function (key, contribuinte) {

                $('#contribuintes_ir_calculado').append('<tr>' +
                    '<td>' + contribuinte.nome + '</td> ' +
                    '<td>' + contribuinte.cpf + '</td> ' +
                    '<td>' + contribuinte.ir+ '</td> ' +
                    '</tr>');
            });
        }
    });
}

function addContribuinte() {
    var contribuinte = {
        "cpf": $('#cpf').val(),
        "nome": $('#nome').val(),
        "numeroDependentes": parseInt($('#dependentes').val()),
        "rendaBrutaMensal": parseFloat($('#renda').val())
    }

    console.log(contribuinte);

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(contribuinte),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Erro ao incluir contribuinte');
        },
        success: function (result) {
            getContribuintes();
        }
    });
}