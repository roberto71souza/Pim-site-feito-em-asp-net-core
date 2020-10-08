// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
});
function LimparCampos() {
    var nome = document.getElementById("nome");
    var email = document.getElementById("email");
    var telefone = document.getElementById("telefone");
    var mensagem = document.getElementById("mensagem");

    nome.value = '';
    email.value = '';
    telefone.value = '';
    mensagem.value = '';
}
