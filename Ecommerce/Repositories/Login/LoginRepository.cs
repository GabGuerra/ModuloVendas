using Ecommerce.Models;
using Ecommerce.Repositories.Shared;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Login
{
    public class LoginRepository : DbRepository<UsuarioVD>, ILoginRepository
    {
        public LoginRepository(IConfiguration config) : base(config) { }

        public UsuarioVD RealizarLogin(string email, string senha)
        {
            string sql = @"SELECT 
                               U.NOME_USUARIO,
                               U.CPF,
                               L.*
                           FROM

                               USUARIO U
                           INNER JOIN LOGIN L ON U.CPF = L.CPF_USUARIO
                           WHERE
                               L.SENHA = @SENHA
                           AND L.EMAIL = @EMAIL";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@SENHA", senha);
                cmd.Parameters.AddWithValue("@EMAIL", email);
                UsuarioVD usuario = ObterRegistro(cmd);
                if(usuario !=null)
                    usuario.Login = new LoginVD(email, senha);
                return usuario;
            }
        }

        public override UsuarioVD PopularDados(MySqlDataReader dr)
        {
            return new UsuarioVD
            {
                Cpf = dr["CPF"].ToString(),
                Nome = dr["NOME_USUARIO"].ToString()
            };
        }

        public void MigrarCarrinhoCookieParaLogado(string cpfUsuario, int codCarrinhoCookie)
        {
            var sql = @"CALL PROC_MIGRACAO_CARRINHO(@P_COD_CPF_USUARIO, @P_COD_CARRINHO_COOKIE)";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@P_COD_CPF_USUARIO", cpfUsuario);
                cmd.Parameters.AddWithValue("@P_COD_CARRINHO_COOKIE", codCarrinhoCookie);                

                ExecutarComando(cmd);
            }
        }

        public int GetCodCarrinhoLogado(string cpfUsuario) 
        {
            var sql = @"SELECT COD_CARRINHO FROM CARRINHO WHERE CARRINHO.CPF_USUARIO = @CPF_USUARIO";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@CPF_USUARIO", cpfUsuario);                

                return ExecutarComando(cmd);
            }
        }
    }
}
