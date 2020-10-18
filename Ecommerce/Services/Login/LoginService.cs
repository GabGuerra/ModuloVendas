using Ecommerce.Models.Resultado;
using Ecommerce.Models;
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

        public UsuarioVD RealizarLogin(LoginVD login)
        {            
           return _loginRepository.RealizarLogin(login.Email, login.Senha);
        }
    }
}

