using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.Resultado;
using Ecommerce.Models;
using Ecommerce.Services.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Login()
        {
            return View();
        }
        public JsonResult RealizarLogin(LoginVD login)
        {
            ResultadoVD result = new ResultadoVD();
            UsuarioVD usuario = _loginService.RealizarLogin(login);
            result.Sucesso = usuario != null;
            if (result.Sucesso)
                HttpContext.Session.SetString("usuarioLogado", JsonConvert.SerializeObject(usuario));

            result.Mensagem = result.Sucesso ? string.Empty : "Email e/ou senha incorretos.";

            return Json(result);
        }
    }
}