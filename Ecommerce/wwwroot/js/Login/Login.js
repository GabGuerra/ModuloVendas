$("#LoginForm").submit(function (e) {    
    let senha = $('#LoginForm input[name="inputSenha"]').val();
    let email = $('#LoginForm input[name="inputEmail"]').val();
    let login = { Email: email, Senha: senha };

    $.ajax({

        url: "/Login/RealizarLogin",
        data: login,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.sucesso)
                RedirecionarParaPaginaInicial();
            else
                alert(result.mensagem);
        },
        error: function (result) {
            console.log(result);
        }
    });
    e.preventDefault();


    function RedirecionarParaPaginaInicial() {
        window.location.href = window.location.origin + "/Home/Index";
    };
});