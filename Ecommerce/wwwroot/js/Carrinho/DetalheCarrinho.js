function RegistraEventoClickFinalizarCompra() {
    $('#modalLogin').on('shown.bs.modal');
};

function FinalizarCompra() {
    $.ajax({
        url: "/Login/VerificaUsuarioLogado",
        data: {},
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
    var carrinho = $('#modelDetalheCarrinho').data('model');
    
    $.ajax({
        type: "POST",
        url: "/Carrinho/FinalizarCompra",
        contentType: "application/json; charset=utf-8",
        data: { carrinho },
        dataType: "json",                
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


function CancelarCompra() {
    var CodCarrinho = $('#modelDetalheCarrinho').data('model').CodCarrinho;
    $.ajax({
        url: "/Carrinho/CancelarCarrinho",
        data:
        {
            codCarrinho: CodCarrinho
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (retorno) {
            if (retorno.sucesso) {
                alert("SUCESSO! " + retorno.mensagem);
                RedirecionaParaPagina("Home", "Vitrine");
            }
            else {
                alert(+"ERRO! ", retorno.mensagem)
            }
        },
        error: function (result) {
            alert(+"ERRO! ", retorno.Mensagem)
        }
    });
};