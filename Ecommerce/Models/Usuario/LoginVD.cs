using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Usuario
{
    public class LoginVD
    {
        public LoginVD()
        {

        }
        public LoginVD(string senha, string email)
        {
            this.Senha = senha;
            this.Email = email;
        }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
