using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Usuario
{
    public interface IUsuarioRepository
    {
        public void InserirUsuario(UsuarioVD usuario);
    }
}
