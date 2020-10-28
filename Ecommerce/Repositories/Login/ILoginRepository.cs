using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Login
{
    public interface ILoginRepository
    {
        public UsuarioVD RealizarLogin(string email, string senha);
        public void MigrarCarrinhoCookieParaLogado(string cpfUsuario, int codCarrinhoCookie);
        public int GetCodCarrinhoLogado(string cpfUsuarioLogado);
    }
}
