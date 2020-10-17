using Ecommerce.Models.Resultado;
using Ecommerce.Models.Usuario;
using Ecommerce.Repositories.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public ResultadoVD RealizarLogin(string email, string senha)
        {
            ResultadoVD resultado = new ResultadoVD();
            UsuarioVD usuario = null;
            using (var dr = _loginRepository.RealizarLogin(email, senha))
            {
                try
                {
                    if (dr.Read())
                    {
                        usuario = new UsuarioVD
                            (
                                dr["CPF_USUARIO"].ToString(),
                                dr["NOME_USUARIO"].ToString(),
                                new LoginVD(email, senha)
                            );
                    }
                }
                catch (Exception ex)
                {
                    resultado.Sucesso = false;
                    resultado.Mensagem = $"Não foi possível realizar login: {Environment.NewLine} {ex.Message}";
                    return resultado;
                }
                finally
                {
                    dr.Close();
                }

                resultado.Sucesso = usuario != null ? true : false;
                resultado.Mensagem = resultado.Sucesso ? string.Empty : "Email e/ou senha incorretos";
                resultado.ObjResultado = usuario;
                return resultado;
            }
        }
    }
}
