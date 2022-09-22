// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    $('.btn-deletar-contato').click(function () {
        var tarefaId = $(this).attr('tarefa-id');

        $.ajax({
            type: 'GET',
            url: '/Tarefa/ConfirmarExclusao/' + tarefaId,
            success: function (result) {
              
                $('.tarefaExclusao').html(result);
                $('#modalTarefaExclusao').modal('show');
            }
        });
    });
});