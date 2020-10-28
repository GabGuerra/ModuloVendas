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
 
    var teste = JSON.stringify({ 'carrinho': model });
    console.log(teste);
    $.ajax({
        url: "/Carrinho/FinalizarCompra",
        data: teste,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (result) {
            if (result.sucesso) {
                alert("Pedido realizado com sucesso!");
                RedirecionaParaPagina("Home/Vitrine");
            }
            else {
                alert(result.mensagem);
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
