
function incrementarContador() {
    var val = Number($("#contQtdItem").val()) + 1;
    $("#contQtdItem").val(val);
    AtualizarPreco();
}

function decrementarContador() {
    var val = Number($("#contQtdItem").val()) - 1;
    $("#contQtdItem").val(val);
    AtualizarPreco();
}

function AtualizarPreco() {
    $("#spanPreco").text(Number($("#valPrecoOriginal").val()) * Number($("#contQtdItem").val()));
}

function AdicionarAoCarrinho() {    
    let param = {
        CodProduto: $("#codProduto").val(),
        QtdProduto: $("#contQtdItem").val(),
        CpfUsuario: ""
    }

    $.ajax({
        url: "/Carrinho/AdicionarItem",
        data: { codProduto: param.CodProduto, qtdProduto: param.QtdProduto, cpfUsuario: param.CpfUsuario },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.sucesso) {
                alert("Sucesso");                
            }
            else
                alert(result.mensagem);
        },
        error: function (result) {
            console.log(result);
        }
    });
};

