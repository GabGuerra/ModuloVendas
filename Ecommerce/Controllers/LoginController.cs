using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.Resultado;
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

        public JsonResult RealizarLogin(string email, string senha)
        {
            ResultadoVD resultado = _loginService.RealizarLogin(email, senha);
            if (resultado.Sucesso)
                HttpContext.Session.SetString("usuarioLogado", JsonConvert.SerializeObject(resultado.ObjResultado));

            return Json(resultado);
        }
    }
}