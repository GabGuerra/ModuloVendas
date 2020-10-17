$(document).ready(function () {
    RegistrarEventoSubmitForm();
    SetarMascaraCpf("#inputCpfCadastroUsuario");
});

function RegistrarEventoSubmitForm() {
    $("#CadastroUsuarioForm").submit(function (e) {
        e.preventDefault();

        let nome = $('#inputNomeCadastro').val();
        let email = $('#inputEmailCadastro').val();
        let cpf = $('#inputCpfCadastroUsuario').val();
        let senha = $('#inputSenhaCadastro').val();
        let confirmacaoSenha = $('#inputConfirmacaoSenha').val();

        let usuario = {
            Cpf: cpf,
            Nome: nome,
            Login: {
                Email: email,
                Senha: senha
            }
        };
        if (senha == confirmacaoSenha) {
            $.ajax({
                url: "/Usuario/InserirUsuario",
                data: { cpf: cpf, nome: nome, email: email, senha: senha },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result.sucesso) {
                        alert("Sucesso");
                        RedirecionaParaPagina("Usuario", "CadastroUsuario");
                    }
                    else
                        alert(result.mensagem);
                },
                error: function (result) {
                    console.log(result);
                }
            });
        } else {
            alert("A confirmação de senha deve ser igual a senha.");
        }
    });
};

