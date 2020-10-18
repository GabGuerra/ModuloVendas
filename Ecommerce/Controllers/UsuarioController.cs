using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult CadastroUsuarioIndex()
        {
            return View();
        }

        public JsonResult InserirUsuario(string cpf, string nome, string email, string senha) 
        {            
            return Json(_usuarioService.InserirUsuario(new UsuarioVD(cpf, nome, new LoginVD(senha, email))));
        }
    }
}