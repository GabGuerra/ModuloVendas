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
    }
}
