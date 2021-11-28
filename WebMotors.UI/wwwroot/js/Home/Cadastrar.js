$('#Marca').on('change', function () {

    let option = $('#Marca option:selected').val()

    let modeloEl = $("#Modelo");
    let versaoEl = $("#Versao");

    $.ajax({
        url: `GetModelo?makeId=${option}`,
        contentType: 'application/json',
        type: 'GET',
        beforeSend: () => {
            modeloEl.empty();
            modeloEl.attr('disabled', 'disabled');

            versaoEl.empty();
            versaoEl.attr('disabled', 'disabled');
        },
        success: (data) => {

            if (!!data) {

                modeloEl.append($(`<option selected value='-1'>Selecione...</option>`));

                $.map(data, function (e, i) {

                    let option = $(`<option value='${e.id}'>${e.name}</option>`);

                    modeloEl.append(option);

                })

                modeloEl.removeAttr("disabled");
            }
        },
        error: () => { }
    })
})

$('#Modelo').on('change', function () {

    let option = $('#Modelo option:selected').val()

    let versaoEl = $("#Versao");

    $.ajax({
        url: `GetVersion?modelId=${option}`,
        contentType: 'application/json',
        type: 'GET',
        beforeSend: () => {
            versaoEl.empty();
            versaoEl.attr('disabled', 'disabled');
        },
        success: (data) => {

            if (!!data) {

                versaoEl.append($(`<option selected value='-1'>Selecione...</option>`));

                $.map(data, function (e, i) {

                    let option = $(`<option value='${e.id}'>${e.name}</option>`);

                    versaoEl.append(option);

                })

                versaoEl.removeAttr("disabled");
            }
        },
        error: () => { }
    })
})

$('#btnSalvar').click(cadastrar)
$('#btnAtualizar').click(cadastrar)

function cadastrar() {

    let isUpdate = $(this).attr('id') == 'btnAtualizar';

    let anuncio = getPayload();

    var serialized = JSON.stringify(anuncio);
    debugger;

    $.ajax({
        url: 'Cadastrar',
        data: serialized,
        contentType: 'application/json',
        type: 'POST',
        success: (response) => {

            if (response) {
                if (isUpdate) {
                    alert('Atualizado com sucesso');
                    window.location.href = 'ListarTodos';
                    return;
                } else {
                    alert('Cadastrado com sucesso');
                }

                limparCampos();
            } else {
                alert('Ocorreu um erro durante o cadastro')
            }

        }
    })
};

function getPayload() {

    let anuncio = {}
    anuncio.ID = $('#anuncio').attr('data-id');
    anuncio.marca = $('#Marca option:selected').text() || '';
    anuncio.modelo = $('#Modelo option:selected').text() || '';
    anuncio.versao = $('#Versao option:selected').text() || '';
    anuncio.ano = $('#Ano').val() || '0';
    anuncio.quilometragem = $('#Quilometragem').val() || '0';
    anuncio.observacao = $('#Observacao').val() || '';

    return anuncio;
}

function limparCampos() {
    $('#Marca').val('-1');
    $('#Modelo').val('-1');
    $('#Versao').val('-1');
    $('#Ano').val('');
    $('#Quilometragem').val('');
    $('#Observacao').val('');
}