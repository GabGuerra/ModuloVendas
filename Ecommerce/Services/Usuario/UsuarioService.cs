using Ecommerce.Models.Resultado;
using Ecommerce.Models;
using Ecommerce.Repositories.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public ResultadoVD InserirUsuario(UsuarioVD usuario) 
        {
            ResultadoVD resultado = new ResultadoVD(true);
            try
            {
                _usuarioRepository.InserirUsuario(usuario);
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível inserir o usuário. {Environment.NewLine} {ex.Message}";
            }

            return resultado;
        }
    }
}
