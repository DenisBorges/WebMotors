$('.btnExcluir').on('click', function () {
    
    let card = $(this).closest('.card');

    let id = card.attr('id');

    $.ajax({
        url: `ExcluirAnuncio?id=${id}`,
        type: 'DELETE',
        success: () => {
            alert('Excluido com sucesso')
            card.hide();
        },
        error: () => {}

    })

});

$('.btnEditar').on('click', function () {

    debugger;

    let card = $(this).closest('.card');

    let id = card.attr('id');

    window.location.href = `Cadastrar?id=${id}`;

});