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

            if (Convert.ToString(Request.Cookies["codCarrinho"]) != null)//quando for logar e possuir algo no cookie passa as infos pro carrinho do usuario.
            {
                var novoCodCarrinho = _loginService.TransferirDadosCarrinhoCookie(usuario.Cpf, Convert.ToInt32(Request.Cookies["codCarrinho"]));
                Response.Cookies.Append("codCarrinho", novoCodCarrinho.ToString());
            }
            else if (result.Sucesso) //Se por algum motivo os cookies forem limpos, ao logar seta o cod do usuario logado
                Response.Cookies.Append("codCarrinho", _loginService.GetCodCarrinhoLogado(usuario.Cpf).ToString());

            result.Mensagem = result.Sucesso ? string.Empty : "Email e/ou senha incorretos.";

            return Json(result);
        }

        public JsonResult VerificaUsuarioLogado()
        {
            var usuario = HttpContext.Session.GetString("usuarioLogado");
            return Json(usuario != null && usuario != string.Empty);
        }
    }
}