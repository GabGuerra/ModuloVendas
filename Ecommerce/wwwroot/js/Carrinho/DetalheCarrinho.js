function RegistraEventoClickFinalizarCompra() {
    $('#modalLogin').on('shown.bs.modal');
};

function FinalizarCompra() {
    $.ajax({
        url: "/Login/VerificaUsuarioLogado",
        data: {  },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result) {
                ConcluirFinalizacaoCompra();
            }
            else {
                AbrirModalLogin();
            }                
        },
        error: function (result) {
            console.log(result);
        }
    });
};

function ConcluirFinalizacaoCompra() {
    var model = $('#modelDetalheCarrinho').data('model');

    $.ajax({
        url: "/Carrinho/FinalizarCompra",
        data:
        {
            carrinho: model
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result) {
                ConcluirFinalizacaoCompra();
            }
            else {
                AbrirModalLogin();
            }
        },
        error: function (result) {
            console.log(result);
        }
    });
};

function AbrirModalLogin() {
    $("#modalLogin").modal('show');
};
