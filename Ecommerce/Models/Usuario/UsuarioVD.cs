using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Usuario
{
    public class UsuarioVD
    {
        public UsuarioVD()
        {
        }
        public UsuarioVD(LoginVD login)
        {
            Login = login;
        }
        public UsuarioVD(string cpf, string nome, LoginVD login)
        {
            Cpf = cpf;
            Nome = nome;
            Login = login;
        }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public LoginVD Login { get; set; }
    }
}
